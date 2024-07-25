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

  public void PlaySimple(Category category, Difficult difficult)
  {
    gameData.gameMode = GameMode.Simple;
    gameData.Category = category;
    gameData.Difficult = difficult;
    ToTutorial();
  }

  public void PlayEndlessGame()
  {
    gameData.gameMode = GameMode.Endless;
    ToGame();
  }
}

public enum Difficult
{
  Easy,
  Medium,
  Hard
}