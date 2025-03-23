using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovementScript : MonoBehaviour
{
    public float maxSpeed;
    private float _speed;
    
    private Collider[] _hitColliders;
    private RaycastHit _hit;

    public float sightRange;
    
    public Rigidbody rb;
    public GameObject target;

    private bool _seePlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = maxSpeed;
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // detect any players in range
        if (Physics.Raycast(transform.position, target.transform.position - transform.position, out _hit, sightRange))
        {
            if (!_hit.collider.gameObject.CompareTag("Player"))
            {
                _seePlayer = false;
                rb.linearVelocity = Vector3.zero;
            }
            else
            {
                _seePlayer = true;
                var heading = target.transform.position - transform.position;
                var distance = heading.magnitude;
                var direction = heading / distance;
                
                //move to the player
                Vector3 move = new Vector3(direction.x * _speed, 0, direction.z * _speed);
                rb.linearVelocity = move;
                transform.forward = move;
            }
        }
        
    }

    public bool CanSeePlayer()
    {
        return _seePlayer;
    }
}
