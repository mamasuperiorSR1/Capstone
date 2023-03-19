using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float stoppingDistance = 3;
    private float timeOfLastAttack = 0;
    private bool hasStopped = false;

    private NavMeshAgent agent = null;
    private Animator anim = null;
    private ZombieStats stats = null;
    private Transform target;

    [SerializeField] private AudioSource noise;
    [SerializeField] private AudioClip[] noiseArray;

    private void Awake()
    {
        noise = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GetReferences();
        StartCoroutine(makenoise());
    }

    private void Update()
    {
        MoveToTarget();
    }

    private IEnumerator makenoise()
    {
        int randomInt = Random.Range(1, noiseArray.Length);
        noise.clip = noiseArray[randomInt];
        noise.PlayOneShot(noise.clip);
        yield return new WaitForSeconds(10f);
    }

    private void MoveToTarget()
    {
        agent.SetDestination(new Vector3(target.position.x,0, target.position.z));
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
            //Attack
            if(!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }
            if (Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                AttackTarget(targetStats);
            }
        }
        else
        {
            if (hasStopped)
            {
                hasStopped = false;
            }
        }
    }

    private void RotateToTarget()
    {
        //transform.LookAt(target);

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("attack");
        stats.DealDamage(statsToDamage);
        //Debug.Log("Attacking");
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<ZombieStats>();
        target = PlayerController.instance;
    }
}
