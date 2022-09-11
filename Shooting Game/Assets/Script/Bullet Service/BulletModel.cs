using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float timeToDisable {get; private set;}
    public int bulletDamage { get; private set; }

    public BulletModel()
    {
       timeToDisable = 2;
       bulletDamage = 10;
    } 
}
