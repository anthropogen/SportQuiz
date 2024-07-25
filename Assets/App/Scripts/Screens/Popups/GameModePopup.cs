using System;
using UnityEngine;
using UnityEngine.UI;

public class GameModePopup : MonoBehaviour
{
  [SerializeField] private MenuSystem menu;
  [SerializeField] private MainMenuPopup mainMenuPopup;
  [SerializeField] private Button backBtn;
  [SerializeField] private Button endlessBtn;
  [SerializeField] private Button simpleBtn;

  public void Init(Action clickBack)
  {
    backBtn.onClick.AddListener(() => clickBack?.Invoke());
    endlessBtn.onClick.AddListener(menu.PlayEndlessGame);
    simpleBtn.onClick.AddListener(mainMenuPopup.OpenSelection);
  }
}