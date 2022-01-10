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

        //lista pra pegar apenas os elementos selecionados 
        List<string> selected = new List<string>();
        foreach (KeyValuePair<string, bool> pair in _selected)
        {
            //pair.value semelhante à pair.value = true
            if (pair.Value) selected.Add(pair.Key);
        }

        //texto com os elementos selecionados
        var selectedString = String.Join(",", selected);


        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine($"01:{_name}");
            sw.WriteLine($"02:{_use}");
            sw.WriteLine($"03:{_why}");
            sw.WriteLine($"04:{selectedString}");
            sw.WriteLine($"05:{System.DateTime.Now}");
            sw.WriteLine($"06:{_time};");
        }
    }
}
