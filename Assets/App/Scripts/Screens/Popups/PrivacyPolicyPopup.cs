using System;
using UnityEngine;
using UnityEngine.UI;

public class PrivacyPolicyPopup : MonoBehaviour
{
  [SerializeField] private Button backBtn;

  public void Init(Action clickBack)
  {
    backBtn.onClick.AddListener(() => clickBack?.Invoke());
  }
}