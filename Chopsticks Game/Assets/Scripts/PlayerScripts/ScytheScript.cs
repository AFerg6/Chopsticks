using UnityEngine;

public class ScytheScript : Cooldown
{
    public double cooldown;
    public float force;
    public float range;

    private double _currentCoolDown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_currentCoolDown < cooldown)
        {
            _currentCoolDown += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && _currentCoolDown >= cooldown)
        {
            Debug.Log("BIGG");
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            
            foreach (Collider e in colliders)
            {
                EnemyMovementScript enemy = e.gameObject.GetComponent<EnemyMovementScript>();
                
                if (enemy != null)
                {
                    e.gameObject.GetComponent<EnemyMovementScript>().freeze(0.5f);
                    e.gameObject.GetComponent<Rigidbody>().AddForce((e.transform.position - transform.position).normalized * force, ForceMode.Impulse);
                    
                }

                if (e.gameObject.tag == "TomatoPlant")
                {
                    Destroy(e.gameObject);
                }
            }
            
        }
    }
    
    //For cooldown UI: GetMaxValue should be the full charge value and GetCurrentValue should be the current value
    public override double GetMaxValue()
    {
        return cooldown;
    }

    public override double GetCurrentValue()
    {
        return _currentCoolDown;
    }
}
