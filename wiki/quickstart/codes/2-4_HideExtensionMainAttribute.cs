using System;

using BveEx.PluginHost.Plugins;
using BveEx.PluginHost.Plugins.Extensions;

[Plugin(PluginType.Extension)]
[HideExtensionMain]
internal class 任意のクラス名 : AssemblyPluginBase, IExtension
{
    // ...略...
}
