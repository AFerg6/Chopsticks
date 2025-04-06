using System;
using UnityEngine;

public class SpearBehaivourSCript : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody rb;
    private GameObject _player;
    private Collider myCollider;

    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false; // Allow physics-based collisions
        
        
        myCollider = GetComponent<Collider>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Ignore collisions between this object and all enemies
        foreach (GameObject enemy in enemies)
        {
            Collider enemyCollider = enemy.GetComponent<Collider>();
            if (enemyCollider != null)
            {
                Physics.IgnoreCollision(myCollider, enemyCollider);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            
            collision.gameObject.GetComponent<PlayerHealthScript>().HurtPlayer(damage);
            
        }
        
        // Debug.Log("Spear hit: " + collision.gameObject.name);
        
        if(!collision.gameObject.tag.Equals("Enemy")){
            Destroy(gameObject);
        }
    }
}
