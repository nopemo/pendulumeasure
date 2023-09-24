using UnityEngine;

public class TestTorque : MonoBehaviour
{
    private Rigidbody2D rb;

    // トルクをかける位置（重心からの相対座標）
    public Vector2 torquePosition = new Vector2(0f, 0f);

    // トルクの大きさ
    public float torqueMagnitude = 1f;

    [SerializeField] private GameObject flags_manager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularDrag = 0f;

    }

    void Update()
    {
        if (rb != null)
        {
            // 重心からの相対座標をワールド座標に変換
            Vector2 worldTorquePosition = rb.transform.TransformPoint(torquePosition);

            if (flags_manager.GetComponent<TestFlags>().getFlag("swing")){
            // 重心から指定位置にトルクをかける
                if (flags_manager.GetComponent<TestFlags>().getFlag("rewind_completed")){
                    Debug.Log("enable joint");
                    GetComponent<FixedJoint2D>().enabled = true;
                }
                else
                {
                //    rb.AddForceAtPosition(torqueMagnitude * Vector2.up, worldTorquePosition);
                // 代わりにスピードを一定にする
                rb.angularVelocity = torqueMagnitude;
                }
            }
        }
    }
}
