using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public int strength;
    public int constitution;
    public int intelligence;
    public int agility;
    public int speed;
    public int luck;
    public int hp;
    public int targetPriority = 25;

    //'this' deals damage to target, returns if target is dead.
    public bool dealDamage(Unit target)
    {
        target.hp -= (int)(strength - (.5f * target.constitution));
        return target.hp <= 0;
    }
}
