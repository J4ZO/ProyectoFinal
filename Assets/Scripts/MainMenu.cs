using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    // Referencias a los paneles
    public GameObject menuPrincipal;
    public GameObject menuOpciones;
    public GameObject menuCreditos;
    
    // Referencia al AudioMixer
    [SerializeField] private AudioMixer audioMixer;
    public Image filtroBrillo;//Imagen que simula el brillo

    // Método para cargar la siguiente escena (botón Jugar)
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Método para mostrar el menú principal
    public void ShowMenuPrincipal()
    {
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
        menuCreditos.SetActive(false);
    }

    // Método para mostrar el menú de opciones
    public void ShowMenuOpciones()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
        menuCreditos.SetActive(false);
    }

    // Método para mostrar el menú de créditos
    public void ShowMenuCreditos()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(false);
        menuCreditos.SetActive(true);
    }

    // Método para cambiar el volumen
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void CambiarBrillo(float brillo)
    {
        // Ajusta la opacidad del filtro según el brillo
        Color colorActual = filtroBrillo.color;
        colorActual.a = 1 - brillo; // Reduce opacidad para más brillo
        filtroBrillo.color = colorActual;
    }
}
