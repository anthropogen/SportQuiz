using Bootstrapper.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Screen = Bootstrapper.UI.Screen;

public class TutorialScreen : Screen
{
  [SerializeField] private SimpleTutorialSystem tutorialSystem;
  [SerializeField] private Button backBtn;
  [SerializeField] private Button playBtn;
  [SerializeField] private TMP_Text titleTxt;
  [SerializeField] private TMP_Text rulesTxt;
  [SerializeField] private Image icon;
  
  public void SetCategory(Category category)
  {
    rulesTxt.text = category.rules;
    icon.sprite = category.icon;
    titleTxt.text = $"Rules \nof the \n{category.name}";
  }

  protected override void Subscribe()
  {
    backBtn.onClick.AddListener(tutorialSystem.ToMenu);
    playBtn.onClick.AddListener(tutorialSystem.ToGame);
  }

  internal override void Unsubscribe()
  {
    backBtn.onClick.RemoveListener(tutorialSystem.ToMenu);
    playBtn.onClick.RemoveListener(tutorialSystem.ToGame);
  }
}