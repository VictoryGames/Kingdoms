using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviors : MonoBehaviour
{

    public GameObject TitleScreen;
    public GameObject Warning;
    public GameObject LoginScreen;
    public GameObject SPCharacterSelectorMenu;


    //Title Buttons
    public void OnSingleplayerClick()
    {
        SPCharacterSelectorMenu.SetActive(true);
        foreach (InitBase i in InitBase.InitBases.Array) i.SingleplayerStart();
        TitleScreen.SetActive(false);
        GameTypes.PauseLayer = 1;
    }
    public void OnDungeonsClick()
    {
        foreach (InitBase i in InitBase.InitBases.Array) i.DungeonStart();
        TitleScreen.SetActive(false);
        GameTypes.PauseLayer--;
    }
    public void OnTrainingClick()
    {
        foreach (InitBase i in InitBase.InitBases.Array) i.TrainingStart();
        TitleScreen.SetActive(false);
        GameTypes.PauseLayer--;
    }
    public void OnShopClick()
    {
        foreach (InitBase i in InitBase.InitBases.Array) i.ShopStart();
        TitleScreen.SetActive(false);
        GameTypes.PauseLayer--;
    }

    //Login Buttons
    public void OnLoginClick()
    {
        UsernameInput.CheckLogin();
        if (UsernameInput.CanLogin)
        {
            LoginScreen.SetActive(false);
        }
        else
        {
            Warning.SetActive(true);
        }
    }

    //SPCharacterSelector
    public void OnCharacterSelect()
    {
        SPCharacterSelectorMenu.SetActive(false);
        GameTypes.PauseLayer--;
    }

}
