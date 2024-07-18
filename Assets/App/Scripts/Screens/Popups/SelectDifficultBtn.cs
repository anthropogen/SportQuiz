using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectDifficultBtn : MonoBehaviour
{
  [SerializeField] private Button btn;
  [SerializeField] private Image icon;
  [SerializeField] private TMP_Text lockTxt;
  [SerializeField] private Sprite lockIcon;
  [SerializeField] private Sprite playIcon;

  public void Init(Action onPlayClick)
  {
    btn.onClick.AddListener(() => onPlayClick?.Invoke());
  }

  public void SetInteractable(bool state)
  {
    btn.interactable = state;
    icon.sprite = state ? playIcon : lockIcon;
    lockTxt.gameObject.SetActive(!state);
  }
}