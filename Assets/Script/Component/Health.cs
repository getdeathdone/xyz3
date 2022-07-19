using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] private UnityEvent _onDie;

    public void ApplyDamage(int damageValue)
    {
        _health -= damageValue;
        _onDamage?.Invoke();
        if(_health <= 0)
        {
            _onDie?.Invoke();
        }
    }
}
