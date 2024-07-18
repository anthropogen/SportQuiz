using Bootstrapper.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Screen = Bootstrapper.UI.Screen;

public class ResultScreen : Screen
{
  [SerializeField] private Button menuBtn;
  [SerializeField] private Button playBtn;
  [SerializeField] private Slider slider;
  [SerializeField] private TMP_Text resultTxt;
  [SerializeField] private Image icon;
  [SerializeField] private TMP_Text title;
  [SerializeField] private ResultSystem resultSystem;

  public void Init(Category category, int current, int max)
  {
    slider.value = current / (float)max;
    resultTxt.text = $"Right {current} out of {max}";
    icon.sprite = category.icon;
    title.text = $"Rules \nof the \n{category.name}";
  }

  protected override void Subscribe()
  {
    menuBtn.onClick.AddListener(resultSystem.ToMenu);
    playBtn.onClick.AddListener(resultSystem.ToGame);
  }

  internal override void Unsubscribe()
  {
    menuBtn.onClick.RemoveListener(resultSystem.ToMenu);
    playBtn.onClick.RemoveListener(resultSystem.ToGame);
  }
}