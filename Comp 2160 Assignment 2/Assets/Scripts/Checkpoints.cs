using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        radius = FindObjectOfType<GameManager>().checkpointRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
