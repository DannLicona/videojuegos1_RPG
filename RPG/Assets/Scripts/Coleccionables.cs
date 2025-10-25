using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    private GameObject player;
    public static string objAColeccionar;
    private Inventario inventario;
    void Start()
    {
        player = GameObject.Find("Player");
        objAColeccionar = "";
        inventario = FindObjectOfType<Inventario>();
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "vida")
        {
            Debug.Log("Aumenta Vida");
            VidasPlayer.vida++;
            player.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
            Destroy(obj.gameObject);
        }
        if (obj.tag == "mana")
        {
            //Aumentar mana
            Debug.Log("mana");
            Destroy(obj.gameObject);
        }
        if (obj.tag == "c1")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c2")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c3")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c4")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c5")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c6")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c7")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c8")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c9")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c10")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c11")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c12")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c13")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c14")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c15")
        {
            AplicaCambios(obj);
        }
        if (obj.tag == "c16")
        {
            AplicaCambios(obj);
        }
    }

    private void AplicaCambios(Collider2D obj)
    {
        objAColeccionar = obj.tag;
        inventario.EscribeEnArreglo();
        Destroy(obj.gameObject);
    }
}
