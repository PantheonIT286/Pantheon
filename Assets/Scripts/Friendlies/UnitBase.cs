using UnityEngine;

public class UnitBase : MonoBehaviour { 

    public GameObject unitPrefab;
    protected Vector3 SpawnPoint = new Vector3(31.5f, 0f, 8.5f) ;//Can only spawn in main castle 
    public int health;
    public float coolDown = 0;
    int dif;




}

