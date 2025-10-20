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
        if (MovX == -1)
        {
            dirAtaque = 1;
        }
        if (MovX == 1)
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

    private void ActualizaCapa()
    {
        if (CCCDuke.atacando == false && CADDuke.disparando == false)
        {
            if (PlayerMoviendose)
            {
                activaCapa("Caminar");
            }
            else
            {
                activaCapa("Idle");
            }
        } else
        {
            activaCapa("Ataque");
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
   
