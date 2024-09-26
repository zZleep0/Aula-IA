using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    //IA
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform stalker = null;
    [SerializeField] private float travelCost = 5f;

    ////Pulo
    //[SerializeField] private Rigidbody rb;
    //[SerializeField] private float forcaPulo;



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Calculando a direcao do stalker em relacao ao objeto atual
        Vector3 direction = (stalker.position - transform.position).normalized; //Direcao normalizada

        //Calculando a magnitude da direcao
        float magnitude = direction.magnitude;
        //Debug da magnitude no console
        print(magnitude);

        Gizmos.DrawLine(transform.position, transform.position + direction);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (agent == null)
        {
            if (!TryGetComponent(out agent))
            {
                Debug.LogWarning(name + "precisa colocar um navmesh agent");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stalker == null)
            return;

        Vector3 directionNormalized = (stalker.position - transform.position).normalized;

        directionNormalized = Quaternion.AngleAxis(Random.Range(-120, 120), Vector3.up) * directionNormalized;

        StartCoroutine(Mover(transform.position - (directionNormalized * travelCost)));

        //Jump();
    }

    //void MoverPara(Vector3 position)
    //{
    //    agent.SetDestination(position);
    //    agent.isStopped = false;
    //}

    IEnumerator Mover(Vector3 position)
    {
        agent.SetDestination(position);
        agent.isStopped = false;
        yield return new WaitForSeconds(3);
    }

    //void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
            
    //        rb.AddForce(new Vector3(0, 1, 0) * forcaPulo, ForceMode.Impulse);
    //        print("pulou");
    //    }
    //}
}
