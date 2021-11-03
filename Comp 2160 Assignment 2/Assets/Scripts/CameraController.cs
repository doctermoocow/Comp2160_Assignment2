using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Rigidbody cameraTarget;
    public float lerpSpeed = 1; 
    public LayerMask groundLayer;
    public Transform cameraTransfrom;
    public float cameraMaxSpeedDifference = 4;
    public float cameraMaxTurnDifference = 1;


    private Vector3 cameraStartingTransform;


    // Start is called before the first frame update
    void Start()
    {
        cameraStartingTransform = cameraTransfrom.position;
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
        Vector3 currTargetPosition = transform.position; //if the ray does not hit, the camera still needs a position to lerp from

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            currTargetPosition = hit.point;
          //  transform.position = hit.point;
        }
        //camera parent follows car
        transform.position = currTargetPosition;


        //Forwards and backwards camera movement

        //gets the offset of the velocity rather than local world coordinates and clamps it to the max distance the camera can move
        float zMax = Mathf.Clamp(cameraTarget.velocity.z,0,cameraMaxSpeedDifference);

        print(zMax);
        //zMax = Vector3.ClampMagnitude(zMax, cameraMaxSpeedDifference);




        Vector3 cameraNewOffset = new Vector3(0, 1.78f, transform.InverseTransformPoint(cameraStartingTransform).z);//z offset + horizontal offset;
        cameraTransfrom.transform.localPosition = Vector3.Lerp(transform.InverseTransformPoint(cameraStartingTransform), cameraNewOffset, 1);
        /*

        //Forwards and backwards camera movement
        //calculate velocity and lerp between current position and velocity vector
        float zLerp = Mathf.Lerp(currTargetPosition.z, currTargetPosition.z - cameraMaxSpeedDifference, cameraTarget.velocity.magnitude/10);
        camera.transform.localPosition = new Vector3(currTargetPosition.x, currTargetPosition.y , zLerp);
        */

        //turning camera movement        
        transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, cameraTarget.transform.eulerAngles.y, transform.rotation.eulerAngles.z);



    }
}
