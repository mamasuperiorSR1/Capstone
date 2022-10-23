using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text currentHealthT;
    [SerializeField] private Text maxHealthT;

    // private PlayerStats stats;

    void Start()
    {
        // stats = GetComponent<PlayerStats>();
    }


    void Update()
    {
        
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        currentHealthT.text = currentHealth.ToString();
        maxHealthT.text = maxHealth.ToString();
    }
}
