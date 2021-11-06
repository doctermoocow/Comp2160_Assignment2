using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointParent : MonoBehaviour
{
    private GameManager gameManager;
    private int currCheckpoint;
    private GameObject[] checkpoints;
    private bool finalCheckpoint;

    private Dictionary<int, string> checkComplete;

    // Start is called before the first frame update
    void Start()
    {
        finalCheckpoint = false;
        checkComplete = new Dictionary<int, string>();
        gameManager = FindObjectOfType<GameManager>();

        currCheckpoint = 0;
        checkpoints = new GameObject[transform.childCount];

        int i = 0;
        foreach(Transform child in transform)
        {
            checkpoints[i] = child.gameObject;
            if(i == 0)
            {
                checkpoints[i].GetComponent<SphereCollider>().enabled = true;
                checkpoints[i].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            }
            else
            {
                checkpoints[i].GetComponent<SphereCollider>().enabled = false;
            }
            checkpoints[i].GetComponent<SphereCollider>().radius = gameManager.checkpointRadius;
            checkComplete.Add(i, "Incomplete");
            i++;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(checkpoints[currCheckpoint].GetComponent<Collider>().enabled == false && finalCheckpoint == false)
        {
            checkComplete[currCheckpoint] = FindObjectOfType<UIManager>().getTime();
            if(currCheckpoint == checkpoints.Length-1)
            {
                finalCheckpoint = true;
                gameManager.Checkpoint(finalCheckpoint);
            }
            else
            {              
                gameManager.Checkpoint(finalCheckpoint);
                currCheckpoint++;
                checkpoints[currCheckpoint].GetComponent<Collider>().enabled = true;
                checkpoints[currCheckpoint].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            }
        }
        
    }

    public Dictionary<int, string> getCheckpointStatus()
    {
        return checkComplete;
    }
}
