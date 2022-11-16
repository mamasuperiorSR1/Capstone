using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Text magazineSizeText;
    [SerializeField] private Text storedAmmoText;

    public void UpdateInfo(int magazineSize, int storedAmmo)
    {
        magazineSizeText.text = magazineSize.ToString();
        storedAmmoText.text = storedAmmo.ToString();
    }

    public void UpdateAmmoUI(int magazineSize, int storedAmmo)
    {
        magazineSizeText.text = magazineSize.ToString();
        storedAmmoText.text = storedAmmo.ToString();
    }
}
