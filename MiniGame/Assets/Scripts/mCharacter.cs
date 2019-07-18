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
    }

    void CheckChanges()
    {

    }

    public void ChangeRelationship()
    {

    }
}

public static class GameData
{
    public static int floor = 1;
}
