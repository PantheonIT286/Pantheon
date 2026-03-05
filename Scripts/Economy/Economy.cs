using UnityEngine;

public class EconomyManager : MonoBehaviour 
{
    public int gold = 100; 

    void Start()
    {
        Debug.Log("<color=yellow>Game Started. Current Gold:</color> " + gold);
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("<color=yellow>Gained Gold! Current Gold:</color> " + gold);
    }
}