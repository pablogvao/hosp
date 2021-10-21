using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelBlock;
    public GameObject slcManager;
    public InputField inputName;
    public InputField inputUse;

    private string _name;
    private string _use;

    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            panelBlock.SetActive(true);
            slcManager.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            panelBlock.SetActive(false);
            slcManager.SetActive(true);
        }
        CleanInputField();
    }

    public void StoreInfo()
    {
        _name = inputName.text;
        _use = inputUse.text;

        //Debug.Log($"O nome é {_name} e essa pessoa quer {_use}");
        CleanInputField();
    }

    public void CleanInputField()
    {
        inputName.text = "";
        inputUse.text = "";
    }
}
