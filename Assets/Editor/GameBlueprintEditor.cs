using System.Runtime.Serialization.Json;
using Bootstrapper.Data;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameBlueprint))]
public class GameBlueprintEditor : Editor
{
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    if (GUILayout.Button("Parse"))
    {
      var json = Resources.Load<TextAsset>("qz");
      var root = JsonUtility.FromJson<Root>(json.text);
      var bl = target as GameBlueprint;
      bl.root = root;
      EditorUtility.SetDirty(target);
    }
  }
}