using System;
using Bootstrapper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserPopup : MonoBehaviour
{
  [SerializeField] private Button backBtn;
  [SerializeField] private Button settingsBtn;
  [SerializeField] private Button changeNameBtn;
  [SerializeField] private TMP_InputField inputField;
  [SerializeField] private TMP_Text nameTxt;
  private MenuSystem menu;

  public void Init(MenuSystem menu, Action onBackClick, Action onSettingsBtn)
  {
    this.menu = menu;
    backBtn.onClick.AddListener(() => onBackClick?.Invoke());
    settingsBtn.onClick.AddListener(() => onSettingsBtn?.Invoke());
    inputField.gameObject.SetActive(false);
    changeNameBtn.onClick.AddListener(OnStartInputName);
    inputField.onEndEdit.AddListener(OnEndInputName);
    nameTxt.text = menu.GetPlayerData.name;
  }

  private void OnEndInputName(string name)
  {
    menu.GetPlayerData.name = name;
    HyperBootstrapper.Instance.Save();
    nameTxt.text = name;
    nameTxt.gameObject.SetActive(true);
    inputField.gameObject.SetActive(false);
  }

  private void OnStartInputName()
  {
    nameTxt.gameObject.SetActive(false);
    inputField.gameObject.SetActive(true);
  }

  private void OnDisable()
  {
    nameTxt.gameObject.SetActive(true);
    inputField.gameObject.SetActive(false);
  }
}