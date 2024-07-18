using Bootstrapper.StateMachine;
using UnityEngine;

public class ResultSystem : GameSystem
{
  [SerializeField] private ResultScreen resultScreen;

  internal override void EnterState()
  {
    resultScreen.Init(gameData.Category, gameData.RightAnswers, Helper.GetQuestionsNumFor(gameData.Difficult));
  }
}