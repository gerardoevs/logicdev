using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonInteractableNpcController : MonoBehaviour
{
    public GameObject[] Npc_list;
    public GameObject[] points;
    private NavMeshAgent agent;

    private float seconds;
    public float maxSeconds = 10;

    // Start is called before the first frame update
    void Start()
    {
        //this.agent = Npc_list[0].GetComponent<NavMeshAgent>();
        //Instantiate(this.Npc_list[0], this.points[0].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        Debug.Log(Mathf.RoundToInt(seconds));
        if (seconds > 10) {
            float random = Random.Range(1, 100);
            Debug.Log("RANDOM IS " + random);
            if (random >= 30 && random <= 70)
            {
                int spawnSelector = Random.Range(0, this.points.Length);
                Debug.Log(spawnSelector + "--" + points[spawnSelector]);
                Instantiate(this.Npc_list[0], this.points[spawnSelector].transform.position, Quaternion.identity);
                this.Npc_list[0].GetComponent<NavMeshAgent>().destination = this.points[0].transform.position;
            }
            seconds = 0;
        }
        //agent.destination = points[1].transform.position;  
    }

    private void checkPath(NavMeshAgent agent) {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    agent.destination = points[0].transform.position;
                }
            }
        }
    }
}
