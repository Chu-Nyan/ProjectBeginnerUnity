using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputKeyManager : MonoBehaviour
{
    InputKeyMasterManager masterManager;
    Camera myCamera;
    Rigidbody2D myRigidbody;
    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;
    Vector3 AddmovePos = Vector3.zero;

    [SerializeField]
    float Speed = 3.0f;

    private void Awake()
    {
        myCamera = Camera.main;
        myRigidbody = GetComponent<Rigidbody2D>();
        masterManager = GameObject.Find("GameManagers").GetComponent<InputKeyMasterManager>();
        mySpriteRenderer = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        myAnimator = transform.Find("MainSprite").GetComponent<Animator>();
    }

    public void Start()
    {
        masterManager.MoveEventHandller += PlayerMove;
        masterManager.LookEventHandller += PlayerLook;
    }

    private void LateUpdate()
    {
        myAnimator.SetFloat("isMove", myRigidbody.velocity.magnitude);
    }

    void PlayerMove(Vector2 movePos)
    {
        AddmovePos = movePos.normalized;
        myRigidbody.velocity = Speed * AddmovePos;

    }

    void PlayerLook(Vector2 movePos)
    {
        Vector3 cusorPos = myCamera.ScreenToWorldPoint(movePos);
        Vector3 myPos = transform.position;
        float rotate = Mathf.Atan2(cusorPos.y - myPos.y, cusorPos.x - myPos.x) * Mathf.Rad2Deg;

        if (Math.Abs(rotate)  >= 90 && mySpriteRenderer.flipX == false)
        {
            mySpriteRenderer.flipX = true;
        }
        else if (Math.Abs(rotate) <= 90  && mySpriteRenderer.flipX == true)
        {
            mySpriteRenderer.flipX = false;
        }
    }


}
