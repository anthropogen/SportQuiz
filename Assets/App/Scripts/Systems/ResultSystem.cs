using Bootstrapper;
using Bootstrapper.Data;
using Bootstrapper.StateMachine;
using UnityEngine;

public class ResultSystem : GameSystem
{
  [SerializeField] private ResultScreen resultScreen;

  internal override void EnterState()
  {
    var max = gameData.gameMode == GameMode.Simple ? Helper.GetQuestionsNumFor(gameData.Difficult) : 90;
    resultScreen.Init(gameData.gameMode, gameData.Category, gameData.RightAnswers, max);

    playerData.totalQuiz++;

    if (gameData.gameMode == GameMode.Simple)
    {
      if (gameData.RightAnswers >= max)
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
    }
    else
    {
      if (gameData.RightAnswers >= max)
      {
        playerData.successQuizSeries++;
      }
      else
      {
        playerData.successQuizSeries = 0;
        playerData.failedQuiz++;
      }
    }


    HyperBootstrapper.Instance.Save();
  }
}