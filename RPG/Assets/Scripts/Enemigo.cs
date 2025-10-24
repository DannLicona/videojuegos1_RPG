using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public static int vidaEnemigo = 1;
    private float frecAtaque = 2.5f, tiempoSigAtaque = 0, iniciaConteo;

    public Transform personaje;
    private NavMeshAgent agente;
    public Transform[] puntosRuta;
    private int indiceRuta = 0;
    private bool playerEnRango = false;
    private bool estabaSiguiendo = false;
    [SerializeField] private float distanciaDeteccionPlayer;
    private SpriteRenderer spriteEnemigo;
    private Transform mirarHacia;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        spriteEnemigo = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        vidaEnemigo = 1;
        agente.updateRotation = false;
        agente.updateUpAxis = false;

        GameObject jugador = GameObject.FindWithTag("Player");

        if (jugador != null)
        {
            personaje = jugador.transform;
        }
        else
        {
            Debug.LogWarning("No se encontro ningun jugador activo en la escena.");
        }

        if (puntosRuta != null && puntosRuta.Length > 0)
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            mirarHacia = puntosRuta[indiceRuta];
        }
    }

    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        float distancia = personaje != null ? Vector3.Distance(personaje.position, this.transform.position) : float.MaxValue;

        playerEnRango = distancia < distanciaDeteccionPlayer;

        if (!playerEnRango && estabaSiguiendo)
        {
            estabaSiguiendo = false;
            if (puntosRuta != null && puntosRuta.Length > 0)
                agente.SetDestination(puntosRuta[indiceRuta].position);
        }

        if (!playerEnRango && puntosRuta != null && puntosRuta.Length > 0)
        {
            float distPunto = Vector3.Distance(transform.position, puntosRuta[indiceRuta].position);
            if (distPunto < 0.3f)
            {
                indiceRuta++;
                if (indiceRuta >= puntosRuta.Length)
                    indiceRuta = 0;
                agente.SetDestination(puntosRuta[indiceRuta].position);
                mirarHacia = puntosRuta[indiceRuta];
            }
        }

        if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
        }
        else
        {
            tiempoSigAtaque = 0;
            VidasPlayer.puedePerderVida = 1;
            SigueAlPlayer(playerEnRango);
            RotaEnemigo();
        }
    }

    private void SigueAlPlayer(bool playerEnRango)
    {
        if (playerEnRango && personaje != null)
        {
            agente.SetDestination(personaje.position);
            mirarHacia = personaje;
            estabaSiguiendo = true;
        }
        else
        {
            if (puntosRuta != null && puntosRuta.Length > 0)
            {
                mirarHacia = puntosRuta[indiceRuta];
            }
        }
    }

    private void RotaEnemigo()
    {
        if (mirarHacia == null) return;

        if (this.transform.position.x > mirarHacia.position.x)
        {
            spriteEnemigo.flipX = true;
        }
        else
        {
            spriteEnemigo.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;
            obj.transform.GetComponentInChildren<VidasPlayer>().TomarDaño(1);
        }
    }

    public void TomarDaño(int daño)
    {
        vidaEnemigo -= daño;
        if (vidaEnemigo <= 0)
        {
            Destroy(gameObject);
        }
    }
}

