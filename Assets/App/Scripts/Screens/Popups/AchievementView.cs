using UnityEngine;
using UnityEngine.UI;

public class AchievementView : MonoBehaviour
{
  [SerializeField] private Image icon;
  [SerializeField] private Sprite passIcon;
  [SerializeField] private Sprite failedIcon;

  public void SetState(bool state)
  {
    icon.sprite = state ? passIcon : failedIcon;
  }
}