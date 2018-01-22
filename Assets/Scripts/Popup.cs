using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {


    public int PopupStay;

    void FixedUpdate()
    {
        PopupStay--;
        if (PopupStay <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
