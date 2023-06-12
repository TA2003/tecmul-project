using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controlador_jogo : MonoBehaviour


    
{
   public GameObject gameOver;
   public float pontuacao; 
    public int scoreCoin;

   public TextMeshProUGUI scoreText;
   public TextMeshProUGUI coinText;
  

   private Player player;

  

    // Start is called before the first frame update
   void Start()
{
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    GameObject pontuacao = GameObject.Find("Pontuacao");
    if (pontuacao != null)
    {
        scoreText = pontuacao.GetComponent<TextMeshProUGUI>();
    }

     player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    GameObject scoreCoin = GameObject.Find("Score Coin");
    if ( scoreCoin  != null)
    {
        coinText = scoreCoin.GetComponent<TextMeshProUGUI>();
    }


}

    // Update is called once per frame
    void Update()
    {
        if(!player.isDead){ 
            
        pontuacao += Time.deltaTime * 5f;
         
        if (scoreText != null)
{
    scoreText.text ="Score:" + Mathf.Round(pontuacao).ToString();
}
}
        
    }

    public void Mostrar_gameOver()
    {
        gameOver.SetActive(true);
    }

    public void addCoin(){

        scoreCoin++;
                if (coinText!= null)
{
    coinText.text = scoreCoin.ToString();
    }
}
}