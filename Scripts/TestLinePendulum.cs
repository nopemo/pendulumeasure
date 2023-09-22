using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLinePendulum : MonoBehaviour
{
    // get Object1's transform
    [SerializeField] private GameObject Object1;
    // get Object2's transform
    [SerializeField] private GameObject Object2;

    // import prefab of line renderer
    [SerializeField] private GameObject linePrefab;
    GameObject line;
    LineRenderer lineRenderer;

    [SerializeField] private GameObject flags_manager;
    [SerializeField] private float speed;
    private float length;
    // Start is called before the first frame update
    void Start()
    {
        // instantiate line renderer
        line = Instantiate(linePrefab);
        // get line renderer component
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, Object1.GetComponent<Transform>().position);
        lineRenderer.SetPosition(1, Object2.GetComponent<Transform>().position);
        length = Vector2.Distance(Object1.GetComponent<Transform>().position, Object2.GetComponent<Transform>().position);
    }

    void Update()
    {
        if (lineRenderer != null)
        {
            if (flags_manager.GetComponent<TestFlags>().getFlag("detach"))
            {
                if (length > 0.5f)
                {
                    lineRenderer.SetPosition(1, Object2.GetComponent<Transform>().position);
                    // 右方向にlengthの長さの線を描画
                    Vector3 new_pos = Object2.GetComponent<Transform>().right * length;
                    lineRenderer.SetPosition(0, new_pos + Object2.GetComponent<Transform>().position);
                    length -= Time.deltaTime * speed;
                }
                else
                {
                    // delete line renderer
                    Destroy(line);
                    flags_manager.GetComponent<TestFlags>().setFlag("rewind_completed", true);
                    Debug.Log("rewind completed");
                }
            }
            else
            {
                lineRenderer.SetPosition(0, Object1.GetComponent<Transform>().position);
                lineRenderer.SetPosition(1, Object2.GetComponent<Transform>().position);
                length = Vector2.Distance(Object1.GetComponent<Transform>().position, Object2.GetComponent<Transform>().position);
                if (length < 0.5f)
                {
                    Destroy(line);
                    flags_manager.GetComponent<TestFlags>().setFlag("rewind_completed", true);
                    Debug.Log("rewind completed");
                }
            }

        }
    }
}
