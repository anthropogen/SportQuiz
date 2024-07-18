using Bootstrapper;
using Bootstrapper.Data;
using Bootstrapper.StateMachine;
using UnityEngine;

public class ResultSystem : GameSystem
{
  [SerializeField] private ResultScreen resultScreen;

  internal override void EnterState()
  {
    resultScreen.Init(gameData.Category, gameData.RightAnswers, Helper.GetQuestionsNumFor(gameData.Difficult));
    if (playerData.TryGetCategory(gameData.Category.name, out var dto))
    {
      dto.rightAnswers = dto.rightAnswers >= gameData.RightAnswers ? dto.rightAnswers : gameData.RightAnswers;
    }
    else
    {
      playerData.categories.Add(new CategoryDto
      {
        name = gameData.Category.name,
        rightAnswers = gameData.RightAnswers,
      });
    }

    HyperBootstrapper.Instance.Save();
  }
}