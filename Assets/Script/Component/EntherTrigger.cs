using UnityEngine;
using UnityEngine.Events;

public class EntherTrigger : MonoBehaviour
{   
   [SerializeField] private string _tag;
   [SerializeField] private UnityEvent _action;

   private void OnTriggerEnter2D(Collider2D other) //получаем обьект с которым Trigger 
   {
     if(other.gameObject.CompareTag(_tag)) //gameObject с которым мы Trigger сравниваем с тегом(_tag) 
      {
         _action?.Invoke(); // выполняем event (_action ) ?если он есть в стеке
      }
   }
}
