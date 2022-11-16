using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text currentHealthT;
    [SerializeField] private Text maxHealthT;

    // private PlayerStats stats;


    [SerializeField] private WeaponUI weaponUI;

    void Start()
    {
        // stats = GetComponent<PlayerStats>();
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        currentHealthT.text = currentHealth.ToString();
        maxHealthT.text = maxHealth.ToString();
    }

    public void UpdateWeaponUI(Weapon newWeapon)
    {
        // If we have a icon
        // weaponUI.UpdateInfo(newWeapon.icon, newWeapon.magazineSize, newWeapon.storedAmmo);

        weaponUI.UpdateInfo(newWeapon.magazineSize, newWeapon.storedAmmo);
    }

    public void UpdateWeaponAmmoUI(int currentAmmo, int storedAmmo)
    {
        weaponUI.UpdateAmmoUI(currentAmmo, storedAmmo);
    }
}
