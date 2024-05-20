using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class DadosLogin
{
    public int id;
    public string username;

    public DadosLogin(int _id, string _username)
    {
        id = _id;
        username = _username;
    }
}
