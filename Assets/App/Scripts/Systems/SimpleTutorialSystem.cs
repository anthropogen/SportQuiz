using Bootstrapper.StateMachine;
using UnityEngine;

public class SimpleTutorialSystem : GameSystem
{
  [SerializeField] private TutorialScreen tutorialScreen;

  internal override void EnterState()
  {
    tutorialScreen.SetCategory(gameData.Category);
  }
}