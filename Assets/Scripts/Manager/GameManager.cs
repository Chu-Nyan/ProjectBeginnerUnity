using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
    }
    public GameObject player;

    public RuntimeAnimatorController penquinController;
    public RuntimeAnimatorController KinghtController;
    public RuntimeAnimatorController WizzardController;
}
