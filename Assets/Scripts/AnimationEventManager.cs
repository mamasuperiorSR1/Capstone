using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private EquipmentManager manager;
    private Inventory inventory;
    private WeaponShooting shooting;
    private Weapon defaultWeapon = null;

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
        DestroyWeapon();
        manager.currentWeaponObject = Instantiate(inventory.GetItem(manager.currentlyEquippedWeapon).prefab, manager.WeaponHolderR);
        shooting.MuzzleFlash = manager.currentWeaponObject.transform.Find("WFX_MF FPS RIFLE1").GetComponent<ParticleSystem>();
        manager.currentWeaponBarrel = manager.currentWeaponObject.transform.GetChild(0);
        manager.currentWeaponAnim = manager.currentWeaponObject.GetComponent<Animator>();
    }

    public void StartReload()
    {
        shooting.canReload = false;
    }

    public void EndReload()
    {
        shooting.canReload = true;
    }


    public void GetReferences()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
        shooting = GetComponentInParent<WeaponShooting>();
    }
}
