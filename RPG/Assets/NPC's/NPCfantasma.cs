using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCfantasma : MonoBehaviour
{
    public GameObject txtDialogo;
    public static int numVisitas;

    public Sprite fantasmatxt1,fantasmatxt2;

    void Start()
    {
        txtDialogo.SetActive(false);
        numVisitas = 0;
         
    }

    private void OnTriggerEnter2D(Collider2D obj){
        txtDialogo.SetActive(true);
        EscribeDialogo();
        numVisitas++; 
    }

    private void EscribeDialogo(){
        switch (numVisitas)
        {
            case 0:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 1:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 2:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 3:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 4:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 5:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 6:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 7:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 8:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt2;
                break;
            case 9:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
            case 10:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt2;
                break;
            case 11:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = fantasmatxt1;
                break;
        }
    }

}