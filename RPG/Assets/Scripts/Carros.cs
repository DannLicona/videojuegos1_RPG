using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carros : MonoBehaviour
{
    public Transform[] puntosRuta;
    public float reachThreshold = 0.12f;
    public float velocidad = 3.5f;
    public bool usarRigidbody2D = true;
    public float checkInterval = 0.6f;
    public float minDistMovida = 0.02f;
    public float maxTiempoAtascado = 1.0f;

    private int indiceRuta = 0;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private Vector2 ultimoPosCheck;
    private float tiempoSinMovimiento = 0f;
    private float tiempoUltimoCheck = 0f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (puntosRuta == null || puntosRuta.Length == 0)
        {
            Debug.LogWarning("Carros: no hay puntosRuta asignados.");
            enabled = false;
            return;
        }

        if (usarRigidbody2D && rb2d == null)
        {
            usarRigidbody2D = false;
        }

        ultimoPosCheck = transform.position;
        tiempoUltimoCheck = Time.time;
        tiempoSinMovimiento = 0f;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        if (!usarRigidbody2D)
        {
            Mover(transform.position, Time.deltaTime);
        }

        RotaCarro();

        if (Time.time - tiempoUltimoCheck >= checkInterval)
        {
            Vector2 actual = transform.position;
            float dist = Vector2.Distance(actual, ultimoPosCheck);

            if (dist < minDistMovida)
            {
                tiempoSinMovimiento += Time.time - tiempoUltimoCheck;
            }
            else
            {
                tiempoSinMovimiento = 0f;
            }

            ultimoPosCheck = actual;
            tiempoUltimoCheck = Time.time;

            if (tiempoSinMovimiento >= maxTiempoAtascado)
            {
                AvanzarSiguientePunto();
                tiempoSinMovimiento = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (usarRigidbody2D && rb2d != null)
        {
            Mover(rb2d.position, Time.fixedDeltaTime);
        }
    }

    private void Mover(Vector2 currentPos, float delta)
    {
        if (puntosRuta == null || puntosRuta.Length == 0) return;

        Vector2 objetivo = (Vector2)puntosRuta[indiceRuta].position;
        float paso = velocidad * delta;
        Vector2 nuevo = Vector2.MoveTowards(currentPos, objetivo, paso);

        if (usarRigidbody2D && rb2d != null)
            rb2d.MovePosition(nuevo);
        else
            transform.position = new Vector3(nuevo.x, nuevo.y, transform.position.z);

        if (Vector2.Distance(nuevo, objetivo) <= reachThreshold)
        {
            AvanzarSiguientePunto();
        }
    }

    private void AvanzarSiguientePunto()
    {
        if (puntosRuta == null || puntosRuta.Length == 0) return;

        indiceRuta++;
        if (indiceRuta >= puntosRuta.Length) indiceRuta = 0;
        tiempoSinMovimiento = 0f;
        ultimoPosCheck = transform.position;
        tiempoUltimoCheck = Time.time;
    }

    private void RotaCarro()
    {
        if (puntosRuta == null || puntosRuta.Length == 0 || sprite == null) return;
        Vector3 objetivo = puntosRuta[indiceRuta].position;
        sprite.flipX = transform.position.x > objetivo.x;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var vidas = other.GetComponent<VidasPlayer>();
            if (vidas != null)
            {
                vidas.TomarDaño(int.MaxValue);
            }
        }
    }
}
