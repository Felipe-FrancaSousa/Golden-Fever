using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SavingSystem : MonoBehaviour
{
    const string nomePasta = "Golden Fever";
    const string extensaoArquivo = ".ea";

  public static void Salvar(GameObject player, Health health, ScriptArma arma, string fase, int pontos)
    {
        string caminhoPasta = Path.Combine(Application.persistentDataPath, nomePasta);
        if (!Directory.Exists(caminhoPasta))
        {
            Directory.CreateDirectory(caminhoPasta);
        }

        string caminhoDados = Path.Combine(caminhoPasta, "GFsave" + extensaoArquivo);

        BinaryFormatter bf = new BinaryFormatter();

        DadosPlayer dadosPlayer = new DadosPlayer(player, health, arma, fase, pontos);
        using(FileStream fileStream = File.Open (caminhoDados, FileMode.OpenOrCreate))
        {
            bf.Serialize(fileStream, dadosPlayer);
        }
    } 

    public static DadosPlayer Carregar()
    {
       

        BinaryFormatter bf = new BinaryFormatter();
        string caminhoPasta = Path.Combine(Application.persistentDataPath, nomePasta);

        string caminho = Path.Combine(caminhoPasta, "GFsave" + extensaoArquivo);

        if (File.Exists(caminho))
        {
            using (FileStream fileStream = File.Open(caminho, FileMode.Open)){
            return (DadosPlayer)bf.Deserialize(fileStream);
        }
        }
        else
        {
            return null;
        }
        

    }

    public static string GerarCaminhos()
    {
        string caminhoPasta = Path.Combine(Application.persistentDataPath, nomePasta);
        string caminho = Path.Combine(caminhoPasta, "GFsave" + extensaoArquivo);
        return caminho;

    }

    public static void SalvarLogin(int id, string username)
    {
        string caminhoPasta = Path.Combine(Application.persistentDataPath, nomePasta);
        if (!Directory.Exists(caminhoPasta))
        {
            Directory.CreateDirectory(caminhoPasta);
        }

        string caminhoDados = Path.Combine(caminhoPasta, "LoginSave" + extensaoArquivo);

        BinaryFormatter bf = new BinaryFormatter();

        DadosLogin dadosLogin = new DadosLogin(id, username);
        using (FileStream fileStream = File.Open(caminhoDados, FileMode.OpenOrCreate))
        {
            bf.Serialize(fileStream, dadosLogin);
        }
    }

    public static DadosLogin CarregarLogin()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string caminhoPasta = Path.Combine(Application.persistentDataPath, nomePasta);

        string caminho = Path.Combine(caminhoPasta, "LoginSave" + extensaoArquivo);

        if (File.Exists(caminho))
        {
            using (FileStream fileStream = File.Open(caminho, FileMode.Open))
            {
                return (DadosLogin)bf.Deserialize(fileStream);
            }
        }
        else
        {
            return null;
        }
    }

}