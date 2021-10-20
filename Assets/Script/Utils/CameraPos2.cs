using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos2 : MonoBehaviour
{
    public Transform pos2;
    public Transform pos3;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pos2.position, Time.deltaTime);

        Vector3 currentAngle = new Vector3(
            Mathf.Lerp(transform.rotation.eulerAngles.x, pos2.transform.rotation.eulerAngles.x, Time.deltaTime),
            Mathf.Lerp(transform.rotation.eulerAngles.y, pos2.transform.rotation.eulerAngles.y, Time.deltaTime),
            Mathf.Lerp(transform.rotation.eulerAngles.z, pos2.transform.rotation.eulerAngles.z, Time.deltaTime));

        transform.eulerAngles = currentAngle;
    }

    public void MovePos2()
    {

    }
}

