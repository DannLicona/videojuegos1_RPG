using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayerCanela : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
    public Animator anim; 

   
    void FixedUpdate(){
        Movimiento();
        AnimacionesPlayer();

    }

    private void Movimiento() {
        float MovX = Input.GetAxisRaw("Horizontal");
        float MovY = Input.GetAxisRaw("Vertical");
        dirMov = new Vector2(MovX,MovY).normalized;
        rb.velocity = new Vector2(dirMov.x * velMov,dirMov.y * velMov);
    }
    private void AnimacionesPlayer() {
        anim.SetFloat("MovX",dirMov.x);
         anim.SetFloat("MovY",dirMov.y);

    }

    
}
