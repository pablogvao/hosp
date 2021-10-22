using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material _maskMaterial;
    [SerializeField] private Material _clickMaterial;
    [SerializeField] private Material _defaultMaterial;

    //dicion�rio pra definir o status do elemento. chave � string e valor � bool
    public Dictionary<string, bool> ElementStates { get; private set; }

    //refer�ncia para a sele��o ou desele��o
    private Transform _selection;

    public bool Selecting = true;

    private void Start()
    {
        /*inicializando o dicion�rio, adicionando nele todos os game object com a tag "element",
          forma f�cil de adicionar ao dicion�rio e n�o listar cada elemento*/
        ElementStates = new Dictionary<string, bool>();
        var elements = GameObject.FindGameObjectsWithTag("element");
        foreach (var element in elements)
        {
            ElementStates.Add(element.name, false);
        }
    }

    void Update()
    {
        /*se a refer�ncia n�o for nula e n�o houverem objetos da biblioteca selecionados,
        altero o material pro padr�o e a refer�ncia volta pro nulo*/
        if (Selecting)
        {
            if (_selection != null && !ElementStates[_selection.name])
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
                //raycast s� continua para o que tiver a tag
                if (selection.CompareTag("element"))
                {
                    if (!ElementStates[selection.name])
                    {
                        selectionRenderer.material = _maskMaterial;
                        _selection = selection;
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        selectionRenderer.material = _clickMaterial;
                        ElementStates[selection.name] = !ElementStates[selection.name];
                        if (ElementStates[selection.name]) { _selection = null; }
                        Debug.Log(selection.name + ", " + ElementStates[selection.name]);
                    }
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