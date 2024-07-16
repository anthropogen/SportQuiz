using System;
using System.Collections.Generic;
using Bootstrapper.Data;
using DG.Tweening;
using LightScrollSnap;
using UnityEngine;
using UnityEngine.UI;

public class SelectionPopup : MonoBehaviour
{
  [SerializeField] private Button backBtn;
  [SerializeField] private CategorySelectionItem selectionItemTemplate;
  [SerializeField] private RectTransform content;
  [SerializeField] private ScrollSnap scrollSnap;
  private List<CategorySelectionItem> selectionItems;
  private readonly float scaleAnimDuration = 0.1f;
  private readonly Vector3 maxSizeItem = new Vector3(1.2f, 1.2f, 1f);
  private readonly Vector3 minSizeItem = new Vector3(1f, 1f, 1f);

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

    SelectItemAnim(selectionItems[0]);
  }

  private void OnPanelSelected(RectTransform arg0, int arg1)
  {
    
  }

  private void OnPanelCentered(int currentI, int prevI)
  {
    SelectItemAnim(selectionItems[currentI]);
    UnselectItemAnim(selectionItems[prevI]);
  }

  private void SelectItemAnim(CategorySelectionItem item)
  {
    item.transform.DOKill();
    item.transform.DOScale(maxSizeItem, scaleAnimDuration).SetAutoKill();
  }

  private void UnselectItemAnim(CategorySelectionItem item)
  {
    item.transform.DOKill();
    item.transform.DOScale(minSizeItem, scaleAnimDuration).SetAutoKill();
  }
}