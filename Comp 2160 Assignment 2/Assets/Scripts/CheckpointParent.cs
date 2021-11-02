using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointParent : MonoBehaviour
{

    private int currCheckpoint;
    private GameObject[] checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        currCheckpoint = 0;
        checkpoints = new GameObject[transform.childCount];
        /*
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i] = GetComponentInChildren<Checkpoints>().gameObject;
            Debug.Log(i);
            Debug.Log(checkpoints[i]);
            checkpoints[i].GetComponent<Collider>().enabled = false;
            
        }
        checkpoints[0].GetComponent<Collider>().enabled = true;
        */        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkpoints[currCheckpoint].GetComponent<Collider>().enabled == false)
        {
            currCheckpoint++;
            checkpoints[currCheckpoint].GetComponent<Collider>().enabled = true;
        }
    }
}
