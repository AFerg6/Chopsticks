using UnityEngine;

public class BlastScript : Cooldown
{
    public double maxCooldown = 5;
    public float blastForce = 3;
    public float blastRadius = 3;

    private double currentCooldown = 0;

    private Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown < maxCooldown)
            currentCooldown += Time.deltaTime;

        if (Input.GetButtonDown("Fire2") && currentCooldown >= maxCooldown)
            blast();
    }

    private void blast()
    {
        currentCooldown = 0;
        RaycastHit hit;
        Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit);

        if(hit.transform)
        {
            Collider[] colliders = Physics.OverlapSphere(hit.transform.position, blastRadius);
            foreach (Collider c in colliders)
            {
                Rigidbody rb = c.attachedRigidbody;
                EnemyMovementScript ems = c.gameObject.GetComponent<EnemyMovementScript>();
                IBlastable blastable = c.gameObject.GetComponent<IBlastable>();
                if(rb)
                    rb.AddExplosionForce(blastForce, hit.transform.position, blastRadius, 3);
                if(ems)
                    ems.freeze(0.5f);
                if(blastable != null)
                    blastable.Blast();
            }
        }
    }
    
    //For cooldown UI: GetMaxValue should be the full charge value and GetCurrentValue should be the current value
    public override double GetMaxValue()
    {
        return maxCooldown;
    }

    public override double GetCurrentValue()
    {
        return currentCooldown;
    }
}
