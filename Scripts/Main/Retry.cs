using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
  [SerializeField] private GameObject reset_button;

  public void OnClick()
  {
    reset_button.GetComponent<TestDebugButton>().OnClick();
  }
}
