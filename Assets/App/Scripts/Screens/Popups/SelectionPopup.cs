using System;
using System.Collections.Generic;
using Bootstrapper.Data;
using LightScrollSnap;
using UnityEngine;
using UnityEngine.UI;

public class SelectionPopup : MonoBehaviour
{
  [SerializeField] private Button backBtn;
  [SerializeField] private CategorySelectionItem selectionItemTemplate;
  [SerializeField] private RectTransform content;
  [SerializeField] private ScrollSnap scrollSnap;
  [SerializeField] private MenuSystem menu;

  [SerializeField] private SelectDifficultBtn easyBtn;
  [SerializeField] private SelectDifficultBtn mediumBtn;
  [SerializeField] private SelectDifficultBtn hardBtn;

  private List<CategorySelectionItem> selectionItems;
  private int selected;

  public void Init(List<Category> categories, Action onBackClicked)
  {
    backBtn.onClick.AddListener(() => onBackClicked?.Invoke());
    scrollSnap.OnItemSelected.AddListener(OnPanelSelected);
    selectionItems = new List<CategorySelectionItem>();
    for (int i = 0; i < categories.Count; i++)
    {
      var item = Instantiate(selectionItemTemplate, content);
      item.UpdateContent(categories[i]);
      selectionItems.Add(item);
    }

    OnPanelSelected(null, 0);
    easyBtn.Init(OnClickEasy);
    mediumBtn.Init(OnClickMedium);
    hardBtn.Init(OnClickHard);
  }

  private void OnClickHard()
  {
    menu.Play(selectionItems[selected].Category, Difficult.Hard);
  }

  private void OnClickMedium()
  {
    menu.Play(selectionItems[selected].Category, Difficult.Medium);
  }

  private void OnClickEasy()
  {
    menu.Play(selectionItems[selected].Category, Difficult.Easy);
  }

  private void OnPanelSelected(RectTransform rect, int index)
  {
    selected = index;
    var item = selectionItems[index];
    if (menu.GetPlayerData.TryGetCategory(item.name, out var dto))
    {
      mediumBtn.SetInteractable(dto.rightAnswers >= Helper.MediumQuestionsNum);
      hardBtn.SetInteractable(dto.rightAnswers >= Helper.HardQuestionsNum);
    }
    else
    {
      mediumBtn.SetInteractable(false);
      hardBtn.SetInteractable(false);
    }
  }
}