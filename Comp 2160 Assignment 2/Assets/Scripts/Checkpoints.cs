using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private SphereCollider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            myCollider.enabled = false;
            GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        }
    }
}
