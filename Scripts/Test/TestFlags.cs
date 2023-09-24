using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlags : MonoBehaviour
{
  private Dictionary<string, bool> flags = new Dictionary<string, bool>();
  private Dictionary<string, string> flags_string = new Dictionary<string, string>();

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

  public void setFlagString(string flag, string value)
  {
    flags_string[flag] = value;
    Debug.Log("Flag " + flag + " is now " + value);
  }
  public string getFlagString(string flag)
  {
    if (!flags_string.ContainsKey(flag))
    {
      flags_string[flag] = "";
    }
    return flags_string[flag];
  }
}
