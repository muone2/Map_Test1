using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour
{
    public GameObject ball;
    public Vector3 posa;
    private void Start()
    {
        posa = ball.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = posa;
        }
    }
}
