using System;
using System.Collections;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public float hRange = 2f;
    public float vRange = 0.5f;

    void Awake()
    {
        transform.localScale += new Vector3(hRange,vRange,0);
    }

    public void rankUp()
    {
        hRange += 1f;
        vRange += 0.2f;
    }
}
