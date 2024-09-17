using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class VidaManager : MonoBehaviour
{
    public TMP_Text textoVida; 
    public Player personaje; 

    void Update()
    {
        
        if (personaje != null && textoVida != null)
        {
            
            textoVida.text = "Vida: " + personaje.vida;
        }
    }
}