using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public bool isCheck = false;
    public float speed = 5f;

    int dir = -1;

    public void Init()
    {
        transform.localPosition = new Vector2(-425, transform.localPosition.y);
        dir = -1;
        speed = Random.Range(2, 9);
    }

    void Update()
    {
        if (transform.localPosition.x >= 425)
            dir = -1;
        else if (transform.localPosition.x <= -425)
            dir = 1;

        transform.Translate(Vector2.right * speed * dir * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCheck = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCheck = false;
    }
}
