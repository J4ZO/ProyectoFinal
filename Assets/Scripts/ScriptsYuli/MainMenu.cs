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
    public Slider slider;
    public float sliderValue;
    public Image filtroBrillo;//Imagen que simula el brillo

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", 5f);
        filtroBrillo.color = new Color(filtroBrillo.color.r,filtroBrillo.color.g, filtroBrillo.color.b, slider.value);
    }

    // M�todo para cargar la siguiente escena (bot�n Jugar)
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // M�todo para mostrar el men� principal
    public void ShowMenuPrincipal()
    {
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
        menuCreditos.SetActive(false);
    }

    // M�todo para mostrar el men� de opciones
    public void ShowMenuOpciones()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
        menuCreditos.SetActive(false);
    }

    // M�todo para mostrar el men� de cr�ditos
    public void ShowMenuCreditos()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(false);
        menuCreditos.SetActive(true);
    }

    // M�todo para cambiar el volumen
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void CambiarBrillo(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        filtroBrillo.color = new Color(filtroBrillo.color.r, filtroBrillo.color.g, filtroBrillo.color.b, slider.value);

    }
}
