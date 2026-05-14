using UnityEngine;

public class Swordsman : UnitBase
{
    protected override void Start()
    {
        base.Start();
        Initialize(100, 1.5f);
    }
}