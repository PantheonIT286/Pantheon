using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/**
 So im thinking that all the units and bosses enemys and allies will use this file to do all the actual work the unit specific file will only hold their values so some of this code will be commented out just so it doesnt cause any
errors but after milestone 2 it should all be set
 * */
public class Main : MonoBehaviour //this is health taken from the entitys class
{
    public int DifficultyScale = GameManager.Instance.DifficultyScale;
    public int Level = GameManager.Instance.Level;
    public int Cooldown = 0;//If im correct each individual unit enemy or ally when spawned in will have their own version of this file so this way I dont have to keep pushing stuff from file to file

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
            if (gameObject.tag == "Enemy")
            {
                GameManager.Instance.Gold = GameManager.Instance.Gold + (3 * DifficultyScale * Level);//Why 3? no clue you can change it if you want once we figure out the ingame economy 
            }
            Destroy(gameObject);
            return false;
        }
    }

    public void Attacked(float Damage, float Health)
    {

        Health = Health - Damage;
        Alive(Health);
    }
    public void Attack(float Damage, GameObject Target)
    {
        // Target.UnitBase.Attacked(Damage, Target.UnitBase.Health);
    }
}