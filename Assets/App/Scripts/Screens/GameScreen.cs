using Bootstrapper.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Screen = Bootstrapper.UI.Screen;

public class GameScreen : Screen
{
  [SerializeField] private RunGameSystem runGameSystem;
  [SerializeField] private Button backBtn;
  [SerializeField] private TMP_Text title;
  [SerializeField] private TMP_Text counter;
  [SerializeField] private TMP_Text question;
  [SerializeField] private TMP_Text timerTxt;
  [SerializeField] private Image icon;
  [SerializeField] private AnswerBtn[] answerBtns;

  public void SetTitle(string count)
  {
    title.text = count;
  }
  
  public void SetIcon(Sprite icon)
  {
    this.icon.sprite = icon;
  }

  public void SetQuestion(Level level)
  {
    question.text = level.question;
    for (var i = 0; i < answerBtns.Length; i++)
    {
      var btn = answerBtns[i];
      btn.SetAnswer(level.options[i]);
      btn.SetInteractable(true);
    }
  }

  public void SetCounter(string txt)
  {
    counter.text = txt;
  }

  public void SetTimer(float time)
  {
    timerTxt.text = $"{time}";
  }

  protected override void Subscribe()
  {
    backBtn.onClick.AddListener(runGameSystem.ToMenu);
    foreach (var btn in answerBtns)
    {
      btn.Init(OnAnswerClicked);
    }
  }

  private void OnAnswerClicked(string answer)
  {
    foreach (var btn in answerBtns)
    {
      btn.SetInteractable(false);
    }

    runGameSystem.SelectAnswer(answer);
  }
}