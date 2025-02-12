using System;

using BveEx.PluginHost.Plugins;
using BveEx.PluginHost.Plugins.Extensions;

[Plugin(PluginType.Extension)]
[Togglable]
internal class PluginMain : AssemblyPluginBase, ITogglableExtension
{
    public bool IsEnabled
    {
        get
        {
            // ...
        }
        set
        {
            // ...
        }
    }

    // ...略...
}
