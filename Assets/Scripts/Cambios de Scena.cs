using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiosdeScena : MonoBehaviour
{
  public void Nivel1()
    {

        SceneManager.LoadScene("Nivel");
    }
    public void Derrota()
    {

        SceneManager.LoadScene("Derrota");
    }
    public void Victoria()
    {

        SceneManager.LoadScene("Victoria 1");
    }
    public void Menu()
    {

        SceneManager.LoadScene("Menu");
    }
    public void Salir()
    {

        Debug.Log("salir");
        Application.Quit();
    }

}
