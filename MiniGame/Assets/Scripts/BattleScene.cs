using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScene : MonoBehaviour
{
    public PageManager pgm;
    int turn = -1; // 0 for c0, 2 for c1, 4 for c2, 1,3,5 for monster
    public Monster monster;
    public int BattleState = -1; // 0 is fighting, 1 win, 2 lose
    string[] toDialog; // who, whom, dmg
    public mCharacter c0;
    public mCharacter c1;
    public mCharacter c2;

    public AudioSource battleAudio;
    GameObject audio;

    // Start is called before the first frame update
    void Start()
    {
        toDialog = new string[3];
        c0 = GameObject.Find("c0").GetComponent<mCharacter>();
        c1 = GameObject.Find("c1").GetComponent<mCharacter>();
        c2 = GameObject.Find("c2").GetComponent<mCharacter>();

        audio = GameObject.Find("Audio");
        audio.SetActive(false);

        GenerateMonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pgm.Act("SelectDoor");
        }
    }

    
    public void StartBattle()
    {
        turn = 0;
    }

    void NextTurn()
    {
        turn += 1;
        if (turn == 6)
        {
            turn = 0;
        }
    }

    //called once per click in battle
    public string[] OneTurn()
    {
        if (turn == 0)
        {
            int dmg = c0.attack - monster.defense;
            dmg = dmg > 0 ? dmg : 0;
            monster.health -= dmg;
            toDialog[0] = c0.cName;
            toDialog[1] = monster.mName;
            toDialog[2] = dmg.ToString();

        }
        else if (turn == 2)
        {
            monster.health -= c1.attack;
            int dmg = c1.attack - monster.defense;
            dmg = dmg > 0 ? dmg : 0;
            monster.health -= dmg;
            toDialog[0] = c1.cName;
            toDialog[1] = monster.mName;
            toDialog[2] = dmg.ToString();
        }
        else if (turn == 4)
        {
            monster.health -= c2.attack;
            int dmg = c2.attack - monster.defense;
            dmg = dmg > 0 ? dmg : 0;
            monster.health -= dmg;
            toDialog[0] = c2.cName;
            toDialog[1] = monster.mName;
            toDialog[2] = dmg.ToString();
        }
        //monster attack
        else
        {
            int r = (int)(Random.value * 3);
            int dmg;
            if (r == 0)
            {
                dmg = monster.attack - c0.defense;
                dmg = dmg > 0 ? dmg : 0;
                toDialog[0] = monster.mName;
                toDialog[1] = c0.cName;
                toDialog[2] = dmg.ToString();
                c0.TakeDamage(dmg);
            }
            if (r == 1)
            {
                dmg = monster.attack - c1.defense;
                dmg = dmg > 0 ? dmg : 0;
                toDialog[0] = monster.mName;
                toDialog[1] = c1.cName;
                toDialog[2] = dmg.ToString();
                c1.TakeDamage(dmg);
            }
            if (r == 2)
            {
                dmg = monster.attack - c2.defense;
                dmg = dmg > 0 ? dmg : 0;
                toDialog[0] = monster.mName;
                toDialog[1] = c2.cName;
                toDialog[2] = dmg.ToString();
                c2.TakeDamage(dmg);
            }

            if (monster.type == 2)
            {
                monster.health += monster.typeValue;
            }

        }

        if (monster.health <= 0)
        {
            BattleWin();
        }
        NextTurn();

        return toDialog;
    }

    void GenerateMonster()
    {
        int r = (int)(Random.value * 3);
        if (GameData.floor < 8)
        {
            monster.Init(r);
        }
        else
        {
            monster.Init(r + 3);
        }

    }

    void BattleWin()
    {
        BattleState = 1;
    }

    void BattleLose()
    {

    }

    public void NextScene()
    {
        audio.SetActive(true);
        battleAudio.gameObject.SetActive(false);
        SceneManager.LoadScene("Iteam");
    }
}