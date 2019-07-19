using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mCharacter : MonoBehaviour
{
    public string cName;
    public bool isPlayer = false;
    public int ID;
    public int health;
    public int defense;
    public int attack;
    public int talent;
    bool isDead = false;

    //对自己好感度
    public int[] relationships;

    public int[] relationshipChange;

    // initialize character attributes by its ID
    public void Init(int ID)
    {

    }

    public void Init(int id, string n, int h, int a, int d, int t)
    {
        ID = id;
        cName = n;
        health = h;
        attack = a;
        defense = d;
        talent = t;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        health = Mathf.Max(health, 0);
        isDead = true;
    }

    void CheckChanges()
    {

    }

    public void ChangeRelationship(int i)
    {
        if (isPlayer && ID == 0)
        {
            GameData.relationship += i;
        }
        if (isPlayer && ID == 1)
        {
            GameData.relationship += i;
        }
        if (isPlayer && ID == 2)
        {
            GameData.relationship += i;
        }
    }
}

public static class GameData
{
    public static int floor = 1;
    public static int whoIsPlayer = 0;
    public static int relationship = 100;
    public static string s20;
    public static int times = 1;
}
