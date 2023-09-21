using UnityEngine;

public class TestTorque : MonoBehaviour
{
    private Rigidbody2D rb;

    // トルクをかける位置（重心からの相対座標）
    public Vector2 torquePosition = new Vector2(0f, 0f);

    // トルクの大きさ
    public float torqueMagnitude = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 摩擦を無視する
        rb.angularDrag = 0f;
        // 軽く角速度を与える
        rb.angularVelocity = 1f;
    }

    void Update()
    {
        if (rb != null)
        {
            // 重心からの相対座標をワールド座標に変換
            Vector2 worldTorquePosition = rb.transform.TransformPoint(torquePosition);

            // トルクをかける
            rb.AddTorque(torqueMagnitude);

            // 重心から指定位置にトルクをかける
            rb.AddForceAtPosition(torqueMagnitude * Vector2.up, worldTorquePosition);
        }
    }
}
