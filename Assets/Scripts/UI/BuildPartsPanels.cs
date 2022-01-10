using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPartsPanels : MonoBehaviour
{
    private GameObject _gr01;
    private GameObject _gr02;
    private GameObject _gr03;
    private GameObject _gr04;
    private GameObject _gr05;


    private int _currentPanel;

    public void Awake()
    {
        _gr01 = transform.Find("GR01").gameObject;
        _gr01.SetActive(false);
        _gr02 = transform.Find("GR02").gameObject;
        _gr02.SetActive(false);
        _gr03 = transform.Find("GR03").gameObject;
        _gr03.SetActive(false);
        _gr04 = transform.Find("GR04").gameObject;
        _gr04.SetActive(false);
        _gr05 = transform.Find("GR05").gameObject;
        _gr05.SetActive(false);
    }
    void Start()
    {
        _currentPanel = 1;
        SetNextPanel(_currentPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetNextPanel(int num)
    {
        switch (num)
        {
            case 1:
                _gr01.SetActive(true);
                break;
            case 2:
                _gr02.SetActive(true);
                break;
            case 3:
                _gr03.SetActive(true);
                break;
            case 4:
                _gr04.SetActive(true);
                break;
            case 5:
                _gr05.SetActive(true);
                break;
        }
    }

    public void AdvancePanel()
    {
        _currentPanel++;
        SetNextPanel(_currentPanel);
    }
}
