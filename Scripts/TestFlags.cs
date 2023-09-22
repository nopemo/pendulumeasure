using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlags : MonoBehaviour
{
  private Dictionary<string, bool> flags = new Dictionary<string, bool>();

  public void setFlag(string flag, bool value)
  {
    flags[flag] = value;
    Debug.Log("Flag " + flag + " is now " + value);
  }
  public bool getFlag(string flag)
  {
    if (!flags.ContainsKey(flag))
    {
      flags[flag] = false;
    }
    return flags[flag];
  }
}
