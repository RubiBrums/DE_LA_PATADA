using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject reiniciar;
    [SerializeField] private GameObject menuGameOver;

    public static GameOverScreen Instance { get; private set; }
    [SerializeField] private AudioSource backgroundSound;

    private bool juegoPausado = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (backgroundSound != null)
        {
            backgroundSound.Play();
        }
    }

    public void Perder()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        reiniciar.SetActive(true);
        menuGameOver.SetActive(true);
        if (backgroundSound != null)
        {
            backgroundSound.Pause();
        }
    }

    public void Reiniciar()
    {
        juegoPausado = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        if (backgroundSound != null)
        {
            backgroundSound.Play();
        }
    }

    public void MenuInicial(string nombre)
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        Application.Quit();
    }
}
