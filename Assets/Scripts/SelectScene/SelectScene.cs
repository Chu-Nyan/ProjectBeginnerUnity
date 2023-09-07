using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ButtonType
{
    LeftArrow,
    RightArrow,
    StartBtn
}

public class SelectScene : MonoBehaviour
{
    [SerializeField]
    GameObject Characters;
    [SerializeField]
    List<Transform> childCharacter;
    [SerializeField]
    TMP_InputField nameTxt;
    
    int SelectNum = 0;
    [SerializeField]
    float camSpd = 20;
    [SerializeField]
    GameObject Bg;

    Camera cam;

    public void Start()
    {
        for (int i = 0; i < Characters.transform.childCount; i++)
        {
            childCharacter.Add(Characters.transform.GetChild(i));
        }
        cam = Camera.main;

    }

    public void LateUpdate()
    {
        if (Math.Abs((SelectNum * 15) - cam.transform.position.x) <= 0.1f)
            return;

        if (SelectNum * 15 < cam.transform.position.x)
        {
            cam.transform.position += camSpd * Time.deltaTime * Vector3.left;

        }
        else if (SelectNum * 15 > cam.transform.position.x)
        {
            cam.transform.position += camSpd * Time.deltaTime * Vector3.right;
        }
    }

    public void ClickBranch(ButtonType btn)
    {
        switch (btn)
        {
            case ButtonType.LeftArrow:
                ClickLeftArrow();
                break;
            case ButtonType.RightArrow:
                ClickRightArrow();
                break;
            case ButtonType.StartBtn:
                ClickStartBtn();
                break;
            default:
                break;
        }
    }

    public void ClickLeftArrow()
    {
        SelectNum--;
        if (SelectNum < 0)
            SelectNum = childCharacter.Count - 1;
    }

    public void ClickRightArrow()
    {
        SelectNum++;
        if (SelectNum >= childCharacter.Count)
            SelectNum = 0;
    }

    public void ClickStartBtn()
    {
        PlayerPrefs.SetString("Name", nameTxt.text);
        PlayerPrefs.SetInt("SpriteType", SelectNum);
        SceneManager.LoadScene("GameScene");
    }
}
