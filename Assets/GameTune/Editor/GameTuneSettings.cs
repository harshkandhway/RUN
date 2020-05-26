using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

class GameTuneSettings : ScriptableObject
{
    public const string k_GameTuneSettingsDirectory = "Assets/GameTune";
    public const string k_GameTuneSettingsFileName = "GameTuneSettings.asset";
    public static readonly string k_GameTuneSettingsPath = Path.Combine(k_GameTuneSettingsDirectory, k_GameTuneSettingsFileName);

    [SerializeField]
    private bool includeAdSupport;

    internal static GameTuneSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<GameTuneSettings>(k_GameTuneSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<GameTuneSettings>();

            // Include AsSupport by default
            settings.includeAdSupport = true;

            if (!Directory.Exists(k_GameTuneSettingsDirectory))
            {
                Directory.CreateDirectory(k_GameTuneSettingsDirectory);
            }

            AssetDatabase.CreateAsset(settings, k_GameTuneSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
}

static class GameTuneSettingsIMGUIRegister
{
    [SettingsProvider]
    public static SettingsProvider CreateGameTuneSettingsProvider()
    {
        var provider = new SettingsProvider("Project/GameTuneIMGUISettings", SettingsScope.Project)
        {
            label = "GameTune Settings",
            guiHandler = (searchContext) =>
            {
                var settings = GameTuneSettings.GetSerializedSettings();
                GUILayout.BeginVertical(EditorStyles.helpBox);
                {
                    GUILayout.Label("iOS ad settings", EditorStyles.boldLabel);
                    GUILayout.Label("If your game includes any ad framework you should also include AdSupport on iOS for GameTune. If not then you must not include it.", new GUIStyle(EditorStyles.label) { wordWrap = true });
                    EditorGUILayout.PropertyField(settings.FindProperty("includeAdSupport"), new GUIContent("Include AdSupport on iOS"));
                }
                GUILayout.EndVertical();
                settings.ApplyModifiedProperties();
            },

            keywords = new HashSet<string>(new[] { "GameTune" })
        };

        return provider;
    }
}
