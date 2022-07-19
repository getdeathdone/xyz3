using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swich : MonoBehaviour
{
    [SerializeField] private Animator _animatorSwich;
    [SerializeField] private bool _state;
    [SerializeField] private string _animationKey;

    public void Switch()
    {
        _state = !_state;
        _animatorSwich.SetBool(_animationKey, _state);
    }
    
    [ContextMenu("Switch")]
    public void SwitchIn()
    {
        Switch();
    }
}
