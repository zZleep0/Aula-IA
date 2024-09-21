using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform stalker = null;
    [SerializeField] private float travelCost = 5f;

    


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

        //directionNormalized = Quaternion.AngleAxis(Random.Range(0,179), Vector3.up) * directionNormalized;

        MoverPara(transform.position - (directionNormalized * travelCost));
    }

    void MoverPara(Vector3 position)
    {
        agent.SetDestination(position);
        agent.isStopped = false;
    }
}
