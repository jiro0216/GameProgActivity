using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidBody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidBody.useGravity = false;
    }

    public void Drop() 
    {
        this.objectGrabPointTransform = null;
        objectRigidBody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float LerpSpeed = 10f;
           Vector3 newPosition =  Vector3.Lerp(objectGrabPointTransform.position, objectGrabPointTransform.position, Time.deltaTime * LerpSpeed);
            // Assuming ObjectPointTransform is supposed to be objectGrabPointTransform
            objectRigidBody.MovePosition(newPosition);
        }
    }
}
