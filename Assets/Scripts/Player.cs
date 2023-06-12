using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private  CharacterController controlador;

    public float velocidade;
    public float alturaSalto;
    private float velcidadeSalto;
    public float gravity;
    public float horizontalSpeed;
    
    private bool MovimentoEsquerdo;
    private bool MovimentoDireito;

    public float rayRadius;

    public LayerMask layer;
    public LayerMask layerCoin;

    public Animator anim;
    public bool isDead;

    private Controlador_jogo gc;

    private float tempoDecorrido = 0f;
    public float aumentoVelocidadePorSegundo =  0.0000001f;

    

    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<CharacterController>();
        gc = FindObjectOfType<Controlador_jogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
    {
        return; // Sai do metodo Update se isDead for verdadeiro
    }

    velocidade = Mathf.Lerp(velocidade, velocidade + aumentoVelocidadePorSegundo, Time.deltaTime);

       Vector3 direction = Vector3.forward * velocidade;
    
        if(controlador.isGrounded)
         {
            if(Input.GetKeyDown(KeyCode.Space))
         {
              velcidadeSalto = alturaSalto;
         }
               if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 3.5f && !MovimentoDireito)
         {
              MovimentoDireito = true;
              StartCoroutine(rightMove());
         }
        
               if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -3.5f && !MovimentoEsquerdo)
         {
              MovimentoEsquerdo = true;
              StartCoroutine(leftMove());
         }
     }
     else
     {
        velcidadeSalto -= gravity;
    }

     ColisaoFrente();

        direction.y = velcidadeSalto;

        controlador.Move(direction * Time.deltaTime);

       
   }

   IEnumerator leftMove(){

        for(float i = 0 ; i < 10 ; i += 0.1f){

        controlador.Move(Vector3.left * Time.deltaTime * horizontalSpeed);

        yield return null;

     }
         MovimentoEsquerdo= false;
   }

    IEnumerator rightMove(){

       for(float i = 0 ; i < 10 ; i += 0.1f){

        controlador.Move(Vector3.right * Time.deltaTime * horizontalSpeed);

        yield return null;
   }
        MovimentoDireito = false;
 }

 void ColisaoFrente(){
     RaycastHit hit;

     if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) && !isDead)
     {
          //O jogo acaba
      anim.SetTrigger("die");
      velocidade = 0;
      alturaSalto = 0;
      horizontalSpeed = 0;
      Invoke("GameOver", 3f);

   

      isDead= true;
     }

      RaycastHit CoinHit;

     if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0 , 1f , 0)), out CoinHit, rayRadius, layerCoin) )
     {
          //Apanha da moeda
          gc.addCoin();
       Destroy(CoinHit.transform.gameObject);
    
     }
 } 
  void GameOver()
  {
  gc.Mostrar_gameOver();
  }
}