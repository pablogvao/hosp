using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ClickOn clickOnScript = hit.collider.GetComponent<ClickOn>();
                clickOnScript.currentlySelected = !clickOnScript.currentlySelected;
                clickOnScript.ClickMe();
            }
        }
    }
}
