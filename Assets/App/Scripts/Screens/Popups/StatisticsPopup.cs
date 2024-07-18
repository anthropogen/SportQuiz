using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsPopup : MonoBehaviour
{
  [SerializeField] private Button backBtn;
  [SerializeField] private TMP_Text failedTxt;
  [SerializeField] private TMP_Text passedTxt;
  [SerializeField] private TMP_Text totalTxt;
  [SerializeField] private AchievementView openTennis;
  [SerializeField] private AchievementView straightThree;
  [SerializeField] private AchievementView passAll;

  public void Init(Action clickBack)
  {
    backBtn.onClick.AddListener(() => clickBack?.Invoke());
  }

  public void Open(MenuSystem menuSystem)
  {
    var data = menuSystem.GetPlayerData;
    failedTxt.text = $"You failed {data.failedQuiz}";
    passedTxt.text = $"You passed {data.passedQuiz}";
    totalTxt.text = $"Total quizes {data.totalQuiz}";

    var maxTennis = Helper.GetQuestionsNumFor(Difficult.Hard);
    if (data.TryGetCategory("Tennis", out var dto))
      openTennis.SetState(dto.rightAnswers >= maxTennis);
    else
      openTennis.SetState(false);

    straightThree.SetState(data.straightQuiz);
    passAll.SetState(PassAll(menuSystem));
  }

  private bool PassAll(MenuSystem menu)
  {
    var save = menu.GetPlayerData;
    var blueprint = menu.GetBlueprint;
    var max = Helper.GetQuestionsNumFor(Difficult.Hard);
    foreach (var c in blueprint.root.categories)
    {
      if (save.TryGetCategory(c.name, out var dto))
      {
        if (dto.rightAnswers < max) return false;
      }
      else
        return false;
    }

    return true;
  }
}