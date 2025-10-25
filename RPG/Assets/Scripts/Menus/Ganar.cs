using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{

    public void VolverAlMenu()
    {
        
        SceneManager.LoadScene("Menu");
    }
}
