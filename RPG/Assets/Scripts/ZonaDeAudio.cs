using UnityEngine;

// Asegurémonos de que este objeto SIEMPRE tenga un AudioSource
[RequireComponent(typeof(AudioSource))]
public class ZonaDeAudio : MonoBehaviour
{
    private AudioSource miAudioSource;

    void Start()
    {
        // Obtenemos la referencia al AudioSource que está
        // en este mismo objeto
        miAudioSource = GetComponent<AudioSource>();
    }

    // Esta función se llama automáticamente cuando
    // algo ENTRA en el trigger
    private void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        // Comprobamos si lo que entró tiene la etiqueta "Player"
        if (otroObjeto.CompareTag("Player"))
        {
            // Si el audio no está sonando ya, lo reproducimos
            if (!miAudioSource.isPlaying)
            {
                miAudioSource.Play();
            }
        }
    }

    // Esta función se llama automáticamente cuando
    // algo SALE del trigger
    private void OnTriggerExit2D(Collider2D otroObjeto)
    {
        // Comprobamos si lo que salió fue el "Player"
        if (otroObjeto.CompareTag("Player"))
        {
            // Si el audio está sonando, lo detenemos
            if (miAudioSource.isPlaying)
            {
                miAudioSource.Stop();
            }
        }
    }
}