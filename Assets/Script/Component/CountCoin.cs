using UnityEngine;

public class CountCoin : MonoBehaviour
{   
    [SerializeField] private GameObject _objectToCount;
    private int _count;

    public void CountObject ()
    {
        _count += 1;
        Debug.Log(_count);        
    }

}
