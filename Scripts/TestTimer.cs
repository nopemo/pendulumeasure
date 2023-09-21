using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTimer : MonoBehaviour
{
  private float past_time;
  [SerializeField] private TextMeshProUGUI text;

  public void Start()
  {
    past_time = 0f;
    text.text = "0.00s";
  }

  public void Update()
  {
    past_time += Time.deltaTime;
    text.text = past_time.ToString("F2") + "s";
  }
}
