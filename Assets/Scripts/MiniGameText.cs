using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameText : MonoBehaviour
{
    Text text;
    bool wait = false;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    void Update ()
    {
        if (!wait)
        {
            text.fontSize = text.fontSize - 1;
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.05f);

            transform.Translate(Vector2.up * 1f * Time.deltaTime);
            wait = true;
        }
        else
            wait = false;

        if (text.fontSize <= 0)
            Destroy(this);
	}
}
