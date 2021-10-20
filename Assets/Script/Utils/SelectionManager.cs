using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material _maskMaterial;
    [SerializeField] private Material _clickMaterial;
    [SerializeField] private Material _defaultMaterial;

    private Dictionary<string, bool> _elementStates;

    private Transform _selection;

    private void Start()
    {
        _elementStates = new Dictionary<string, bool>();
        var elements = GameObject.FindGameObjectsWithTag("element");
        foreach (var element in elements)
        {
            _elementStates.Add(element.name, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null && !_elementStates[_selection.name])
        {
            var selectionrenderer = _selection.GetComponent<Renderer>();
            selectionrenderer.material = _defaultMaterial;
            _selection = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selection.CompareTag("element"))
            {
                if (!_elementStates[selection.name])
                {
                    selectionRenderer.material = _maskMaterial;
                    _selection = selection;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    selectionRenderer.material = _clickMaterial;
                    _elementStates[selection.name] = !_elementStates[selection.name];
                    if (_elementStates[selection.name]) { _selection = null; }
                    Debug.Log(selection.name + ", " + _elementStates[selection.name]);
                }
            }
        }
    }
}