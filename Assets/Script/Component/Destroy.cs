using UnityEngine;

public class Destroy : MonoBehaviour
{
   [SerializeField] private GameObject _objectToDestroy;

   public void DestroyObject ()
   {
      Destroy(_objectToDestroy);
   }
}
