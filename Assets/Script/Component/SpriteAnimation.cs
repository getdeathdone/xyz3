using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]

public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private UnityEvent _onComplite;

    private SpriteRenderer _renderer; // рендерер
    private float _nextFrameTime; // время до следующего update 
    private float _secondPerFrame; // секунды на показ одного спрайта 
    private int _currentSpriteIndex; // текущий индекс нашего спрайта 

    private void Start()
    {   
        _renderer = GetComponent<SpriteRenderer>(); 
    }

    private void OnEnable()
    {
        _secondPerFrame = 1f / _frameRate; // расчитываем сколько времени будет длится 1 кадр 
        _nextFrameTime = Time.time + _secondPerFrame; // задаем следующий update нашего кадра 
        _currentSpriteIndex = 0; // сбрасываем индекс спрайтов на ноль
    }
    
    private void Update()
    {
        if(_nextFrameTime > Time.time) return; // проверяем наступило ли время слудующего кадра 
        
        if(_currentSpriteIndex >= _sprites.Length) // влазим ли мы в то количество спрайтов, которое у нас есть 
        {
            if(_loop) // если цикляящая анимация 
            {
                _currentSpriteIndex = 0; // сбрасываем индекс спрайтов на ноль
            }
            else 
            {
                enabled = false;
                _onComplite?.Invoke();
                return;
            }
        }

        _renderer.sprite = _sprites[_currentSpriteIndex]; // меняем спрайт 
        _nextFrameTime += _secondPerFrame; // обновляем время до следующего изменения 
        _currentSpriteIndex++; // слудующий раз устанавливаем следующий спрайт 
        
    }
    
}
