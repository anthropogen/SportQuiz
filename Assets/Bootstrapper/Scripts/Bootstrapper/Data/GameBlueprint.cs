using System.Collections.Generic;
using UnityEngine;

namespace Bootstrapper.Data
{
  [CreateAssetMenu(fileName = "GameBlueprint", menuName = "New GameBlueprint")]
  public class GameBlueprint : ScriptableObject
  {
    public Root root;
  }

  [System.Serializable]
  public class Category
  {
    public string name;
    public Sprite icon;
    public string rules;
    public List<Level> levels;
  }

  [System.Serializable]
  public class Level
  {
    public string question;
    public List<string> options;
    public string answer;
  }

  [System.Serializable]
  public class Root
  {
    public List<Category> categories;
  }
}