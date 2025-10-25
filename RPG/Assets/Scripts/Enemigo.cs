using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [Header("Configuración de enemigo")]
    [SerializeField] private int vidaInicial = 1;
    [SerializeField] private float velocidad = 3.5f;
    [SerializeField] private int dañoAlPlayer = 1;

    private int vidaEnemigo;
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
    private Animator anim;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        spriteEnemigo = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        vidaEnemigo = vidaInicial;
        agente.updateRotation = false;
        agente.updateUpAxis = false;
        agente.speed = velocidad;

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

        // Si está lejos o ya no atacando → volver a caminar
        if (!playerEnRango && anim != null && !anim.GetCurrentAnimatorStateInfo(0).IsName("ArdillaAtaque"))
        {
            anim.SetBool("Caminando", true);
        }

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
            spriteEnemigo.flipX = false;
        }
        else
        {
            spriteEnemigo.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player") && anim != null)
        {
            // Al colisionar: reproducir animación de ataque primero
            anim.SetBool("Caminando", false);
            anim.SetTrigger("Atacando");

            // Guardar referencia al player temporalmente
            personaje = obj.transform;

            // Inicia conteo de ataque (para evitar spam)
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;
        }
    }

    public void AplicarDaño()
    {
        if (personaje != null)
        {
            var vida = personaje.GetComponentInChildren<VidasPlayer>();
            if (vida != null)
                vida.TomarDaño(dañoAlPlayer);
        }
    }

    public void TomarDaño(int daño)
    {
        vidaEnemigo -= daño;
        if (vidaEnemigo <= 0)
        {
            if (anim != null)
            {
                anim.SetTrigger("Muerto");
                agente.isStopped = true;
            }
        }
    }

    public void DestruirEnemigo()
    {
        Destroy(gameObject);
    }
}