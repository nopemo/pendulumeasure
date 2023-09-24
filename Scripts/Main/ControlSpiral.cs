using UnityEngine;

public class ControlSpiral : MonoBehaviour
{
  private Rigidbody2D rb;
  [SerializeField] private GameObject flags_manager;
  [SerializeField] private GameObject measure;
  [SerializeField] private GameObject fulcrum;
  [SerializeField] private float radius = 2.48f;
  [SerializeField] private float momentum_of_inertia_spiral = 100f;
  [SerializeField] private float momentum_of_inertia_measure = 1f;
  private float saved_angle_z = 0f;
  private float saved_angular_velocity = 0f;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    rb.angularDrag = 0f;
  }
  void Update()
  {
    rb.GetComponent<Transform>().position = measure.GetComponent<Transform>().position;
    if (flags_manager.GetComponent<TestFlags>().getFlag("swing"))
    {
      if (flags_manager.GetComponent<TestFlags>().getFlag("rewind_completed"))
      {
        if (!flags_manager.GetComponent<TestFlags>().getFlag("recoil"))
        {
          saved_angular_velocity = (momentum_of_inertia_spiral * rb.angularVelocity / momentum_of_inertia_measure) + measure.GetComponent<Rigidbody2D>().angularVelocity;
          measure.GetComponent<Rigidbody2D>().angularVelocity = saved_angular_velocity;

          saved_angle_z = GetComponent<Transform>().rotation.eulerAngles.z - measure.GetComponent<Transform>().rotation.eulerAngles.z;
          flags_manager.GetComponent<TestFlags>().setFlag("recoil", true);
          Debug.Log("enable joint");
        }
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, saved_angle_z + measure.GetComponent<Transform>().rotation.eulerAngles.z);
      }
      else
      {
        float angular_velocity = 30f * Vector2.Dot(measure.GetComponent<Transform>().right, measure.GetComponent<Rigidbody2D>().velocity) / radius;
        rb.angularVelocity = measure.GetComponent<Rigidbody2D>().angularVelocity - angular_velocity;
      }
    }
  }
}
