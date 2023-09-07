using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum NpcType
{
    Tutor1,
    Student1
}

public class NpcScript : MonoBehaviour
{
    [SerializeField] NpcType npcType;
    [SerializeField] string _name;
    GameObject interactionPopUI;
    
    private void Awake()
    {
        interactionPopUI = transform.Find("UI").gameObject.transform.Find("InteractionPopUp").gameObject;
    }

    private void Start()
    {
        transform.Find("UI").gameObject.transform.Find("NameTxt").gameObject.GetComponent<TextMeshProUGUI>().text = _name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactionPopUI.SetActive(true);
        InputKeyMasterManager.IMM.InteractionEventHandller += Interaction;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionPopUI.SetActive(false);
        InputKeyMasterManager.IMM.InteractionEventHandller -= Interaction;
        TalkManager.TM.EndTalk();
    }

    void Interaction()
    {
        TalkManager.TM.StartTalk(npcType);
    }
}
