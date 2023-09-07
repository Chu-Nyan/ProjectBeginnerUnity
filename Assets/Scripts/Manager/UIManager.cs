using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UM;

    void Awake()
    {
        if (UM != null)
            Destroy(this);

        UM = this;
    }
}
