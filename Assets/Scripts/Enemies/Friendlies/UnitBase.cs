using System.Net.NetworkInformation;
using UnityEngine;

public class UnitBase : MonoBehaviour { 

    public GameObject unitPrefab;
    protected Vector3 SpawnPoint = new Vector3(31.5f, 0f, 8.5f) ;//Can only spawn in main castle 
    public int health;
    public float coolDown = 0;
    int dif;

    protected virtual void Start()
    {
        dif = GameManager.Instance.DifficultyScale;
    }

    public virtual void Initialize(int startHealth, float startCooldown)
    {
        health = startHealth/ dif; // divides because friendly units are weaker on harder difficulties
        coolDown = startCooldown*dif;
    }

    public virtual void SpawnUnit()
    {
        Instantiate(unitPrefab, SpawnPoint, Quaternion.identity);
    }


}

