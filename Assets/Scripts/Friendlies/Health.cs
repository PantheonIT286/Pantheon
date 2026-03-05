using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour //this is health taken from the entitys class
{
    public int DifficultyScale = 1;
    public int gold = 0;
    public int Level = 1; // Added missing Level variable



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get difficulty
    }
    public void Difficulty()
    {

    }


    public bool Alive(float Health)
    {
        if (Health > 0f)
        {
            return true;
        }
        else
        {
            if (gameObject.tag == "Enemy")//# Now how tf do I get the game object from the script its from here?
            {
                gold = gold + (3 * DifficultyScale * Level);//Why 3? no clue you can change it if you want once we figure out the ingame economy 
            }
            Destroy(gameObject);
            return false;
        }
    }

    public void Attacked(float Damage, float Health)
    {
    }
}
