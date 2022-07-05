using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage;

    public void ApplyDamage(GameObject target)
    {
        var healthComponent = target.GetComponent<Health>();
        if (healthComponent != null) 
        {
            healthComponent.ApplyDamage(_damage);
        }
    }
}
