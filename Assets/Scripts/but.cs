using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class but : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        board b = transform.parent.GetComponent<board>();
        b.scoarx = 0;
        b.scorey = 0;
       for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                b.mat[i, j] = 0;
        }

        for (int i = 1; i < 10; i++)
        {
            GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().sprite = null;
        }
        b.time = 5;


    }
}
