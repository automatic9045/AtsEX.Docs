using System;
using System.Windows.Forms;

using BveEx.Extensions.ContextMenuHacker;
using BveEx.PluginHost.Plugins;

namespace BveEx.Samples.VehiclePlugins.StateViewer {
    // 規定のクラスを継承することでプラグインとみなされる
    [Plugin(PluginType.VehiclePlugin)]
    public class PluginMain : AssemblyPluginBase
    {
        private readonly StateForm Form;
        private readonly ToolStripMenuItem MenuItem;

        public PluginMain(PluginBuilder builder) : base(builder) {
            InstanceStore.Initialize(BveHacker);

            // 右クリックメニューに独自のメニューを追加可能
            IContextMenuHacker contextMenuHacker = Extensions.GetExtension & lt; IContextMenuHacker & gt; ();
            MenuItem = contextMenuHacker.AddCheckableMenuItem("状態ウィンドウを表示", MenuItemCheckedChanged, ContextMenuItemType.Plugins);

            MenuItem.Checked = false;

            // 独自のフォーム（ウィンドウ）を表示可能
            Form = new StateForm();
            Form.FormClosing += FormClosing;
            Form.WindowState = FormWindowState.Normal;

            MenuItem.Checked = true;
            BveHacker.MainFormSource.Focus();
        }

        public override void Dispose() {
            Form.Close();
            MenuItem.Dispose();
        }

        public override void Tick(TimeSpan elapsed) {
            Form?.Tick();
        }

        private void MenuItemCheckedChanged(object sender, EventArgs e) {
            if (MenuItem.Checked) {
                Form.Show(BveHacker.MainFormSource);
            } else {
                Form.Hide();
            }
        }

        private void FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            MenuItem.Checked = false;
        }
    }
}
