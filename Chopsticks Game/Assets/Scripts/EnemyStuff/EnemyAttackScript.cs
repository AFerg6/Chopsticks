using System;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    [Tooltip("The amount of damage to deal to the player on contact")]
    public int contactDamage;
    
    public bool ranged = false;

    [Tooltip("The amount of time between ranged attacks. Is ignored if ranged is false")]
    public float cooldown;
    [Tooltip("Object to use as a projectile. Is ignored if ranged is false")]
    public GameObject projectile;

    private float _lastAttackTime;
    
    private EnemyMovementScript _movementScript;
    private GameObject _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movementScript = GetComponent<EnemyMovementScript>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_movementScript.CanSeePlayer() && Time.time > _lastAttackTime + cooldown && ranged)
        {
            AttackPlayer();
            _lastAttackTime = Time.time;
        }
    }

    private void AttackPlayer()
    {
        Vector3 look = _player.transform.position;
        look.y = transform.position.y;
        transform.LookAt(look);
        
        Rigidbody rb = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 32f, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerHealthScript>().HurtPlayer(contactDamage);
            _movementScript.freeze(0.5f);
        }
    }
}
