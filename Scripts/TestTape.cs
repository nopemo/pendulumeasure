using UnityEngine;

public class TestTape : MonoBehaviour
{
    public float minPendulumLength = 1.0f; // 糸の最小長さ
    public float decreaseRate = 0.1f; // 糸の短くなる速度

    DistanceJoint2D pendulum_length;

    void Start()
    {
        pendulum_length=GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
      if(pendulum_length.distance > minPendulumLength)
      {
        pendulum_length.distance -= decreaseRate * Time.deltaTime;
      }
    }
}
