using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints;     //Array de pontos de patrulha
    [SerializeField] private float speed = 3f;          // Velocidade do patrulhamento
    [SerializeField] private int targetPoint = 0;                        //Ponto alvo atual

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = Random.Range(0, 6) % waypoints.Length; // Define o ponto alvo inicial aleatorio
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == waypoints[targetPoint].position)
        {
            //Atualiza o targetPoint para o proximo waypoint
            targetPoint = Random.Range(0, 6) % waypoints.Length; //Aleatoriza o proximo ponto
        }

        //Atualiza a posicao do NPC
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetPoint].position, speed * Time.deltaTime);
    }
}
