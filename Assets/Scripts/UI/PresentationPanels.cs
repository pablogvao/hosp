using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationPanels : MonoBehaviour
{
    private GameObject _context;
    private GameObject _earth;
    private GameObject _terrain;
    private GameObject _masks;

    private int _currentPanel;

    public void Awake()
    {
        _context = transform.Find("Context").gameObject;
        _context.SetActive(false);
        _earth = transform.Find("Earth").gameObject;
        _earth.SetActive(false);
        _terrain = transform.Find("Terrain").gameObject;
        _terrain.SetActive(false);
        _masks = transform.Find("Masks").gameObject;
        _masks.SetActive(false);
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
                _context.SetActive(true);
                break;
            case 2:
                _earth.SetActive(true);
                break;
            case 3:
                _terrain.SetActive(true);
                _masks.SetActive(true);
                break;
        }
    }

    public void AdvancePanel()
    {
        _currentPanel++;
        SetNextPanel(_currentPanel);
    }
}
