using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // 0 = primary, 1 = secondary, 2 = melee
    [SerializeField] private Weapon[] weapons;

    void Start()
    {
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
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }
}
