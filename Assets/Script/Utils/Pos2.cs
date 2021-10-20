using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pos2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pos2;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, pos2.position, Time.deltaTime);

            Vector3 currentAngle = new Vector3(
                Mathf.Lerp(Camera.main.transform.rotation.eulerAngles.x, pos2.transform.rotation.eulerAngles.x, Time.deltaTime),
                Mathf.Lerp(Camera.main.transform.rotation.eulerAngles.y, pos2.transform.rotation.eulerAngles.y, Time.deltaTime),
                Mathf.Lerp(Camera.main.transform.rotation.eulerAngles.z, pos2.transform.rotation.eulerAngles.z, Time.deltaTime));

            Camera.main.transform.eulerAngles = currentAngle;
            Debug.Log("Cliquei");
        }

    }
}
