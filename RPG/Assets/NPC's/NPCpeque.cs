using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCpeque : MonoBehaviour
{
    public GameObject txtDialogo;
    public static int numVisitas;

    public Sprite pequetxt1, pequetxt2, pequetxt3;

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
                txtDialogo.GetComponent<SpriteRenderer>().sprite = pequetxt1;
                break;
            case 1:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = pequetxt2;
                break;
            case 2:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = pequetxt3;
                break;
        }
    }

}

