using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Shoot();
        }
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
    }
}
