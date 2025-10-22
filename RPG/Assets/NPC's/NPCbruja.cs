using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCbruja : MonoBehaviour
{
    public GameObject txtDialogo;
    public static int numVisitas;

    public Sprite brujatxt1, brujatxt2, brujatxt3;

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
                txtDialogo.GetComponent<SpriteRenderer>().sprite = brujatxt1;
                break;
            case 1:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = brujatxt2;
                break;
            case 2:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = brujatxt3;
                break;
        }
    }

}

