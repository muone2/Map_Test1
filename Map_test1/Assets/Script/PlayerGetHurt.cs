using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHurt : MonoBehaviour
{
    Color startColor;


    // Start is called before the first frame update
    void Start()
    {
        startColor = GetComponent<MeshRenderer>().material.color;
    }


    void OnDamaged(Vector3 targetpoint)
    {
        GetComponent<MeshRenderer>().material.color = Color.black;
        GetComponent<Rigidbody>().AddForce((transform.position - targetpoint)*7, ForceMode.Impulse);

        Invoke("OffDamaged", 0.5f);
    }

    void OffDamaged()
    {
        GetComponent<MeshRenderer>().material.color = startColor;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //벽에 닿았을때
        if (collision.gameObject.CompareTag("Wall"))
            OnDamaged(collision.contacts[0].point);  //처음으로 충돌한 지점
    }

}
