using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCementerio : MonoBehaviour
{
    public GameObject txtDialogo;
    public static int numVisitas;

    public Sprite cemetxt1;

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
                txtDialogo.GetComponent<SpriteRenderer>().sprite = cemetxt1;
                break;
            case 1:
                  txtDialogo.GetComponent<SpriteRenderer>().sprite = cemetxt1;
                break;
        }
    }

}

