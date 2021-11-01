using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Rigidbody cameraTarget;
    public float lerpSpeed = 1; 
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //basic add camera
       /// transform.position = cameraTarget.position;
    }

    void LateUpdate()
    {
        //calculate camera distance from ground (needs to stay before calculating vector
        Ray ray = new Ray(cameraTarget.transform.position, Vector3.down);
        RaycastHit hit;
        Vector3 nextPosition = transform.position; //if the ray does not hit, the camera still needs a position to lerp from

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            nextPosition = hit.point;
          //  transform.position = hit.point;
        }
        //calculate velocity and lerp between current position and velocity vector
        Vector3 newPosition = cameraTarget.transform.position - cameraTarget.velocity;
        Vector3 newOffset = new Vector3(newPosition.x, nextPosition.y, newPosition.z);


        transform.position = Vector3.Lerp(nextPosition, newOffset, lerpSpeed * Time.deltaTime);
        transform.rotation = new Quaternion(transform.rotation.x, cameraTarget.transform.rotation.y, transform.rotation.z, transform.rotation.w);



    }
}
