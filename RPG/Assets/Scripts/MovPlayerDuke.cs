using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayerDuke : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
    public Animator anim;

    private bool PlayerMoviendose = false;
    private float ultimoMovX, ultimoMovY;

    public static int dirAtaque = 0; //1- Front, 2- Back, 3- Left, 4- Right

    // --- NUEVO: Variables para AMBOS sonidos ---
    public AudioClip sonidoAtaqueMelee;     // Sonido para el ataque cuerpo a cuerpo
    public AudioClip sonidoAtaqueDistancia; // Sonido para el disparo
    private AudioSource audioSource;

    // --- NUEVO: Banderas separadas para cada ataque ---
    private bool yaSonoMelee = false;
    private bool yaSonoDistancia = false;
    // ------------------------------------------

    void Start() // --- NUEVO: Añadimos Start() para obtener el componente ---
    {
        // Obtenemos el componente AudioSource que añadiste al jugador
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate(){
        Movimiento();
        if (CCCDuke.atacando == false && CADDuke.disparando == false)
        {
            AnimacionesPlayer();
        }
    }

    private void Movimiento() {
        float MovX = Input.GetAxisRaw("Horizontal");
        float MovY = Input.GetAxisRaw("Vertical");
        dirMov = new Vector2(MovX,MovY).normalized;
        rb.velocity = new Vector2(dirMov.x * velMov,dirMov.y * velMov);

        if (MovX == -1)
        {
            dirAtaque = 3;
        }
        if (MovX == 1)
        {
            dirAtaque = 4;
        }
        if (MovY == -1)
        {
            dirAtaque = 1;
        }
        if (MovY == 1)
        {
            dirAtaque = 2;
        }

        if (MovX == 0 && MovY == 0) //Idle
        {
            PlayerMoviendose = false;
        }
        else //Caminar
        {
            PlayerMoviendose = true;
            ultimoMovX = MovX;
            ultimoMovY = MovY;
        }
        ActualizaCapa();
    }
    private void AnimacionesPlayer() {
        anim.SetFloat("MovX",ultimoMovX);
        anim.SetFloat("MovY",ultimoMovY);

    }

    // --- MODIFICADO: Toda la lógica de ActualizaCapa cambió ---
    private void ActualizaCapa()
    {
        // --- Lógica de Ataque Melee ---
        if (CCCDuke.atacando == true)
        {
            activaCapa("Ataque"); // Asumo que ambos usan la misma capa de animación

            // Si está atacando y el sonido de MELEE no ha sonado
            if (!yaSonoMelee && sonidoAtaqueMelee != null)
            {
                audioSource.PlayOneShot(sonidoAtaqueMelee);
                yaSonoMelee = true; // Marcamos que ya sonó
            }
            // Reiniciamos la bandera del otro ataque por si acaso
            yaSonoDistancia = false;
        }
        // --- Lógica de Ataque a Distancia ---
        else if (CADDuke.disparando == true)
        {
            activaCapa("Ataque"); // Asumo que ambos usan la misma capa de animación

            // Si está disparando y el sonido de DISTANCIA no ha sonado
            if (!yaSonoDistancia && sonidoAtaqueDistancia != null)
            {
                audioSource.PlayOneShot(sonidoAtaqueDistancia);
                yaSonoDistancia = true; // Marcamos que ya sonó
            }
            // Reiniciamos la bandera del otro ataque por si acaso
            yaSonoMelee = false;
        }
        // --- Lógica de Idle / Caminar (Si NO ataca) ---
        else
        {
            if (PlayerMoviendose)
            {
                activaCapa("Caminar");
            }
            else
            {
                activaCapa("Idle");
            }

            // Cuando el jugador DEJA de atacar, reiniciamos AMBAS banderas.
            yaSonoMelee = false;
            yaSonoDistancia = false;
        }
    }
    
    private void activaCapa(string nombre)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0); //Ambos layers con weight en 0
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
}