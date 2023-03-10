using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    Vector3 velocity;

    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity) {
        velocity = _velocity;
    }    

    void FixedUpdate(){
        rigidBody.MovePosition(rigidBody.position + (velocity * Time.fixedDeltaTime));
    }

    public void LookAt(Vector3 lookPoint) {
        Vector3 crctHeightPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(crctHeightPoint); 
    }
}
