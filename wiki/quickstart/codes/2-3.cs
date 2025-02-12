using System;

using BveEx.PluginHost.Plugins;
using BveEx.PluginHost.Plugins.Extensions;

[Plugin(PluginType.Extension)]
internal class PluginMain : AssemblyPluginBase, IExtension
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
