using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Saver : MonoBehaviour {

    public static string CharacterList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_";
    public string[] Usernames = new string[] { "lukecashwell","The_Bestest","Tester" };
    public string[] Passwords = new string[] { "duck", "hello", "10" };
    [MenuItem("Tools/Write file")]
    void Start()
    {
        int iter = -1;
        foreach (string s in Usernames)
        {
            iter++;
            if (!IsUsername(s))
            {
                AddUsername(s);
                AddPassword(Passwords[iter]);
            }
        }
    }
    //---------------------
    public static string GetPassword(string username)
    {
        string path = "Assets/SaveFile/Usernames.txt";
        string Passpath = "Assets/SaveFile/Passwords.txt";
        int Start = 0;
        int iteration = 0;
        string CheckName = "";
        string CheckChar = "";
        StreamReader reader = new StreamReader(path);
        string usernamelist = reader.ReadToEnd();
        reader.Close();
        int UsernameID = 0;
        bool check = true;
        while (check)
        {
            UsernameID++;
            Start = iteration;
                for (int i = Start; usernamelist[i].ToString() != "~" && check; i++)
                {
                    iteration = i;
                    if (usernamelist[i].ToString() != "-" && usernamelist[i].ToString() != "~") CheckChar += usernamelist[i]; else { CheckName += CharacterList[int.Parse(CheckChar)]; CheckChar = ""; }
                }
                iteration += 2;
                if (CheckName == username)
                {
                    check = false;
                }
                 Debug.Log(CheckName);
                 CheckName = "";

        }

        reader = new StreamReader(Passpath);
        string passwordlist = reader.ReadToEnd();
        reader.Close();
        Debug.Log(UsernameID);
        CheckChar = "";
        for (int i = 0, j = 0; j < UsernameID; i++)
        {
            try
            {
                if (passwordlist[i].ToString() == "~")
                {
                    j++;
                }
            }
            catch { }
            if (passwordlist[i].ToString() != "-" && passwordlist[i].ToString() != "~") CheckChar += passwordlist[i]; else { if (passwordlist[i].ToString() != "~") CheckName += CharacterList[int.Parse(CheckChar)]; else if (j < UsernameID)CheckName = ""; CheckChar = ""; }
            Debug.Log(CheckName);
        }
        return CheckName;

    }

    //--------------------
    public static void AddPassword(string password)
    {

        bool DontWrite = false;
        string EncryptUser = "";
        string path = "Assets/SaveFile/Passwords.txt";

        int j = -1;
        foreach (char c in password)
        {
            j++;
            bool didEqual = false;
            for (int i = 0; i < CharacterList.Length; i++)
            {
                if (CharacterList[i] == c)
                {
                    didEqual = true;
                    EncryptUser += EncryptUser == "" ? i.ToString() : (j < password.Length - 1 ? "-" + i.ToString() : "-" + i.ToString() + "-~");

                }
            }
            Debug.Log(EncryptUser);
            if (!didEqual)
            {
                DontWrite = true;
            }
        }

        if (!DontWrite)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(EncryptUser);
            writer.Close();
            AssetDatabase.ImportAsset(path);
        }


    }

    public static bool IsUsername(string username)
    {
        string path = "Assets/SaveFile/Usernames.txt";
        int Start = 0;
        int iteration = 0;
        string CheckName = "";
        string CheckChar = "";
        if (username == "") return false;

        StreamReader reader = new StreamReader(path);
        string usernamelist = reader.ReadToEnd();
        if (usernamelist == "") return false;
        reader.Close();
        int UsernameID = 0;
        bool check = true;
        while (check)
        {
            UsernameID++;
            Start = iteration;
            try
            {

                for (int i = Start; usernamelist[i].ToString() != "~" && check; i++)
                {
                    iteration = i;
                    if (usernamelist[i].ToString() != "-" && usernamelist[i].ToString() != "~") CheckChar += usernamelist[i]; else { CheckName += CharacterList[int.Parse(CheckChar)]; CheckChar = ""; }
                    if (i >= usernamelist.Length) { return false; };
                }
                iteration += 1;
                if (CheckName == username)
                {
                    return true;
                }
                CheckName = "";
            }
            catch
            {
                return false;
            }
            
        }
        return false;
    }

    public static void AddUsername(string username)
    {
        bool DontWrite = false;
        string EncryptUser = "";
        string path = "Assets/SaveFile/Usernames.txt";

        int j = -1;
        foreach(char c in username)
        {
            j++;
            bool didEqual = false;
            for (int i = 0; i < CharacterList.Length; i++)
            {
                if (CharacterList[i] == c)
                {
                    didEqual = true;
                    EncryptUser += EncryptUser == "" ? i.ToString() : (j < username.Length - 1 ? "-" + i.ToString() : "-" + i.ToString() + "-~");

                }
            }
            Debug.Log(EncryptUser);
            if (!didEqual)
            {
                DontWrite = true;
            }
        }

        if (!DontWrite)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(EncryptUser);
            writer.Close();
            AssetDatabase.ImportAsset(path);
        }

    }
}
