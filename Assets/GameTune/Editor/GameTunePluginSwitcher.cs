using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class GameTunePluginSwitcher
{
    private const string AdSupportFrameworkId = "7b2ddd8e283a64223889aa59c9963753";
    private const string ContextualFrameworkId = "dd9c8b068f35a4ff69b768082da63254";

    static GameTunePluginSwitcher()
    {
        var adSupportFrameworkPath = AssetDatabase.GUIDToAssetPath(AdSupportFrameworkId);
        var contextualFrameworkPath = AssetDatabase.GUIDToAssetPath(ContextualFrameworkId);

        var adSupportFramework = AssetImporter.GetAtPath(adSupportFrameworkPath) as PluginImporter;
        var contextualFramework = AssetImporter.GetAtPath(contextualFrameworkPath) as PluginImporter;

        if (adSupportFramework != null) adSupportFramework.SetIncludeInBuildDelegate(ShouldIncludeAdSupport);
        if (contextualFramework != null) contextualFramework.SetIncludeInBuildDelegate(ShouldExcludeAdSupport);
    }

    private static bool ShouldIncludeAdSupport(string path)
    {
        var settings = GameTuneSettings.GetSerializedSettings();
        return settings.FindProperty("includeAdSupport").boolValue;
    }

    private static bool ShouldExcludeAdSupport(string path)
    {
        var settings = GameTuneSettings.GetSerializedSettings();
        return !settings.FindProperty("includeAdSupport").boolValue;
    }
}
