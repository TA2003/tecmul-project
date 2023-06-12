using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BazarManager : MonoBehaviour

{
    [SerializeField] private string restart;
    [SerializeField] private string bazar;

    public void Restart()
    {
        SceneManager.LoadScene(restart);
    }

    public void Baza()
    {
        SceneManager.LoadScene(bazar);
    }
}
