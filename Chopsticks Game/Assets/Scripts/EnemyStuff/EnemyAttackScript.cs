using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public float attackRange = 10.0f;
    
    public bool ranged = false;

    public float cooldown = 2f;

    public float _lastAttackTime;
    public GameObject projectile;

    private EnemyMovementScript _movementScript;
    private GameObject _player;
    private bool _isAttacking;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movementScript = GetComponent<EnemyMovementScript>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_movementScript.CanSeePlayer() && Time.time > _lastAttackTime + cooldown )
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
}
