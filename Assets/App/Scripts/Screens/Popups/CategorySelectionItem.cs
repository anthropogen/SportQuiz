using System;
using Bootstrapper.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategorySelectionItem : MonoBehaviour
{
  [SerializeField] private TMP_Text text;
  [SerializeField] private Image icon;

  public Category Category { get; private set; }

  public void UpdateContent(Category itemData)
  {
    text.text = itemData.name;
    icon.sprite = itemData.icon;
    Category = itemData;
  }
}