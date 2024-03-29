using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentlyEquippedWeapon = 2;
    public GameObject currentWeaponObject = null;
    public Transform currentWeaponBarrel = null;
    public int currentWeaponAudio;
    public int FireMode;

    public Transform WeaponHolderR = null;
    private Animator anim;
    public Animator currentWeaponAnim;
    private Inventory inventory;
    private HUD hud;
    private WeaponShooting shooting;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquippedWeapon != 0)
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentlyEquippedWeapon != 1)
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(1));
        }
    }

    public IEnumerator Switching()
    {
        shooting.isSwitching = true;
        yield return new WaitForSeconds(3f);
        shooting.isSwitching = false;
    }

    public void EquipWeapon(Weapon weapon)
    {
        currentlyEquippedWeapon = (int)weapon.weaponStyle;
        currentWeaponAudio = (int)weapon.weaponType;
        if ((int)weapon.fireMode == 0)
        {
            FireMode = 0;
        }
        if ((int)weapon.fireMode == 1)
        {
            FireMode = 1;
        }
        anim.SetInteger("weaponType", (int)weapon.weaponType);
        hud.UpdateWeaponUI(weapon);
    }
    
    public void UnequipWeapon()
    {
        anim.SetTrigger("unequipWeapon");
    }

    private void GetReferences()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
        hud = GetComponent<HUD>();
    }
}
