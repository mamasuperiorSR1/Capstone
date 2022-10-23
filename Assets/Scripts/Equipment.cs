using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Transform WeaponHolderR = null;
    private Animator anim;
    private Inventory inventory;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeaponAnimations(0, WeaponType.AR);
            SetWeaponAnimations(0, WeaponType.Shotgun);
            SetWeaponAnimations(0, WeaponType.Sniper);

            EquipWeapon(inventory.GetItem(0).prefab, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeaponAnimations(1, WeaponType.Pistol);

            EquipWeapon(inventory.GetItem(1).prefab, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeaponAnimations(2, WeaponType.Melee);

            EquipWeapon(inventory.GetItem(2).prefab, 2);
        }
    }

    private void GetReferences()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }

    private void SetWeaponAnimations(int weaponStyle, WeaponType weaponType)
    {
        Weapon weapon = inventory.GetItem(weaponStyle);
        if (weapon != null)
        {
            if (weapon.weaponType == weaponType)
            {
                anim.SetInteger("weaponType", (int)weaponType);
            }
        }

    }

    private void EquipWeapon(GameObject weaponObject, int weaponStyle)
    {
        Weapon weapon = inventory.GetItem(weaponStyle);
        if (weapon != null)
        {
            Instantiate(weaponObject, WeaponHolderR);
        }

    }
}
