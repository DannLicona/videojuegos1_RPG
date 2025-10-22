using UnityEngine;
using UnityEngine.EventSystems;

public class DialogoNPC : MonoBehaviour
{
    private void OnMouseDown()
    {
        this.gameObject.SetActive(false);
    }
}