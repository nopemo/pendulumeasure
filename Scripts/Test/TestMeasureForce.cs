using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMeasureForce : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float power;
    [SerializeField] private GameObject fulcrum;
    [SerializeField] private GameObject force_point;
    [SerializeField] private GameObject flags_manager;
    [SerializeField] private GameObject power_slider;
    private Vector2 fulcrum_pos;
    private Vector3 force_pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fulcrum_pos = fulcrum.GetComponent<Transform>().position;
        force_pos = force_point.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        // rb.AddForce((fulcrum_pos - (Vector2)transform.position).normalized * power);
        // Debug.DrawRay(transform.position, transform.right * power, Color.red);
        if (flags_manager.GetComponent<TestFlags>().getFlag("swing"))
        {
            if (flags_manager.GetComponent<TestFlags>().getFlag("detach"))
            {
                Debug.Log("zero power");
            }
            else
            {
            force_pos = force_point.GetComponent<Transform>().position;
            rb.AddForceAtPosition((fulcrum_pos - (Vector2)force_pos).normalized * power * power_slider.GetComponent<Slider>().value, force_pos);
            Debug.DrawRay(force_pos, (fulcrum_pos - (Vector2)force_pos).normalized * power * power_slider.GetComponent<Slider>().value, Color.red);
            }
        }
    }
}
