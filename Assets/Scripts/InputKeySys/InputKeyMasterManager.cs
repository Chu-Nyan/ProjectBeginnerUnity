using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputKeyMasterManager : MonoBehaviour
{
    public static InputKeyMasterManager IMM;
    private void Awake()
    {
        if (IMM != null)
        {
            Destroy(this);
            return;
        }
        IMM = this;
    }

    public PlayerInput keyController;

    public event Action<Vector2> MoveEventHandller;
    public event Action<Vector2> LookEventHandller;
    public event Action InteractionEventHandller;
    public event Action OnNextTalkEventHandller;

    public void ChangeTalkActionMap()
    {
        keyController.SwitchCurrentActionMap("Talk");
    }

    public void ChangeUnitActionMap()
    {
        keyController.SwitchCurrentActionMap("Unit");
    }

    public void OnMove(InputValue movePos)
    {
        MoveEventHandller?.Invoke(movePos.Get<Vector2>());
    }

    public void OnLook(InputValue movePos)
    {
        LookEventHandller?.Invoke(movePos.Get<Vector2>());
    }

    public void OnInteraction()
    {
        Debug.Log("OnInteraction");
        InteractionEventHandller?.Invoke();
    }
    public void OnNextTalk()
    {
        Debug.Log("OnNextTalk");
        OnNextTalkEventHandller?.Invoke();
    }
}