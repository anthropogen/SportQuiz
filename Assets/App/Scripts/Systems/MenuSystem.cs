using Bootstrapper.Data;
using Bootstrapper.StateMachine;
using UnityEngine;

public class MenuSystem : GameSystem
{
  [SerializeField] private MenuScreen menuScreen;

  internal override void EnterState()
  {
    menuScreen.Init();
  }

  public void Play(Category category, Difficult difficult)
  {
    gameData.Category = category;
    gameData.Difficult = difficult;
    ToTutorial();
  }
}

public enum Difficult
{
  Easy,
  Medium,
  Hard
}