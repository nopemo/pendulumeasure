using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMeasureForce : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float power;
    [SerializeField] private GameObject fulcrum;
    private Vector2 fulcrum_pos;
    private Transform thisTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fulcrum_pos = fulcrum.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        // // objectの向きに合わせて力を加える
        // rb.AddForce(transform.right * power);
        // fulcrumの位置に向けて力を加える
        rb.AddForce((fulcrum_pos - (Vector2)transform.position).normalized * power);
        // 力の大きさをデバッグするために線を引く
        Debug.DrawRay(transform.position, transform.right * power, Color.red);
    }
}
