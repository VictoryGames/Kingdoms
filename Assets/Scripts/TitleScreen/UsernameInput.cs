using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour {

    public static string Username = "";
    public static string Password = "";
    public static bool CanLogin = false;

    public void setUsername()
    {
        Username = GetComponent<Text>().text;
    }
    public void setPassword()
    {
        Password = GetComponent<Text>().text;
    }
    public static void CheckLogin()
    {
        if (Saver.IsUsername(Username))
        {
            Debug.Log("hello");
            if (Saver.GetPassword(Username) == Password)
            {
                CanLogin = true;
            }
            else
            {
                CanLogin = false;
                Debug.Log("hello2");
            }
        }
        else
        {
            Debug.Log("hello");
            CanLogin = false;
        }
    }
}
