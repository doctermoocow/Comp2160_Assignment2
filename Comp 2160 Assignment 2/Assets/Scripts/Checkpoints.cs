using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] checkpoints = new Vector3[transform.childCount];
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i] = transform.GetChild(i).position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
