using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CADCanela : MonoBehaviour
{
    [SerializeField] private GameObject proyectil;
    public float tiempoSigAtaque;
    public float tiempoEntreAtaques;
    public Transform puntoEmision;
    private Animator anim;

    public static int dirDisparo = 0;
    public static bool disparando = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (tiempoSigAtaque < 0.05f && tiempoEntreAtaques > 0)
        {
            disparando = false;
        }
        if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2") && tiempoSigAtaque <= 0)
        {
            disparando = true;
            activaCapa("Ataque");
            Dispara();
            tiempoSigAtaque = tiempoEntreAtaques;
        }
    }

    private void Dispara()
    {
        if (MovPlayerCanela.dirAtaque == 1)
        {
            anim.SetTrigger("disparaFront");
        }
        else if (MovPlayerCanela.dirAtaque == 2)
        {
            anim.SetTrigger("disparaBack");
        }
        else if (MovPlayerCanela.dirAtaque == 3)
        {
            anim.SetTrigger("disparaLeft");
        }
        else if (MovPlayerCanela.dirAtaque == 4)
        {
            anim.SetTrigger("disparaRight");
        }
    }

    private void EmiteProyectil()
    {
        dirDisparo = MovPlayerCanela.dirAtaque;
        Instantiate(proyectil, puntoEmision.position, transform.rotation);
    }

    private void activaCapa(string nombre)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0);
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
}