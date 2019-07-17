using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcPath : MonoBehaviour
{
    public GameObject[] ListOfPoints;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = ListOfPoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 2) {
            Debug.Log("STOPED :" + agent.remainingDistance);
            Destroy(this.gameObject);
        }
    }
}
