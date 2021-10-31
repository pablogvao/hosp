using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

        //verificar se o caminho existe
        if (!File.Exists(path)) { File.WriteAllText(path, "infos: \n\n"); }

        //conteúdo
        File.AppendAllText(path,
            $"name: {_name}; \n" +
            $"suggested use: {_use}; \n" +
            $"why: {_why}; \n" +
            $"selected elements: {_selected}; \n\n" +

            $"date: {System.DateTime.Now}; \n" +
            $"in time: {_time}s;");
        }
}
