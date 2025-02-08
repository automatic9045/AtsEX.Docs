using System;

using BveTypes.ClassWrappers;

using BveEx.PluginHost.Plugins;

namespace BveEx.Samples.VehiclePlugins.SimpleAts {
    // 規定のクラスを継承することでプラグインとみなされる
    [Plugin(PluginType.VehiclePlugin)]
    public class SimpleAts : AssemblyPluginBase {
        public SimpleAts(PluginBuilder builder) : base(builder) {
        }

        public override void Dispose() {
        }

        public override void Tick(TimeSpan elapsed) {
            // 100 km/h 以上出ていたら常用最大ブレーキ
            if (100 / 3.6 < BveHacker.Scenario.VehicleLocation.Speed) {
                AtsPlugin atsPlugin = BveHacker.Scenario.Vehicle.Instruments.AtsPlugin;

                // 力行をNに設定
                atsPlugin.AtsHandles.PowerNotch = 0;

                // ブレーキをハンドル位置と常用最大の大きい方に設定
                int maxServiceBrakeNotch = atsPlugin.AtsHandles.NotchInfo.EmergencyBrakeNotch - 1;
                int brakeNotch = atsPlugin.Handles.BrakeNotch;
                atsPlugin.AtsHandles.BrakeNotch = Math.Max(maxServiceBrakeNotch, brakeNotch);

                // 定速制御を停止
                atsPlugin.AtsHandles.ConstantSpeedMode = ConstantSpeedMode.Disable;
            }
        }
    }
}
