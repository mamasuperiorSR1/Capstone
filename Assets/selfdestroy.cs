using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestroy : MonoBehaviour
{
    [SerializeField] private AudioSource deathsound;
    [SerializeField] private AudioClip[] deathsoundArray;

    private void Awake()
    {
        deathsound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        int randomInt = Random.Range(1, deathsoundArray.Length);
        deathsound.clip = deathsoundArray[randomInt];
        deathsound.PlayOneShot(deathsound.clip);
        StartCoroutine(SelfDestruct());
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
