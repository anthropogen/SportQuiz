using System;
using System.Collections.Generic;
using Bootstrapper.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class AnswerBtn : MonoBehaviour
{
  [SerializeField] private Button btn;
  [SerializeField] private TMP_Text txt;
  private string answer;

  public void Init(Action<string> onPressed)
  {
    btn.onClick.AddListener(() => onPressed?.Invoke(answer));
  }

  public void SetAnswer(string answer)
  {
    this.answer = answer;
    txt.text = answer;
  }

  public void SetInteractable(bool state)
    => btn.interactable = state;
}