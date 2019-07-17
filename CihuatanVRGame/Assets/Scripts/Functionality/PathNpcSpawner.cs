using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNpcSpawner : MonoBehaviour
{
    public GameObject Npc;
    private float seconds;
    public float maxSeconds = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds > maxSeconds)
        {
            float random = Random.Range(1, 100);
            Debug.Log("RANDOM IS " + random);
            if (random >= 30 && random <= 70)
            {
                Instantiate(Npc, this.transform.position, Quaternion.identity);
            }
            seconds = 0;
        }
    }
}
