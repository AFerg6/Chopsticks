using UnityEditor;
using UnityEngine;

public class DirtScript : MonoBehaviour, IBlastable
{
    public int maxBlastsToDestroy;

    private int currentBlastsToDestroy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBlastsToDestroy = maxBlastsToDestroy;
    }

    public void Blast()
    {
        currentBlastsToDestroy--;
        if(currentBlastsToDestroy <= 0)
            Destroy(transform.parent.gameObject);
        
        float reductionScale = 1 - (1f / maxBlastsToDestroy);
        transform.localScale = new Vector3(transform.localScale.x * reductionScale, transform.localScale.y,
            transform.localScale.z * reductionScale);
    }
}
