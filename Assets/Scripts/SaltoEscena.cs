using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaltoEscena : MonoBehaviour
{
    public string escenaACargar;

    public void Skip()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escenaACargar);
    }
}