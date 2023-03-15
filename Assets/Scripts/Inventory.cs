using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // 0 = primary, 1 = secondary, 2 = melee
    [SerializeField] private Weapon[] weapons;

    private WeaponShooting shooting;
    private HUD hud;

    void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void InitVariables()
    {
        weapons = new Weapon[3];
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;

        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;

        hud.UpdateWeaponUI(newItem);

        shooting.InitAmmo((int)newItem.weaponStyle, newItem);
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void GetReferences()
    {
        hud = GetComponent<HUD>();
        shooting = GetComponent<WeaponShooting>();
    }
}
