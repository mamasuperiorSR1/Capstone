using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    //private Animator ani;

    void Start()
    {
        //ani = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //SetAnimations(int weaponID, WeaponType weaponType)
        }
    }
    /*
    private void SetAnimations(int weaponID, WeaponType weaponType)
    {
        
        if (inventory.GetItem(weaponID).weaponType == weaponType)
        {
            ani.SetInteger("weaponType", (int)weaponType);
        }
        */
}
