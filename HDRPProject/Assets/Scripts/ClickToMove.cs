using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private GameObject Ethan;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Ethan = GameObject.Find("Ethan");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Ethan.transform.position;
    }
}