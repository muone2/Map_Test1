using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    public float ButtonMaxY;
    public float ButtonMinY;

    public float power;
    public float wallpower;

    public bool isOn;

    public GameObject puzzle;


    // Start is called before the first frame update
    void Start()
    {
        ButtonMaxY = gameObject.transform.position.y;
        ButtonMinY = gameObject.transform.position.y - 0.5f;
        power = 1f;
        wallpower = 3f;
        isOn = false;
    }

    private void FixedUpdate()
    {
        StartCoroutine(ButtonDown());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOn = true;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            isOn = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }


    IEnumerator ButtonDown()
    {
        if (isOn == true && gameObject.transform.position.y > ButtonMinY)
            gameObject.transform.Translate(0, -0.01f, 0);
        else if (isOn == false && gameObject.transform.position.y < ButtonMaxY)
            gameObject.transform.Translate(0, 0.01f, 0);

        if (isOn == true && puzzle.transform.localPosition.z < 5.1f)
            puzzle.transform.Translate(0, 0, 0.05f);
        else if (isOn == false && puzzle.transform.localPosition.z > 0f)
            puzzle.transform.Translate(0, 0, -0.05f);

        yield return new WaitForSeconds(0.01f);
    }

}