using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class TestSetReleasePosition : MonoBehaviour
{
  [SerializeField] private GameObject flags_manager;
  [SerializeField] private GameObject angle_slider;
  [SerializeField] private GameObject height_slider;
  [SerializeField] private GameObject measure;
  [SerializeField] private GameObject fulcrum;
  [SerializeField] private GameObject tape_output;
  [SerializeField] private GameObject spiral;
  [SerializeField] private GameObject gravity_slider;

  void Update()
  {
    if (!flags_manager.GetComponent<TestFlags>().getFlag("swing") && !flags_manager.GetComponent<TestFlags>().getFlag("detach"))
    {
      measure.GetComponent<Transform>().position = new Vector2(fulcrum.GetComponent<Transform>().position.x + Mathf.Cos(angle_slider.GetComponent<Slider>().value * Mathf.Deg2Rad) * height_slider.GetComponent<Slider>().value, fulcrum.GetComponent<Transform>().position.y + Mathf.Sin(angle_slider.GetComponent<Slider>().value * Mathf.Deg2Rad) * height_slider.GetComponent<Slider>().value);
      // measureの右方向にfulcrumが来るようにmeasureを回転させる
      // fulcrumを原点としたmeasureの座標
      Vector2 measure_pos = -measure.GetComponent<Transform>().position + fulcrum.GetComponent<Transform>().position;
      // measure_posの角度、ただし-180~180の範囲で無限大を避ける
      float measure_angle = Mathf.Atan2(measure_pos.y, measure_pos.x) * Mathf.Rad2Deg;
      // measureの角度をmeasure_angleにする
      measure.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, measure_angle);
      // measureの座標をtape_outputの相対座標分だけずらす
      measure.GetComponent<Transform>().position -= (tape_output.GetComponent<Transform>().position - measure.GetComponent<Transform>().position);
      spiral.GetComponent<Transform>().position = measure.GetComponent<Transform>().position;
      spiral.GetComponent<Transform>().rotation = measure.GetComponent<Transform>().rotation;

    }
    measure.GetComponent<Rigidbody2D>().gravityScale = gravity_slider.GetComponent<Slider>().value;
    spiral.GetComponent<Rigidbody2D>().gravityScale = gravity_slider.GetComponent<Slider>().value;
  }


}
