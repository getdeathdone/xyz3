using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class Cheat : MonoBehaviour
{   

    [SerializeField] private float _inputTimeToLive;
    [SerializeField] private CheatItem[] _cheats;

    private string _currrentInput;
    private float _inputTime;

    private void Awake()
    {
        Keyboard.current.onTextInput += OnTextInput;
    }

    private void OnDestroy()
    {
        Keyboard.current.onTextInput -= OnTextInput;
    }

    private void OnTextInput(char inputChar)
    {   
        _currrentInput += inputChar;
        _inputTime = _inputTimeToLive;
        FindAnyCheath();
    }

    private void FindAnyCheath()
    {
        foreach (var cheatItem in _cheats)
        {
            if(_currrentInput.Contains(cheatItem.Name))
            {
                cheatItem.Action.Invoke();
                _currrentInput = string.Empty;
            }
        }
    }

    private void Update()
    {
        if (_inputTime < 0)
        {
            _currrentInput = string.Empty;
        }
        else
        {
            _inputTime -= Time.deltaTime;
        }
    }

[Serializable]
public class CheatItem
{
    public string Name;
    public UnityEvent Action;
}

}

