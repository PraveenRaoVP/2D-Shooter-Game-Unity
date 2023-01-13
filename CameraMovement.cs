using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 cameraOffset=new Vector3(0,1,-3);
    public Transform targetObject;
    public bool lookAtTarget=false;
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;  //+cameraOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(targetObject != null) { 

            Vector3 newPosition = targetObject.transform.position + cameraOffset;
            transform.position = Vector3.Slerp(transform.position,newPosition,1f);
            if(lookAtTarget){
                transform.LookAt(targetObject);
            }
        }
    }
}