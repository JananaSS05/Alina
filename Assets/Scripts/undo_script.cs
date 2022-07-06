using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undo_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        board b = transform.parent.GetComponent<board>();
        if(b.GameOver == false && b.cnt >= 1)
        {
            int k = b.cnt;
            b.mat[b.xs[k], b.ys[k]] = 0;
            GameObject.Find((b.xs[k] * 3 + b.ys[k] + 1).ToString()).GetComponent<SpriteRenderer>().sprite = null;
            b.cnt--;
            if (b.player == "X")
                b.player = "O";
            else
                b.player = "X";
            b.time = 5;
        }
    }
}
