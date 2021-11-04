using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCircle : MonoBehaviour
{
    private void FixedUpdate()
    {
        StartCoroutine(SSH_TurnCircle());
    }

    IEnumerator SSH_TurnCircle()
    {
        gameObject.transform.eulerAngles = gameObject.transform.eulerAngles + new Vector3(0, 1.5f, 0);
        yield return new WaitForSeconds(0.01f);
    }
}
