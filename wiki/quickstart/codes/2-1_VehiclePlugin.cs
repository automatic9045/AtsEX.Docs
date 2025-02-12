using System;

using BveEx.PluginHost.Plugins;

[Plugin(PluginType.VehiclePlugin)]
internal class PluginMain : AssemblyPluginBase
{
    public PluginMain(PluginBuilder builder) : base(builder)
    {
    }

    public override void Dispose()
    {
    }

    public override void Tick(TimeSpan elapsed)
    {
    }
}
