using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class UserInfo
{
    private string _name;
    private string _use;
    private string _why;
    private Dictionary<string, bool> _selected;
    private string _time;

    //preciso verificar os itens do dicionario que são true

    public UserInfo(string name, string use, string why, string time, Dictionary<string, bool> selected)
    {
        _name = name;
        _use = use;
        _why = why;
        _time = time;
        _selected = selected;
    }

    public void SaveToFile()
    {
        //caminho e nome do arquivo
        string path = Application.dataPath + $"/{_name} file.txt";

        List<string> selected = new List<string>();
        foreach (KeyValuePair<string, bool> pair in _selected)
        {
            if (pair.Value) selected.Add(pair.Key);
        }

        var selectedString = String.Join(",", selected);


        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine($"infos:");
            sw.WriteLine($"name: {_name}");
            sw.WriteLine($"suggested use: {_use}");
            sw.WriteLine($"why: {_why}");
            sw.WriteLine($"selected elements: {selectedString}");
            sw.WriteLine();
            sw.WriteLine($"date: {System.DateTime.Now}");
            sw.WriteLine($"in time: {_time}s;");
        }
    }
}
