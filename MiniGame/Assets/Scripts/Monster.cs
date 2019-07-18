using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int id;
    public string mName;
    public int health;
    public int attack;
    public int defense;

    public int type;
    public int typeValue;

    public void Init(int id)
    {
        if (type == 1)
        {
            attack += typeValue;
        }
        if (type == 3)
        {
            defense += typeValue;
        }

    }
}

//0-没有怪物特性；1-攻击时附加无视防御的伤害；2-攻击时回复自身生命；3-受到伤害时减免一定伤害
