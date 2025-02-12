using System;

using BveEx.PluginHost.Plugins;
using BveEx.PluginHost.Plugins.Extensions;

[Plugin(PluginType.Extension)]
[ExtensionMainDisplayType(typeof(IHogeExtension))]
internal class PluginMain : AssemblyPluginBase, IHogeExtension
{
    // ...略...
}

public interface IHogeExtension : IExtension
{
}
