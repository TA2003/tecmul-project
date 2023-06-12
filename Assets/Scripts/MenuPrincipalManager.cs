using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
 
{
 [SerializeField] private string jogo;
 
    public void Jogar() {

     SceneManager.LoadScene(jogo);
    }
}
