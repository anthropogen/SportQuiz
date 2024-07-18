using System;
using System.Collections.Generic;
using Bootstrapper.Data;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class AnswerBtn : MonoBehaviour
{
  [SerializeField] private Button btn;

  private string answer;

  public void Init(Action<string> onPressed)
  {
    btn.onClick.AddListener(() => onPressed?.Invoke(answer));
  }

  public void SetAnswer(string answer)
    => this.answer = answer;

  public void SetInteractable(bool state)
    => btn.interactable = state;
}

public class AnswersPopup : MonoBehaviour
{
  [SerializeField] private AnswerBtn[] answerBtns;

  private Level level;
  private int currentQuestion;

  public void Init()
  {
    foreach (var btn in answerBtns)
    {
      btn.Init(OnAnswer);
    }
  }

  public void SetCategory(Category category)
  {
    currentQuestion = 0;
    Shuffle(category.levels);
    foreach (var lvl in category.levels)
    {
      Shuffle(lvl.options);
    }
    // random.
    // level.question;
  }

  private void OnAnswer(string answer)
  {
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