using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OneButton : MonoBehaviour
{
    [SerializeField] private GameObject flags_manager;
    [SerializeField] private GameObject start_swing_button;
    [SerializeField] private GameObject detach_fulcrum_button;
    [SerializeField] private GameObject height_slider;
    [SerializeField] private GameObject angle_slider;
    [SerializeField] private GameObject reset_button;
    [SerializeField] private GameObject window_title;
    [SerializeField] private GameObject window_description;
    [SerializeField] private Transform measure;
    [SerializeField] private GameObject process_text_angle;
    [SerializeField] private GameObject process_text_height;
    [SerializeField] private GameObject process_text_swing;

    private float max_angle = 360f;
    private float min_angle = 0f;
    private float max_height = 125f;
    private float min_height = 0f;

    float scaled_time = 0f;
    float determined_angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        flags_manager.GetComponent<TestFlags>().setFlagString("game_section", "waiting");
        max_angle = angle_slider.GetComponent<Slider>().maxValue;
        min_angle = angle_slider.GetComponent<Slider>().minValue;
        max_height = height_slider.GetComponent<Slider>().maxValue;
        min_height = height_slider.GetComponent<Slider>().minValue;
    }
    void Update()
    {
        if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "angle")
        {
            scaled_time += Time.deltaTime;
            // 二次関数っぽく動かす
            determined_angle = (max_angle - min_angle) / 2 * (1 - Mathf.Sin(-Mathf.PI * scaled_time / 1.5f)) + min_angle;
            angle_slider.GetComponent<Slider>().value = determined_angle;
            window_description.GetComponent<Text>().text = "角度:" + ((int)(1.001 * (270 - determined_angle))).ToString("D3") + "°";
            process_text_angle.GetComponent<Text>().text = ((int)(1.001 * (270 - determined_angle))).ToString() + "°";
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "height")
        {
            scaled_time += Time.deltaTime;
            // 二次関数っぽく動かす
            height_slider.GetComponent<Slider>().value = ((max_height - min_height) / 2 * (1 - Mathf.Cos(Mathf.PI * scaled_time / 1.5f)) + min_height);
            window_description.GetComponent<Text>().text = "長さ:" + ((int)(4.0001 * height_slider.GetComponent<Slider>().value)).ToString("D3") + "cm";
            process_text_height.GetComponent<Text>().text = ((int)(4.0001 * height_slider.GetComponent<Slider>().value)).ToString("D3") + "cm";
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "swing")
        {
            scaled_time += Time.deltaTime;
            window_description.GetComponent<Text>().text = "時間:" + Math.Round(scaled_time, 1).ToString() + "sec";
            process_text_swing.GetComponent<Text>().text = Math.Round(scaled_time, 1).ToString() + "sec";
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "detach" || flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "detach_speedup")
        {
            window_description.GetComponent<Text>().text = "距離:" + ((int)(measure.GetComponent<Transform>().position.x * 4)).ToString() + "cm";
        }
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "waiting")
        {
            flags_manager.GetComponent<TestFlags>().setFlagString("game_section", "angle");
            window_title.GetComponent<Text>().text = "タップして角度決定";
            scaled_time = 0f;
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "angle")
        {
            flags_manager.GetComponent<TestFlags>().setFlagString("game_section", "height");
            window_title.GetComponent<Text>().text = "タップして長さ決定";
            scaled_time = 0f;
            if (determined_angle > 185 && determined_angle <= 270)
            {
                max_height = Mathf.Min(max_height, 45f / (Mathf.Cos((270 - determined_angle) * Mathf.PI / 180f)) - 10f);
            }
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "height")
        {
            flags_manager.GetComponent<TestFlags>().setFlagString("game_section", "swing");
            window_title.GetComponent<Text>().text = "タップしてジャンプ";
            start_swing_button.GetComponent<TestDebugButton>().OnClick();
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "swing")
        {
            flags_manager.GetComponent<TestFlags>().setFlagString("game_section", "detach");
            window_title.GetComponent<Text>().text = "タップして倍速再生";
            scaled_time = 0f;
            // detach_fulcrum_buttonのボタンを押したことにする。
            detach_fulcrum_button.GetComponent<TestDebugButton>().OnClick();
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "detach")
        {
            flags_manager.GetComponent<TestFlags>().setFlagString("game_section", "detach_speedup");
            window_title.GetComponent<Text>().text = "タップして通常再生";
            Time.timeScale = 3f;
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "detach_speedup")
        {
            flags_manager.GetComponent<TestFlags>().setFlagString("game_section", "detach");
            window_title.GetComponent<Text>().text = "タップして倍速再生";
            Time.timeScale = 1f;
        }
        else if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "result")
        {
            reset_button.GetComponent<Retry>().OnClick();
        }
    }
}
