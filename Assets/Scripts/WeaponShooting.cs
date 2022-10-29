using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    private Camera cam;
    private Inventory inventory;
    private EquipmentManager manager;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastShoot();
    }

    private void RaycastShoot()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        float currentWeaponRange = inventory.GetItem(manager.currentlyEquippedWeapon).range;

        if (Physics.Raycast(ray, out hit, currentWeaponRange))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.tag == "Enemy")
            {
                CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();
                //enemyStats.TakeDamage(currentWeapon.damage);
                enemyStats.TakeDamage(10);
            }
        }
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
    }
}
