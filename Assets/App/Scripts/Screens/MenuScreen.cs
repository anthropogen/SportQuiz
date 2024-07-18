using UnityEngine;
using Screen = Bootstrapper.UI.Screen;

public class MenuScreen : Screen
{
  [SerializeField] private MenuSystem menuSystem;
  [SerializeField] private SettingsPopup settingsPopup;
  [SerializeField] private MainMenuPopup mainPopup;
  [SerializeField] private StatisticsPopup statisticsPopup;
  [SerializeField] private SelectionPopup selectionPopup;
  [SerializeField] private UserPopup userPopup;

  public void Init()
  {
    settingsPopup.Init(SetMain, menuSystem);
    statisticsPopup.Init(SetMain);
    userPopup.Init(menuSystem, SetMain, OpenSettings);
    mainPopup.Init(menuSystem, this);
  }

  public override void Open()
  {
    base.Open();
    SetMain();
  }

  public void OpenSettings()
  {
    mainPopup.gameObject.SetActive(false);
    settingsPopup.gameObject.SetActive(true);
    userPopup.gameObject.SetActive(false);
    statisticsPopup.gameObject.SetActive(false);
  }

  private void SetMain()
  {
    selectionPopup.gameObject.SetActive(false);
    mainPopup.gameObject.SetActive(true);
    settingsPopup.gameObject.SetActive(false);
    userPopup.gameObject.SetActive(false);
    statisticsPopup.gameObject.SetActive(false);
  }

  public void OpenStatistics()
  {
    mainPopup.gameObject.SetActive(false);
    settingsPopup.gameObject.SetActive(false);
    userPopup.gameObject.SetActive(false);
    statisticsPopup.Open(menuSystem);
    statisticsPopup.gameObject.SetActive(true);
  }

  public void OpenUser()
  {
    mainPopup.gameObject.SetActive(false);
    settingsPopup.gameObject.SetActive(false);
    userPopup.gameObject.SetActive(true);
    statisticsPopup.gameObject.SetActive(false);
  }
}