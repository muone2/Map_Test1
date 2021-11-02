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
        if (isOn == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * power*0.1f);
            if (gameObject.transform.position.y < ButtonMinY)
                gameObject.transform.position += new Vector3(0, ButtonMinY- gameObject.transform.position.y, 0);
            if (puzzle.transform.localPosition.z < 5.1f )
                puzzle.transform.Translate(Vector3.forward * wallpower * Time.deltaTime, Space.World);


        }
        else if (isOn == false)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * power);
            if (gameObject.transform.position.y > ButtonMaxY)
                gameObject.transform.position += new Vector3(0, ButtonMaxY - gameObject.transform.position.y, 0);
            if(puzzle.transform.localPosition.z>0)
               puzzle.transform.Translate(Vector3.back * wallpower * Time.deltaTime, Space.World);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOn = true;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
          //  puzzle.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            isOn = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
          //  puzzle.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
}
/*
puzzle.GetComponent<Rigidbody>().AddForce(Vector3.back * power);
if (puzzle.transform.position.z < 0f)
    puzzle.transform.position = new Vector3(0, 5.1f, 0);
puzzle.GetComponent<Rigidbody>().AddForce(Vector3.forward * power);
if (puzzle.transform.position.z > 5.1f)
    puzzle.transform.position += new Vector3(0, 5.1f - puzzle.transform.position.z, 0);*/