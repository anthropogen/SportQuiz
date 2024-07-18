using UnityEngine;
using UnityEngine.UI;

public class MainMenuPopup : MonoBehaviour
{
  [SerializeField] private Button playBtn;
  [SerializeField] private Button settingsBtn;
  [SerializeField] private Button statiscticsBtn;
  [SerializeField] private Button userBtn;
  [SerializeField] private SelectionPopup selection;

  public void Init(MenuSystem menuSystem, MenuScreen menuScreen)
  {
    playBtn.onClick.AddListener(OpenSelection);
    settingsBtn.onClick.AddListener(menuScreen.OpenSettings);
    selection.Init(menuSystem.GetBlueprint.root.categories, CloseSelection);
    userBtn.onClick.AddListener(menuScreen.OpenUser);
    statiscticsBtn.onClick.AddListener(menuScreen.OpenStatistics);
  }

  private void OpenSelection()
  {
    gameObject.SetActive(false);
    selection.gameObject.SetActive(true);
  }

  private void CloseSelection()
  {
    gameObject.SetActive(true);
    selection.gameObject.SetActive(false);
  }
}