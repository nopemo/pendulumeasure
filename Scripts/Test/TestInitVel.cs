using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInitVel : MonoBehaviour
{
    [SerializeField] private float init_vel;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 摩擦を無視する
        rb.angularDrag = 0f;
        // 軽く横方向に速度を与える
        rb.velocity = new Vector2(init_vel, 0f);
    }
}
