using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestBG : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject text2;
    private int length;
    [SerializeField] private GameObject wall;
    // Start is called before the first frame update
    public void ChangeColorUsingOddEven(Vector2 pos)
    {
        if ((pos.x + pos.y) % 2 == 1)
        {
            // 016A70 is the color of the wall
            wall.GetComponent<SpriteRenderer>().color = new Color(0f, 0.4f, 0.439f);
        }
        else
        {
            // 015670 is the color of the wall
            wall.GetComponent<SpriteRenderer>().color = new Color(0f, 0.337f, 0.439f);
        }
        if (text != null)
        {
            length = (int)pos.x * 400;
            text.GetComponent<TextMeshProUGUI>().text = length.ToString() + "cm";
        }
        if (text2 != null)
        {
            length = (int)pos.x * 400 + 200;
            text2.GetComponent<TextMeshProUGUI>().text = length.ToString() + "cm";
        }
    }
}
