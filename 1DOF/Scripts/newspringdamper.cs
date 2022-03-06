using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newspringdamper : MonoBehaviour
{
    [Header("Init")]
    public GameObject attachedObject;
    private Rigidbody rootrb;
    private Vector3 rootToattachedVector;

    [Header("Suspension")]
    public float springConstant;

    private float lengthChange;
    private float relaxedLength;
    private float currentLength;

    private float springForceMag;
    private float pastLength;

    [Header("Damper")]

    public float damperConstant;
    private Vector3 rootVelocity;
    private Vector3 pastrootVelocity;
    public float damperForceMag;
    private Ray ray;

    

    void Start()
    {
        rootrb = transform.root.GetComponent<Rigidbody>();
        rootToattachedVector = transform.position - attachedObject.transform.position;
        relaxedLength = rootToattachedVector.magnitude;

    }

    void FixedUpdate()
    {
        pastLength = currentLength;
        rootToattachedVector = transform.position - attachedObject.transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -rootToattachedVector, out hit)) {
            currentLength = hit.distance;
        }


        //currentLength = rootToattachedVector.magnitude;
        lengthChange = relaxedLength - currentLength;

        pastrootVelocity = rootVelocity;
        rootVelocity = rootrb.velocity;

        springForceMag = springConstant * lengthChange;
        damperForceMag = damperConstant * (currentLength-pastLength) / Time.fixedDeltaTime;




        rootrb.AddForceAtPosition(rootToattachedVector.normalized  * (springForceMag - damperForceMag ) , this.transform.position);

        
        Debug.DrawLine(transform.position, attachedObject.transform.position, Color.green);
        
    }
}
