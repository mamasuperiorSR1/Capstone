using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    private float lastShootTime = 0;

    [SerializeField] private bool canShoot = true;
    public bool canReload = true;
    private bool isReloading;
    public bool isSwitching;

    [SerializeField] private int primaryCurrentAmmo;
    [SerializeField] private int primaryCurrentAmmoStorage;

    [SerializeField] private int secondaryCurrentAmmo;
    [SerializeField] private int secondaryCurrentAmmoStorage;

    [SerializeField] private bool primaryMagazineIsEmpty = false;
    [SerializeField] private bool secondaryMagazineIsEmpty = false;

    [SerializeField] private AudioSource pistolsound;
    [SerializeField] private AudioSource arsound;
    [SerializeField] private AudioSource shotgunsound;
    public ParticleSystem MuzzleFlash = null;

    private Camera cam;
    private Inventory inventory;
    private EquipmentManager manager;
    private Animator anim;
    private HUD hud;
    private Recoil rs;

    void Start()
    {
        GetReferences();
        canShoot = true;
        canReload = true;
    }

    void Update()
    {
        updateWeaponUI(manager.currentlyEquippedWeapon);
        CheckCanShoot(manager.currentlyEquippedWeapon);
        if (canShoot && isReloading == false && isSwitching == false)
        {
            if (Input.GetKey(KeyCode.Mouse0) && (int)inventory.GetItem(0).fireMode == 1)
            {
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && (int)inventory.GetItem(0).fireMode == 0)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload(manager.currentlyEquippedWeapon));
        }
    }

    IEnumerator Muzzle()
    {
        MuzzleFlash.Play();
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.Stop();
    }
    private void Shoot()
    {
        Weapon currentWeapon = inventory.GetItem(manager.currentlyEquippedWeapon);

        if (Time.time > lastShootTime + currentWeapon.fireRate)
        {
            lastShootTime = Time.time;
            RaycastShoot(currentWeapon);
            rs.RecoilFire();
            UseAmmo((int)currentWeapon.weaponStyle, 1, 0);
            if (manager.currentWeaponAudio == 1)
            {
                pistolsound.Play();
            }
            if (manager.currentWeaponAudio == 2)
            {
                arsound.Play();
            }
            if (manager.currentWeaponAudio == 3)
            {
                shotgunsound.Play();
            }
            StartCoroutine(Muzzle());
        }
    }

    private void RaycastShoot(Weapon currentWeapon)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        float currentWeaponRange = currentWeapon.range;

        if (Physics.Raycast(ray, out hit, currentWeaponRange))
        {
            Debug.Log("hit"+hit.transform.name);

            if (hit.transform.tag == "Enemy")
            {
                CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();
                enemyStats.TakeDamage(currentWeapon.damage);
                //enemyStats.TakeDamage(10);
            }
        }
    }
    private void updateWeaponUI(int slot)
    {
        if (slot == 0)
        {
            hud.UpdateWeaponAmmoUI(primaryCurrentAmmo, primaryCurrentAmmoStorage);
        }
        if (slot == 1)
        {
            hud.UpdateWeaponAmmoUI(secondaryCurrentAmmo, secondaryCurrentAmmoStorage);
        }
    }
    private void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {
        //primary
        if (slot == 0)
        {
            if (primaryCurrentAmmo == 0)
            {
                primaryMagazineIsEmpty = true;
            }
            else
            {
                primaryCurrentAmmo -= currentAmmoUsed;
                primaryCurrentAmmoStorage -= currentStoredAmmoUsed;
            }
        }

        //secondary
        if (slot == 1)
        {
            if (secondaryCurrentAmmo == 0)
            {
                secondaryMagazineIsEmpty = true;
            }
            else
            {
                secondaryCurrentAmmo -= currentAmmoUsed;
                secondaryCurrentAmmoStorage -= currentStoredAmmoUsed;
            }
        }
    }

    public void InitAmmo(int slot, Weapon weapon)
    {
        //primary
        if (slot == 0)
        {
            primaryCurrentAmmo = weapon.magazineSize;
            primaryCurrentAmmoStorage = weapon.storedAmmo;
        }

        //secondary
        if (slot == 1)
        {
            secondaryCurrentAmmo = weapon.magazineSize;
            secondaryCurrentAmmoStorage = weapon.storedAmmo;
        }
    }

    private void CheckCanShoot(int slot)
    {
        if (slot == 0)
        {
            if (primaryCurrentAmmo < 1)
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }

        if (slot == 1)
        {
            if (secondaryCurrentAmmo < 1)
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }
    }
    IEnumerator Reload(int slot)
    {
        isReloading = true;
        if (slot == 0)
        {
            int ammoToReload = inventory.GetItem(0).magazineSize - primaryCurrentAmmo;

            if (primaryCurrentAmmoStorage >= ammoToReload)
            {
                if (primaryCurrentAmmo == inventory.GetItem(0).magazineSize)
                {
                    Debug.Log("Magazine is full.");
                }

                AddAmmo(slot, ammoToReload, 0);
                UseAmmo(slot, 0, ammoToReload);

                primaryMagazineIsEmpty = false;
            }
            else
            {
                ammoToReload = primaryCurrentAmmoStorage;
                AddAmmo(slot, ammoToReload, 0);
                UseAmmo(slot, 0, ammoToReload);

                primaryMagazineIsEmpty = false;
                Debug.Log("Loaded last mag");
            }
        }

        if (slot == 1)
        {
            int ammoToReload = inventory.GetItem(1).magazineSize - secondaryCurrentAmmo;

            if (secondaryCurrentAmmoStorage >= inventory.GetItem(1).magazineSize)
            {
                if (secondaryCurrentAmmo == inventory.GetItem(1).magazineSize)
                {
                    Debug.Log("Magazine is full.");
                }

                AddAmmo(slot, ammoToReload, 0);
                UseAmmo(slot, 0, ammoToReload);

                secondaryMagazineIsEmpty = false;
            }
            else
            {
                ammoToReload = secondaryCurrentAmmoStorage;
                AddAmmo(slot, ammoToReload, 0);
                UseAmmo(slot, 0, ammoToReload);

                secondaryMagazineIsEmpty = false;
                Debug.Log("Loaded last mag");
            }

        }
        anim.SetTrigger("reload");
        yield return new WaitForSeconds(3f);
        isReloading = false;
    }
    
    private void AddAmmo(int slot, int currentAmmoadded, int currentStoredAmmoAdded)
    {
        //primary
        if (slot == 0)
        {
            primaryCurrentAmmo += currentAmmoadded;
            primaryCurrentAmmoStorage += currentStoredAmmoAdded;
        }

        //secondary
        if (slot == 1)
        {
            secondaryCurrentAmmo += currentAmmoadded;
            secondaryCurrentAmmoStorage += currentStoredAmmoAdded;
        }
    }


    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
        anim = GetComponentInChildren<Animator>();
        hud = GetComponent<HUD>();
        rs = GetComponentInChildren<Recoil>();
    }
}
