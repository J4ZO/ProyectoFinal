using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Jugar();
            }
            else 
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        juegoPausado=true;
        Time.timeScale = 0f ;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Jugar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Restaurar()
    {
        Time.timeScale = 0f ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        Time.timeScale = 1f; // Asegúrate de restaurar el tiempo antes de cambiar de escena.
        SceneManager.LoadScene("Menu");
    }
}
