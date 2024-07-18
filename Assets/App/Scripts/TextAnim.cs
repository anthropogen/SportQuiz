using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class TextAnim : MonoBehaviour
{
  [SerializeField] private Canvas canvas;
  [SerializeField] private RectTransform[] transforms;
  private float timeMin = 10f;
  private float timeMax = 15f;

  private void Awake()
  {
    var canvasRect = canvas.GetComponent<RectTransform>();
    var left = -canvasRect.rect.width / 2;
    var right = canvasRect.rect.width / 2;


    foreach (var t in transforms)
    {
      var startValue = left - t.rect.width / 2f;
      var endValue = right + t.rect.width / 2f;
      var endPos = new Vector3(endValue, t.localPosition.y, 0);

      var time = Random.Range(timeMin, timeMax);
      var dist = Mathf.Abs(startValue - endValue);
      var speed = dist / time;
      var path = Mathf.Abs(endValue - t.localPosition.x);
      var tC = path / speed;
      t.DOLocalMove(endPos, tC).OnComplete(() =>
        {
          t.localPosition = new Vector3(startValue, t.localPosition.y, 0);
          t.DOLocalMove(endPos, time)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
        })
        .SetEase(Ease.Linear);
    }
  }
}