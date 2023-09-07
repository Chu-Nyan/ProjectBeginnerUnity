using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum SpriteType
{
    Penguin,
    Knight,
    Wizzard
}

public class Player : MonoBehaviour
{
    private Animator myAnimator;
    private TextMeshProUGUI nameUI;

    [SerializeField] private string myName = "";
    [SerializeField] private SpriteType spriteType;

    public string Name 
    { 
        get { return myName; } 
        set 
        { 
            myName = value;
            ChangeName();
        } 
    }

    public SpriteType SpriteType
    {
        get { return spriteType; }
        set
        {
            spriteType = value;
            ChangeSprite();
        }
    }

    public void Awake()
    {
        nameUI = transform.Find("UI").gameObject.transform.Find("NameTxt").gameObject.GetComponent<TextMeshProUGUI>();
        myAnimator = transform.Find("MainSprite").gameObject.GetComponent<Animator>();
    }


    void Start()
    {
        GetComponent<Player>().Name = PlayerPrefs.GetString("Name");
        GetComponent<Player>().SpriteType = (SpriteType)PlayerPrefs.GetInt("SpriteType");
    }

    void ChangeSprite() 
    {
        switch(spriteType)
        {
            case SpriteType.Penguin:
                myAnimator.runtimeAnimatorController = GameManager.GM.penquinController;
                break;
            case SpriteType.Knight:
                myAnimator.runtimeAnimatorController = GameManager.GM.KinghtController;
                break;
            case SpriteType.Wizzard:
                myAnimator.runtimeAnimatorController = GameManager.GM.WizzardController;
                break;

        }
    }

    void ChangeName()
    {
        nameUI.text = Name;
    }
}
