using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EvokeRanking : MonoBehaviour
{
  [SerializeField] private GameObject flags_manager;
  [SerializeField] private Transform measure_transform;
  [SerializeField] private GameObject process_canvas;
  bool is_ranking_evoke = false;
  bool is_ranking_shown = false;
  float scaled_time = 0f;
  void Start()
  {
    is_ranking_evoke = false;
    is_ranking_shown = false;
    process_canvas.GetComponent<Canvas>().enabled = false;
  }
  void Update()
  {
    if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "result" && !is_ranking_evoke)
    {
      is_ranking_evoke = true;
      scaled_time = 0;
    }
    else if (is_ranking_evoke)
    {
      scaled_time += Time.deltaTime;
      if (scaled_time > 0.5f && !is_ranking_shown)
      {
        process_canvas.GetComponent<Canvas>().enabled = true;
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking((int)measure_transform.position.x * 4);
        is_ranking_shown = true;
      }
    }
  }
}
