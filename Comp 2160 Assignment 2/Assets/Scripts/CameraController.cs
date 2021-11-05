using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Rigidbody cameraTarget;
    public LayerMask groundLayer;



    //camera stuff
    public float scaleFactor = 0.1f;
    public float difPerSecond = 10f;
    public float velocityEmphasis = 5f;
    private Vector3 offset;
    private Vector3 newOffset;
    private Vector3 oldOffset;

    void Start()
    {
        newOffset = cameraTarget.transform.position;
    }

    void LateUpdate()
    {

        Debug.DrawLine(cameraTarget.transform.position, cameraTarget.transform.position +
            (new Vector3(cameraTarget.velocity.x, 0, cameraTarget.velocity.z)), Color.magenta);


        Ray ray = new Ray(cameraTarget.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * cameraTarget.velocity.magnitude, Color.white);
        }


        oldOffset = cameraTarget.transform.position;
        //  print(offset);
        newOffset += (oldOffset + (cameraTarget.velocity * velocityEmphasis) - newOffset) * Time.fixedDeltaTime / difPerSecond;

        Vector3 offset = Vector3.Lerp(cameraTarget.position, newOffset, scaleFactor);
        offset.y = hit.point.y;

       // print(newOffset);

        transform.position = offset;



        //turning camera movement        
       transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, cameraTarget.transform.eulerAngles.y, transform.rotation.eulerAngles.z);


       // previousVelocity = cameraTarget.velocity;
    }
}
