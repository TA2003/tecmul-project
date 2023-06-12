using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List <GameObject> plataformas = new List <GameObject>();
    public List <Transform> plataformaAtual = new List <Transform>();

    public int desvio;
    private Transform player;
    private Transform pontoAtualPlataforma;
    private int IndexPlataforma;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < plataformas.Count; i++)
        {
         Transform p = Instantiate(plataformas[i], new Vector3(0,0,i * 85), transform.rotation).transform;
         plataformaAtual.Add(p);
          desvio += 85;
        }
        pontoAtualPlataforma = plataformaAtual[IndexPlataforma].GetComponent<Plataforma>().ponto;

    }
   
    // Update is called once per frame
    void Update()
    {
        float distancia = player.position.z - pontoAtualPlataforma.position.z;
        if(distancia >= 5){
            Recycle(plataformaAtual[IndexPlataforma].gameObject);
            
            IndexPlataforma++;
              if(IndexPlataforma > plataformaAtual.Count -1){
                   IndexPlataforma = 0;
              }

            pontoAtualPlataforma = plataformaAtual[IndexPlataforma].GetComponent<Plataforma>().ponto;
        }
    }

    public void Recycle(GameObject plataforma)
    {
        plataforma.transform.position = new Vector3(0 , 0 , desvio);
        desvio += 85;
    }
}
