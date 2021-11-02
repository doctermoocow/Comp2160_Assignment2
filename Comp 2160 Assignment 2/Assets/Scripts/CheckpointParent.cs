using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointParent : MonoBehaviour
{
    private GameManager gameManager;
    private int currCheckpoint;
    private GameObject[] checkpoints;
    private bool finalCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        currCheckpoint = 0;
        checkpoints = new GameObject[transform.childCount];

        int i = 0;
        foreach(Transform child in transform)
        {
            checkpoints[i] = child.gameObject;
            if(i == 0)
            {
                checkpoints[i].GetComponent<Collider>().enabled = true;
            }
            else
            {
                checkpoints[i].GetComponent<Collider>().enabled = false;
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(checkpoints[currCheckpoint].GetComponent<Collider>().enabled == false)
        {
            if(currCheckpoint == checkpoints.Length-1)
            {
                finalCheckpoint = true;
            }
            else
            {              
                finalCheckpoint = false;
                currCheckpoint++;
                checkpoints[currCheckpoint].GetComponent<Collider>().enabled = true;
            }
        }
        
    }
}
