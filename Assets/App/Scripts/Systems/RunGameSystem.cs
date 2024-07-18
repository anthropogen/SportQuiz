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
  private Category category;
  private float time;

  internal override void EnterState()
  {
    category = gameData.Category;
    currentQuestion = 0;
    gameData.RightAnswers = 0;
    Shuffle(category.levels);
    foreach (var lvl in category.levels)
      Shuffle(lvl.options);

    SetQuestion();
    gameScreen.SetIcon(category.icon);
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
    if (currentQuestion > Helper.GetQuestionsNumFor(gameData.Difficult))
      ToResult();
    else
      SetQuestion();
  }

  private void SetQuestion()
  {
    time = 0;
    var max = Helper.GetQuestionsNumFor(gameData.Difficult);
    gameScreen.SetQuestion(category.levels[currentQuestion]);
    gameScreen.SetCounter($"{currentQuestion}/{max}");
    gameScreen.SetTitle($"Question {currentQuestion}");
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