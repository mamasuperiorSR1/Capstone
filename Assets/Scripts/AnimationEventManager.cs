using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private Equipment manager;
    private Inventory inventory;
    //private EquipmentManager manager;

    private void Start()
    {
        GetReferences();
    }

    public void DestroyWeapon()
    {
        Destroy(manager.currentWeaponObject);
    }

    public void InstantiateWeapon()
    {
        manager.currentWeaponObject = Instantiate(inventory.GetItem(manager.currentlyEquippedWeapon).prefab, manager.WeaponHolderR);
    }

    public void GetReferences()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<Equipment>();
    }
}
