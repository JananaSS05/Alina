using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class board_tile : MonoBehaviour
{

    public Sprite sprite1; 
    public Sprite sprite2;
    public int x;
    public int y;
    private SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnMouseDown()
    {
        board b = transform.parent.GetComponent<board>();
        if(b.GameOver == true)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    b.mat[i, j] = 0;
            }

            for (int i = 1; i < 10; i++)
            {
                b.xs[i] = b.ys[i] = 0;
                GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().sprite = null;
            }

            b.GameOver = false;
            b.cnt = 0;
            b.time = 5;
            GameObject.Find("score_box").GetComponent<TMP_Text>().text = b.scoarx.ToString() + " : " + b.scorey.ToString();
            GameObject.Find("winner").GetComponent<TMP_Text>().text = null;
        }
        if (spriteRenderer.sprite != sprite1 && spriteRenderer.sprite != sprite2 && b.GameOver == false)
        {
            if (b.player == "X")
            {
                spriteRenderer.sprite = sprite1;
                b.player = "O";
                b.dx = x;
                b.dy = y;
                b.pus = true;
            } 
            else
            {
                b.pus = true;
                spriteRenderer.sprite = sprite2;
                b.player = "X";
                b.dx = x;
                b.dy = y;
            }
            b.cnt++;
            b.time = 5;
        }
    }
}
