using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QSTXFrameWork.UI.MVP;

public class PlayerStats : CharacterStats
{
    private HUD hud;

 
    void Start()
    {
        hud = GetComponent<HUD>();
        InitVariables();
    }

    void Update()
    {
        /* Debug
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetDamage(10);
        }
        */
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        if (isDead)
        {
            UIContainer.Instance.Enter(UIVIewID.GameEndViewID);
        }
        hud.UpdateHealth(health, maxHealth);
    }
}
