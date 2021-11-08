using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallOnCircle : MonoBehaviour
{
    public GameObject empyt;
    public float radious;
    public Vector3 velVec;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            velVec = collision.gameObject.GetComponent<Rigidbody>().velocity;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(velVec, ForceMode.Force);


            radious = (collision.transform.position - empyt.transform.position).magnitude;

        }

    }

}
