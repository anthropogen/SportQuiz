using System.Collections.Generic;
using Bootstrapper.Data;
using Bootstrapper.StateMachine;
using UnityEngine;
using Random = System.Random;

public class RunGameSystem : GameSystem
{
  [SerializeField] private GameScreen gameScreen;
  private readonly float maxSec = 30f;
  private int currentQuestion;
  private int endlessCurrentQuestion = 0;
  private int categoryIndex;
  private Category category;
  private float time;

  internal override void EnterState()
  {
    category = gameData.gameMode == GameMode.Simple ? gameData.Category : blueprint.root.categories[0];
    currentQuestion = 0;
    endlessCurrentQuestion = 0;
    categoryIndex = 0;
    gameData.RightAnswers = 0;
    ShuffleCategory();

    SetQuestion();
    gameScreen.SetIcon(category.icon);
  }

  private void ShuffleCategory()
  {
    Shuffle(category.levels);
    foreach (var lvl in category.levels)
      Shuffle(lvl.options);
  }

  internal override void Loop()
  {
    time += Time.deltaTime;
    gameScreen.SetTimer(Mathf.RoundToInt(maxSec - time));
    if (time >= maxSec)
      ToResult();
  }

  public void SelectAnswer(string answer)
  {
    if (category.levels[currentQuestion].answer.Equals(answer))
    {
      gameData.RightAnswers++;
    }

    currentQuestion++;
    if (gameData.gameMode == GameMode.Simple)
    {
      if (currentQuestion >= Helper.GetQuestionsNumFor(gameData.Difficult))
        ToResult();
      else
        SetQuestion();
    }
    else
    {
      endlessCurrentQuestion++;
      if (currentQuestion >= Helper.HardQuestionsNum)
      {
        currentQuestion = 0;
        categoryIndex++;
        if (categoryIndex >= blueprint.root.categories.Count)
        {
          ToResult();
        }
        else
        {
          category = blueprint.root.categories[categoryIndex];
          ShuffleCategory();
          SetQuestion();
        }
      }
      else
      {
        SetQuestion();
      }
    }
  }

  private void SetQuestion()
  {
    time = 0;
    var max = gameData.gameMode == GameMode.Simple
      ? Helper.GetQuestionsNumFor(gameData.Difficult)
      : 90;
    var cur = gameData.gameMode == GameMode.Simple ? currentQuestion : endlessCurrentQuestion;
    gameScreen.SetQuestion(category.levels[currentQuestion]);
    gameScreen.SetCounter($"{cur}/{max}");
    gameScreen.SetTitle($"Question {cur}");
  }

  private void Shuffle<T>(List<T> list)
  {
    var random = new Random();
    for (int i = list.Count - 1; i > 0; i--)
    {
      var k = random.Next(i + 1);
      (list[k], list[i]) = (list[i], list[k]);
    }
  }
}

public enum GameMode
{
  Endless,
  Simple,
}