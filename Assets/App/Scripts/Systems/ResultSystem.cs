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

    playerData.totalQuiz++;
    if (gameData.RightAnswers >= Helper.GetQuestionsNumFor(gameData.Difficult))
    {
      playerData.successQuizSeries++;
      if (playerData.straightQuiz == false && playerData.successQuizSeries >= 3)
      {
        playerData.straightQuiz = true;
      }

      playerData.passedQuiz++;
    }
    else
    {
      playerData.successQuizSeries = 0;
      playerData.failedQuiz++;
    }

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