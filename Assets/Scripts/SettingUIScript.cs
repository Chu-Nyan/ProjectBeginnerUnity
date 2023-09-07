using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingUIScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject SettingUI;
    public GameObject CharacterImg;
    public TMP_InputField nameTxt;

    public Sprite[] Character = new Sprite[3];
    int selectNum;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SettingUI.activeInHierarchy == false)
        {
            OpenUI();
        }
        else
        {
            CloseUI();
        }
    }

    void OpenUI()
    {
        SettingUI.SetActive(true);

        nameTxt.text = GameManager.GM.player.GetComponent<Player>().Name;
        nameTxt.placeholder.gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.GM.player.GetComponent<Player>().Name;
        selectNum = (int)GameManager.GM.player.GetComponent<Player>().SpriteType;
        CharacterImg.GetComponent<Image>().sprite = Character[selectNum];
        CharacterImg.GetComponent<Image>().SetNativeSize();
        Time.timeScale = 0f;
    }

    void CloseUI()
    {
        SettingUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickLeft()
    {
        selectNum--;
        if (selectNum < 0)
            selectNum = Character.Length - 1;

        CharacterImg.GetComponent<Image>().sprite = Character[selectNum];
        CharacterImg.GetComponent<Image>().SetNativeSize();
    }

    public void ClickRight()
    {
        selectNum++;
        if (selectNum > 2)
            selectNum = 0;

        CharacterImg.GetComponent<Image>().sprite = Character[selectNum];
        CharacterImg.GetComponent<Image>().SetNativeSize();
    }

    public void ClickDecision()
    {
        GameManager.GM.player.GetComponent<Player>().Name = nameTxt.text;
        GameManager.GM.player.GetComponent<Player>().SpriteType = (SpriteType)selectNum;

        CloseUI();
    }




}
