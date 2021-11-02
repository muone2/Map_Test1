using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour
{
    public GameObject ball;
    Vector3 posa;
    private void Start()
    {
        posa = ball.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.transform.position = posa;
        }
    }
}
