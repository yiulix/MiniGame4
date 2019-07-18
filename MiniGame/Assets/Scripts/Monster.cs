using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int ID;
    public string mName;
    public int health;
    public int attack;
    public int defense;

    public int type;
    public int typeValue;

    int[] M_ID;
    string[] M_NAME;
    int[] M_HEALTH;
    int[] M_TYPE;
    int[] M_ATTACK;
    int[] M_DEFENSE;
    int[] M_TYPEVALUE;
    public Sprite[] M_SPRITE;

    private void Awake()
    {
        M_ID = new int[6] { 0, 1, 2, 3, 4, 5 };
        M_NAME = new string[6] { "熊", "狼", "猴", "椒图", "两角兽", "麒麟" };
        M_HEALTH = new int[6] { 300, 180, 90, 200, 250, 300 };
        M_TYPE = new int[6] { 0, 0, 0, 2, 3, 1 };
        M_ATTACK = new int[6] { 10, 25, 15, 25, 20, 25 };
        M_DEFENSE = new int[6] { 10, 5, 15, 15, 15, 20 };
        M_TYPEVALUE = new int[6] { 0, 0, 0, 10, 3, 5 };




    }

    public void Init(int id)
    {
        ID = M_ID[id];
        mName = M_NAME[id];
        health = M_HEALTH[id];
        attack = M_ATTACK[id];
        defense = M_DEFENSE[id];
        type = M_TYPE[id];
        typeValue = M_TYPEVALUE[id];

        if (type == 1)
        {
            attack += typeValue;
        }
        if (type == 3)
        {
            defense += typeValue;
        }

        GetComponent<SpriteRenderer>().sprite = M_SPRITE[id];

    }
}

//0-没有怪物特性；1-攻击时附加无视防御的伤害；2-攻击时回复自身生命；3-受到伤害时减免一定伤害
