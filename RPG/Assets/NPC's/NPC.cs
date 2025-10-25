using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject txtDialogo;
    public static int numVisitas;

    public Sprite proftxt1, proftxt2, proftxt3;

    void Start()
    {
        txtDialogo.SetActive(false);
        numVisitas = 0;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            txtDialogo.SetActive(true);
            EscribeDialogo();
            numVisitas++;
        }
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
            case 2:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = proftxt3;
                break;
        }
    }
}
