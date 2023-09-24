using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLinePendulum : MonoBehaviour
{
    // get fulcrum's transform
    [SerializeField] private GameObject fulcrum;
    // get tape_out's transform
    [SerializeField] private GameObject tape_out;
    [SerializeField] private GameObject measure;

    // import prefab of line renderer
    [SerializeField] private GameObject linePrefab;
    GameObject line;
    LineRenderer lineRenderer;

    [SerializeField] private GameObject flags_manager;
    [SerializeField] private float speed;
    private float length;

    [SerializeField] private float l_length = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        // instantiate line renderer
        line = Instantiate(linePrefab);
        // get line renderer component
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0, tape_out.GetComponent<Transform>().position);
        lineRenderer.SetPosition(1, fulcrum.GetComponent<Transform>().position);
        lineRenderer.SetPosition(2, -tape_out.GetComponent<Transform>().up * l_length + fulcrum.GetComponent<Transform>().position);
        length = Vector2.Distance(fulcrum.GetComponent<Transform>().position, tape_out.GetComponent<Transform>().position);
    }

    void Update()
    {
        if (lineRenderer != null)
        {
            if (flags_manager.GetComponent<TestFlags>().getFlag("detach"))
            {
                if (length > 0.5f)
                {
                    lineRenderer.positionCount = 3;
                    lineRenderer.SetPosition(0, tape_out.GetComponent<Transform>().position);
                    // 右方向にlengthの長さの線を描画
                    Vector3 new_pos = tape_out.GetComponent<Transform>().right * length;
                    lineRenderer.SetPosition(1, new_pos + tape_out.GetComponent<Transform>().position);
                    lineRenderer.SetPosition(2, -tape_out.GetComponent<Transform>().up * l_length + new_pos + tape_out.GetComponent<Transform>().position);
                    length -= Time.deltaTime * speed;
                }
                else
                {
                    lineRenderer.positionCount = 2;
                    lineRenderer.SetPosition(0, tape_out.GetComponent<Transform>().position);
                    lineRenderer.SetPosition(1, -tape_out.GetComponent<Transform>().up * l_length + tape_out.GetComponent<Transform>().position);
                    lineRenderer.positionCount = 2;
                    flags_manager.GetComponent<TestFlags>().setFlag("rewind_completed", true);
                    Debug.Log("rewind completed");
                }
            }
            else
            {
                lineRenderer.positionCount = 3;
                lineRenderer.SetPosition(0, tape_out.GetComponent<Transform>().position);
                lineRenderer.SetPosition(1, fulcrum.GetComponent<Transform>().position);
                lineRenderer.SetPosition(2, -tape_out.GetComponent<Transform>().up * l_length + fulcrum.GetComponent<Transform>().position);
                length = Vector2.Distance(fulcrum.GetComponent<Transform>().position, tape_out.GetComponent<Transform>().position);
                speed = Vector2.Distance(fulcrum.GetComponent<Rigidbody2D>().velocity, measure.GetComponent<Rigidbody2D>().velocity);
            }

        }
    }
}
