using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class EnterColision : MonoBehaviour
{
   [SerializeField] private string _tag;
   [SerializeField] private EnterEvent _action;

   private void OnCollisionEnter2D(Collision2D other) //получаем обьект с которым Colision 
   {
     if(other.gameObject.CompareTag(_tag)) //gameObject с которым мы Trigger сравниваем с тегом(_tag) 
      {
         _action?.Invoke(other.gameObject); // выполняем event (_action ) ?если он есть в стеке
      }
   }

   [Serializable]
   public class EnterEvent : UnityEvent<GameObject>
   {

   }
}
