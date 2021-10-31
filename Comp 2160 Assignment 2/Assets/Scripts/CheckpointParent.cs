using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] checkpoints = new GameObject[transform.childCount];
        for(int i = 0; i < checkpoints.Length; i++)
        {
            //checkpoints[i] = transform.GetChild(i);
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
