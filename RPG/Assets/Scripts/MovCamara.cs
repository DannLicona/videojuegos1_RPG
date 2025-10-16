using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "portal1")
        {
            Vector3 posicioncamara = new Vector3(29.8f, -0.3f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(19, 0, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal2")
        {
            Vector3 posicioncamara = new Vector3(0.19f, -19.79f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-0.45f, -14, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal3")
        {
            Vector3 posicioncamara = new Vector3(-30.18f, -0.39f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-19, 0, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal4")
        {
            Vector3 posicioncamara = new Vector3(0f, -0.36f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(11.23f, 0.37f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal5")
        {
            Vector3 posicioncamara = new Vector3(0, -0.36f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(0.45f, -6, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal6")
        {
            Vector3 posicioncamara = new Vector3(0, -0.36f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-11.17f, 0.37f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal7")
        {
            Vector3 posicioncamara = new Vector3(29.84f, -19.79f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(18.82f, -16.37f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal8")
        {
            Vector3 posicioncamara = new Vector3(29.84f, -19.79f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(18.82f, -22.89f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal9")
        {
            Vector3 posicioncamara = new Vector3(0.19f, -19.79f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(11.24f, -16.37f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal10")
        {
            Vector3 posicioncamara = new Vector3(0.19f, -19.79f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(11.24f, -22.89f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal11")
        {
            Vector3 posicioncamara = new Vector3(59.9f, -19.79f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(48.96f, -19.9f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portal12")
        {
            Vector3 posicioncamara = new Vector3(29.84f, -19.79f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(41.25f, -19.9f, 0);
            this.transform.position = posicionPlayer;
        }


        //Portales salones
        if (obj.gameObject.tag == "portals1")
        {
            Vector3 posicioncamara = new Vector3(59.98f, 29.82f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(61.03f, 24.17f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portals2")
        {
            Vector3 posicioncamara = new Vector3(90, 29.82f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(91.01f, 24.17f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portals3")
        {
            Vector3 posicioncamara = new Vector3(120, 29.82f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(121.08f, 24.17f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portals4")
        {
            Vector3 posicioncamara = new Vector3(150, 29.82f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(150.99f, 24.17f, 0);
            this.transform.position = posicionPlayer;
        }

        //Portales salones de regreso
        if (obj.gameObject.tag == "portalsr1")
        {
            Vector3 posicioncamara = new Vector3(29.8f, -0.3f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(21.44f, 2, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portalsr2")
        {
            Vector3 posicioncamara = new Vector3(29.8f, -0.3f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(26.46f, 2, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portalsr3")
        {
            Vector3 posicioncamara = new Vector3(29.8f, -0.3f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(31.45f, 2, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "portalsr4")
        {
            Vector3 posicioncamara = new Vector3(29.8f, -0.3f, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(36.47f, 2, 0);
            this.transform.position = posicionPlayer;
        }
    }
}
