using System;

using BveTypes.ClassWrappers;

using BveEx.Extensions.Native;
using BveEx.PluginHost;
using BveEx.PluginHost.Input;
using BveEx.PluginHost.Plugins;

namespace BveEx.Samples.MapPlugins.TrainController {
    // 規定のクラスを継承することでプラグインとみなされる
    [Plugin(PluginType.MapPlugin)]
    public class TrainController : AssemblyPluginBase {
        private Train Train;
        private double Speed = 25 / 3.6; // 25 km/h = 25 / 3.6 m/s

        public TrainController(PluginBuilder builder) : base(builder) {
            BveHacker.ScenarioCreated += OnScenarioCreated;
        }

        public override void Dispose() {
            BveHacker.ScenarioCreated -= OnScenarioCreated;
        }

        private void OnScenarioCreated(ScenarioCreatedEventArgs e) {
            // 本サンプルでは、キーが 'test' の他列車を操作する。
            // 操作対象の他列車が定義されていない場合はエラーで終了
            if (!e.Scenario.Trains.TryGetValue("test", out Train train)) {
                throw new BveFileLoadException("キーが 'test' の他列車が見つかりませんでした。", "TrainController");
            }

            Train = train;
        }

        public override void Tick(TimeSpan elapsed) {
            // F キーが押下されていたら減速、G キーが押下されていたら加速
            INative native = Extensions.GetExtension<INative>();
            if (native.AtsKeys.GetKey(AtsKeyName.F).IsPressed) Speed -= 10.0 * elapsed.Ticks / TimeSpan.TicksPerMillisecond / 1000;
            if (native.AtsKeys.GetKey(AtsKeyName.G).IsPressed) Speed += 10.0 * elapsed.Ticks / TimeSpan.TicksPerMillisecond / 1000;

            // キーの押下にかかわらず、時間経過に応じて一定程度減速させる
            if (Speed > 0) {
                Speed -= 2.0 * elapsed.Ticks / TimeSpan.TicksPerMillisecond / 1000;
                if (Speed < 0) Speed = 0d;
            } else if (Speed < 0) {
                Speed += 2.0 * elapsed.Ticks / TimeSpan.TicksPerMillisecond / 1000;
                if (Speed > 0) Speed = 0d;
            }

            // ここまで計算した速度をもとに、操作対象の他列車の位置 (距離程) と速度を更新
            Train.Location += Speed * elapsed.Ticks / TimeSpan.TicksPerMillisecond / 1000;
            Train.Speed = Speed;
        }
    }
}
