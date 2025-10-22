using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCrubio : MonoBehaviour
{
    public GameObject txtDialogo;
    public static int numVisitas;

    public Sprite rubiotxt1, rubiotxt2;

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
                txtDialogo.GetComponent<SpriteRenderer>().sprite = rubiotxt1;
                break;
            case 1:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = rubiotxt2;
                break;
        }
    }

}


