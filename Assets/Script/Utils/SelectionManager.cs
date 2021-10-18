using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material maskMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionrenderer = _selection.GetComponent<Renderer>();
            selectionrenderer.material = defaultMaterial;
            _selection = null;
        }

        //mesh collider aplicado na unity apenas nos itens selecionáveis
        //elimino a necessidade do filtro no raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = maskMaterial;
            }

            _selection = selection;

            //if (Input.GetMouseButtonDown(0))
            //{
            //    Debug.Log(hit.transform.name);
            //    selectionRenderer.material = maskMaterial;
            //} 

        }








        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    var click = hit.transform;
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Debug.Log(hit.transform.name);
        //        var clickRenderer = click.GetComponent<Renderer>();
        //        if (clickRenderer != null)
        //        {
        //            clickRenderer.material = maskMaterial;
        //        }
        //    }
        //}


        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        var click = hit.transform;
        //        var clickRenderer = click.GetComponent<Renderer>();
        //        clickRenderer.material = maskMaterial;
        //        selected = true;
        //        Debug.Log(hit.transform.name);
        //        Debug.Log(selected);
        //    }
        //}

    }
}