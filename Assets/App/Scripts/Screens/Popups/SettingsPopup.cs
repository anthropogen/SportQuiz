using System;
using System.Collections.Generic;
using Bootstrapper;
using Bootstrapper.Data;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
  [SerializeField] private Button backBtn;
  [SerializeField] private Button privacyBtn;
  [SerializeField] private Button clearAllDataBtn;
  [SerializeField] private Button clearAllAchievementsBtn;

  public void Init(Action onBackClick, MenuSystem menuSystem)
  {
    backBtn.onClick.AddListener(() => onBackClick?.Invoke());
    clearAllDataBtn.onClick.AddListener(() =>
    {
      var data = menuSystem.GetPlayerData;
      data.categories = new List<CategoryDto>();
      data.totalQuiz = 0;
      data.passedQuiz = 0;
      data.failedQuiz = 0;
      data.successQuizSeries = 0;
      data.straightQuiz = false;
      data.name = "";
      HyperBootstrapper.Instance.Save();
    });

    clearAllAchievementsBtn.onClick.AddListener(() =>
    {
      var data = menuSystem.GetPlayerData;
      if (data.TryGetCategory("Tennis", out var dto))
      {
        dto.rightAnswers = 0;
      }

      data.totalQuiz = 0;
      data.passedQuiz = 0;
      data.failedQuiz = 0;
      data.straightQuiz = false;
      HyperBootstrapper.Instance.Save();
    });
  }
}