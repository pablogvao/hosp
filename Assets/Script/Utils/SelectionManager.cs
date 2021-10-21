using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material _maskMaterial;
    [SerializeField] private Material _clickMaterial;
    [SerializeField] private Material _defaultMaterial;

    //dicionário pra definir o status do elemento. chave é string e valor é bool
    private Dictionary<string, bool> _elementStates;

    //referência para a seleção ou deseleção
    private Transform _selection;

    private void Start()
    {
        /*inicializando o dicionário, adicionando nele todos os game object com a tag "element",
          forma fácil de adicionar ao dicionário e não listar cada elemento*/
        _elementStates = new Dictionary<string, bool>();
        var elements = GameObject.FindGameObjectsWithTag("element");
        foreach (var element in elements)
        {
            _elementStates.Add(element.name, false);
        }
        
    }

    void Update()
    {
        /*se a referência não for nula e não houverem objetos da biblioteca selecionados,
        altero o material pro padrão e a referência volta pro nulo*/
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
            //raycast só continua para o que tiver a tag
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


    //public void PrintDictionary()
    //{
    //    foreach (KeyValuePair<string, bool> pair in _elementStates)
    //    {
    //        Debug.Log(_elementStates[name]);
    //        //Debug.Log("Key = {0}, Value {1}", pair.Key, pair.Value);
    //    }
    //}
}