using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    private EquipmentManager manager;
    private Inventory inventory;

    private float recoil_x;
    private float recoil_y;
    private float recoil_z;

    private float snap;
    private float rs;
    void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        if(manager.currentWeaponObject != null)
        {
            SetRecoil();
        }
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, rs * Time.deltaTime);
        currentRotation = Vector3.Lerp(currentRotation, targetRotation, snap * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }
    public void SetRecoil()
    {
        recoil_x = inventory.GetItem(manager.currentlyEquippedWeapon).recoilX;
        recoil_y = inventory.GetItem(manager.currentlyEquippedWeapon).recoilY;
        recoil_z = inventory.GetItem(manager.currentlyEquippedWeapon).recoilZ;
        snap = inventory.GetItem(manager.currentlyEquippedWeapon).snappiness;
        rs = inventory.GetItem(manager.currentlyEquippedWeapon).returnSpeed;
    }    
    public void RecoilFire()
    {
        targetRotation += new Vector3(Random.Range(-recoil_x, recoil_x), Random.Range(-recoil_y, recoil_y), Random.Range(-recoil_z, recoil_z));
    }
    private void GetReferences()
    {
        manager = GetComponentInParent<EquipmentManager>();
        inventory = GetComponentInParent<Inventory>();
    }
}
