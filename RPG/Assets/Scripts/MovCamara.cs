using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "portal1Ex1")
        {
            Vector3 posicioncamara = new Vector3(1, 1, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(1, 1, 0);
            this.transform.position = posicionPlayer;
        }

        if (obj.gameObject.tag == "portal2Ex1")
        {
            Vector3 posicioncamara = new Vector3(30, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(18.65f, 0.5f, 0);
            this.transform.position = posicionPlayer;
        }

        if (obj.gameObject.tag == "portal3Ex1")
        {
            Vector3 posicioncamara = new Vector3(1, 1, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(1, 1, 0);
            this.transform.position = posicionPlayer;
        }

        if (obj.gameObject.tag == "portal4Ex1")
        {
            Vector3 posicioncamara = new Vector3(-30, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-18, 0.5f, 0);
            this.transform.position = posicionPlayer;
        }

        if (obj.gameObject.tag == "portal4A200")
        {
            Vector3 posicioncamara = new Vector3(0, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(12.5f, 0.5f, 0);
            this.transform.position = posicionPlayer;
        } 

         if (obj.gameObject.tag == "portal2CTA")
        {
            Vector3 posicioncamara = new Vector3(0, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-11, 0.5f, 0);
            this.transform.position = posicionPlayer;
        } 
    }
}
