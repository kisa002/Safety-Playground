using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField]
    private float initY;
    private Vector3 prevPos;

    private new RectTransform transform;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        StartCoroutine(Scroll());
    }
	
    public void ToOrigin()
    {
        transform.anchoredPosition = new Vector2(transform.anchoredPosition.x, initY);
    }

    private IEnumerator Scroll()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                prevPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 curPos = Input.mousePosition;
                float gap = prevPos.y - curPos.y;        
                transform.anchoredPosition += new Vector2(0, gap);
                if(transform.anchoredPosition.y > initY)
                {
                    transform.anchoredPosition = new Vector2(transform.anchoredPosition.x, initY);
                }
                
                prevPos = curPos;
            }            

            yield return null;
        }
        
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    public void Start()
    {
        StartCoroutine(Scroll());
    }
}
