using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    private string _name;
    private string _use;
    private Dictionary<string, bool> _selected;
    private string _time;

    public UserInfo(string name, string use, string time, Dictionary<string, bool> selected)
    {
        _name = name;
        _use = use;
        _time = time;
        _selected = selected;
        _selected = selected;
    }

    public void SaveToFile()
    {
        // Write data to file
    }

    public void PrintData()
    {
        Debug.Log($"O nome é {_name} e essa pessoa quer {_use}");
    }
}
