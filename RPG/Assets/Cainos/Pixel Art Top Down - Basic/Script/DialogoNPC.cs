using UnityEngine;
using UnityEngine.EventSystems;

public class DialogoNPC : MonoBehaviour
{
    
    public AudioClip sonidoAlActivar; 
    // -----------

    private void OnMouseDown()
    {
        // --- NUEVO: Reproducir el sonido ---
        // Esto crea un AudioSource temporal en la posición del NPC
        // que reproducirá el clip completo aunque el NPC se desactive.
        if (sonidoAlActivar != null)
        {
            AudioSource.PlayClipAtPoint(sonidoAlActivar, transform.position);
        }
        
       
        this.gameObject.SetActive(false);
    }
}