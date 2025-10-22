using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject txtDialogo;
    public static int numVisitas;

    public Sprite proftxt1, proftxt2;

    void Start()
    {
        txtDialogo.SetActive(false);
        numVisitas = 0;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        txtDialogo.SetActive(true);
        EscribeDialogo();
        numVisitas++;
    }

    private void EscribeDialogo()
    {
        switch (numVisitas)
        {
            case 0:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = proftxt1;
                break;
            case 1:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = proftxt2;
                break;
        }
    }
}
