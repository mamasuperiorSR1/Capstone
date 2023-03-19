using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject prefab;
    public int damage;
    public int magazineSize;
    public int storedAmmo;
    public float fireRate;
    public float range;
    public WeaponType weaponType;
    public WeaponStyle weaponStyle;
    public FireMode fireMode;

    public float recoilX;
    public float recoilY;
    public float recoilZ;
    public float snappiness;
    public float returnSpeed;
}

public enum WeaponType { Melee, Pistol, AR, Shotgun, Sniper}
public enum WeaponStyle { Primary, Secondary, Melee}
public enum FireMode { Semi, Auto }