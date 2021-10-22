using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    private GameObject _panel;
    private GameObject _panelBlock;
    private SelectionManager _slcManager;
    private InputField _inputName;
    private InputField _inputUse;

    private UserInfo _userInfo;

    public void Awake()
    {
        _panel = transform.Find("PnInputName&Use").gameObject;
        _panel.SetActive(false);
        _panelBlock = transform.Find("PanelBlock").gameObject;
        _panelBlock.SetActive(false);
        _slcManager = GameObject.Find("Project Manager").GetComponent<SelectionManager>();
        _inputName = _panel.transform.Find("InputName").GetComponent<InputField>();
        _inputUse = _panel.transform.Find("InputUse").GetComponent<InputField>();
    }

    public void OpenPanel()
    {
        if (_panel != null)
        {
            _panel.SetActive(true);
            _panelBlock.SetActive(true);
            _slcManager.Selecting = false;
        }
    }

    public void ClosePanel()
    {
        if (_panel != null)
        {
            _panel.SetActive(false);
            _panelBlock.SetActive(false);
            _slcManager.Selecting = true;
        }
        CleanInputField();
    }

    public void StoreInfo()
    {
        _userInfo = new UserInfo(_inputName.text, _inputUse.text, Time.time.ToString(), _slcManager.ElementStates);
        //_userInfo.SaveToFile();
        _userInfo.PrintData();

        //Debug.Log($"O nome é {_name} e essa pessoa quer {_use}");
        CleanInputField();
    }

    public void CleanInputField()
    {
        _inputName.text = "";
        _inputUse.text = "";
    }
}
