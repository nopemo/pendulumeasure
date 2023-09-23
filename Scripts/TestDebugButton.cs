using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebugButton : MonoBehaviour
{
  [SerializeField] private GameObject flags_manager;
  [SerializeField] private string flag_name;
  [SerializeField] private GameObject measure;
  [SerializeField] private GameObject spiral;
  [SerializeField] private GameObject fulcrum;

  public void OnClick()
  {
    bool current_flag = flags_manager.GetComponent<TestFlags>().getFlag(flag_name);
    flags_manager.GetComponent<TestFlags>().setFlag(flag_name, !current_flag);
    Debug.Log("Button clicked! Flag " + flag_name + " is now " + !current_flag);
    if (flag_name == "reset")
    {
      // refresh the scene
      flags_manager.GetComponent<TestFlags>().setFlag("reset", false);
      UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    if (flag_name == "swing")
    {
      // start the swing
      if (!current_flag)
      {
        // Activate the measure object
        measure.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        spiral.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

      }
    }
    if (flag_name == "detach")
    {
      // detach the fulcrum
      if (!current_flag)
      {
        // Activate the measure object
        fulcrum.GetComponent<DistanceJoint2D>().enabled = false;
        // fulcrum.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
      }
    }
  }
}
