using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {     
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = new Vector3(Mathf.Clamp(transform.position.x,-2.5f,2.5f),0,transform.position.z) + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            

            transform.position = Vector3.Lerp(this.transform.position, targetPos + offset, 0.25f);
            

        }
    }

}