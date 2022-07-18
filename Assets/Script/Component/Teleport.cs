using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _destinationTransform;

    public void Teleporting(GameObject target)
    {
        target.transform.position = _destinationTransform.position;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            Teleporting(other.gameObject);
    }
}
