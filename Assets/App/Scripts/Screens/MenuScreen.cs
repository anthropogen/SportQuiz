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
  [SerializeField] private GameModePopup gameModePopup;

  public void Init()
  {
    settingsPopup.Init(OpenMain, menuSystem);
    statisticsPopup.Init(OpenMain);
    userPopup.Init(menuSystem, OpenMain, OpenSettings);
    mainPopup.Init(menuSystem, this);
  }

  public override void Open()
  {
    base.Open();
    OpenMain();
  }

  public void OpenSettings()
  {
    mainPopup.gameObject.SetActive(false);
    settingsPopup.gameObject.SetActive(true);
    userPopup.gameObject.SetActive(false);
    statisticsPopup.gameObject.SetActive(false);
    gameModePopup.gameObject.SetActive(false);
  }

  public void OpenMain()
  {
    selectionPopup.gameObject.SetActive(false);
    mainPopup.gameObject.SetActive(true);
    settingsPopup.gameObject.SetActive(false);
    userPopup.gameObject.SetActive(false);
    statisticsPopup.gameObject.SetActive(false);
    gameModePopup.gameObject.SetActive(false);
  }

  public void OpenStatistics()
  {
    mainPopup.gameObject.SetActive(false);
    settingsPopup.gameObject.SetActive(false);
    userPopup.gameObject.SetActive(false);
    statisticsPopup.Open(menuSystem);
    statisticsPopup.gameObject.SetActive(true);
    gameModePopup.gameObject.SetActive(false);
  }

  public void OpenUser()
  {
    mainPopup.gameObject.SetActive(false);
    settingsPopup.gameObject.SetActive(false);
    userPopup.gameObject.SetActive(true);
    statisticsPopup.gameObject.SetActive(false);
    gameModePopup.gameObject.SetActive(false);
  }
}