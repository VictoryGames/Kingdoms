using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassTextSetter : MonoBehaviour {

    public Classes.enumClasses EnumClass;
    public GameObject Player;

    void Update()
    {
        GetComponent<Text>().text = Class.GetClass((int)EnumClass).Name;
    }

    public void SetClass()
    {
        Player.GetComponent<ClassComponent>().SelectedClass = Class.GetClass((int)EnumClass);
    }

}
