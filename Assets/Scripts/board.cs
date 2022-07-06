using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class board : MonoBehaviour
{

    public string player = "X";
    public int cnt = 0;
    public bool GameOver = false;
    public int[,] mat = new int[4, 4];
    public int dx = 0;
    public int dy = 0;
    public int scoarx;
    public int scorey;
    public Sprite sprite1;
    public Sprite sprite2;
    public bool pus = false;
    public int[] xs = new int[11];
    public int[] ys = new int[11];
    public float time = 5;

    string mesaj;
    void Start()
    {
        Application.targetFrameRate = 40;
        Camera.main.backgroundColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            GameObject.Find("timer").GetComponent<TMP_Text>().text = time.ToString().Substring(0, 3);
        }
        else
        {
            int a = 1;
            int b = 1;
            while (mat[a, b] > 0)
            {
                a = Random.Range(0, 3);
                b = Random.Range(0, 3); 
            }
            cnt++;
            xs[cnt] = a;
            ys[cnt] = b;

            if (player == "X")
            {
                player = "O";
                mat[a, b] = 2;
                GameObject.Find((a * 3 + b + 1).ToString()).GetComponent<SpriteRenderer>().sprite = sprite2;
            }
            else
            {
                player = "X";
                GameObject.Find((a * 3 + b + 1).ToString()).GetComponent<SpriteRenderer>().sprite = sprite1;
                mat[a, b] = 1;
            }


            pus = false;
                
            time = 5;
        }

        

        if (player == "X" && pus == true)
        {
            Debug.Log("O");
            mat[dx, dy] = 2;
            xs[cnt] = dx;
            ys[cnt] = dy;
            pus = false;
        }
        else if(pus == true && player == "O")
        {
            Debug.Log("X");
            mat[dx, dy] = 1;
            xs[cnt] = dx;
            ys[cnt] = dy;
            pus = false;
        }

        for (int i = 0; i < 3; i++)
        {
            if (mat[i, 0] == mat[i, 1] && mat[i, 1] == mat[i, 2] && mat[i, 0] == mat[i, 2] && mat[i, 0] > 0 && GameOver == false)
            {
                if (player == "X")
                {
                    mesaj = "O a castigat";
                    scorey++;
                }
                else
                {
                    mesaj = "X a castigat";
                    scoarx++;
                }
                GameObject.Find("winner").GetComponent<TMP_Text>().text = mesaj;
                GameOver = true;
            }

            if (mat[0, i] == mat[1, i] && mat[1, i] == mat[2, i] && mat[0, i] == mat[2, i] && mat[0, i] > 0 && GameOver == false)
            {
                if (player == "X")
                {
                    mesaj = "O a castigat";
                    scorey++;
                }
                else
                {
                    mesaj = "X a castigat";
                    scoarx++;
                }
                GameObject.Find("winner").GetComponent<TMP_Text>().text = mesaj;
                GameOver = true;
            }
        }

        if (mat[0, 0] == mat[1, 1] && mat[1, 1] == mat[2, 2] && mat[0, 0] == mat[2, 2] && mat[0, 0] > 0 && GameOver == false)
        {
            if (player == "X")
            {
                mesaj = "O a castigat";
                scorey++;
            }
            else
            {
                mesaj = "X a castigat";
                scoarx++;
            }
            GameObject.Find("winner").GetComponent<TMP_Text>().text = mesaj;
            GameOver = true;
        }

        if (mat[0, 2] == mat[1, 1] && mat[1, 1] == mat[2, 0] && mat[0, 2] == mat[2, 0] && mat[0, 2] > 0 && GameOver == false)
        {
            if (player == "X")
            {
                mesaj = "O a castigat";
                scorey++;
            }
            else
            {
                mesaj = "X a castigat";
                scoarx++;
            }
            GameObject.Find("winner").GetComponent<TMP_Text>().text = mesaj;
            GameOver = true;
        }

        if(cnt == 9 && GameOver == false)
            GameObject.Find("winner").GetComponent<TMP_Text>().text = "este remiza";

    }
}
