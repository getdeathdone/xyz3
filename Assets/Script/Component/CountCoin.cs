using UnityEngine;

public class CountCoin : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    public void CountSilverCoin ()
    {
        _hero._heroSilverCoin += 1;
        Debug.Log($"SilverCoin = "+_hero._heroSilverCoin);        
    }
    public void CountGoldCoin ()
    {
        _hero._heroGoldCoin += 1;
        Debug.Log($"GoldCoin = "+_hero._heroGoldCoin);        
    }
}
