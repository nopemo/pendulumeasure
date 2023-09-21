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
    // Start is called before the first frame update
    void Start()
    {
        // instantiate line renderer
        line = Instantiate(linePrefab);
        // get line renderer component
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, Object1.GetComponent<Transform>().position);
        lineRenderer.SetPosition(1, Object2.GetComponent<Transform>().position);
    }

    void Update()
    {
        lineRenderer.SetPosition(0, Object1.GetComponent<Transform>().position);
        lineRenderer.SetPosition(1, Object2.GetComponent<Transform>().position);
    }
}
