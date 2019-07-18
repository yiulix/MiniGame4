using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartManger : MonoBehaviour
{
    private int NumofIteam;
    private int NumofPlayer;
    public Fungus.Flowchart flowchart;
    public mCharacter c0;
    public mCharacter c1;
    public mCharacter c2;

    private void Start()
    {
        c0 = GameObject.Find("c0").GetComponent<mCharacter>();
        c1 = GameObject.Find("c1").GetComponent<mCharacter>();
        c2 = GameObject.Find("c2").GetComponent<mCharacter>();
    }
    public void setiteam(int i)
    {
        NumofIteam = i;
        
    }
    public void setPlayer(int i)
    {
        NumofPlayer = i;
        switch (NumofPlayer)
        {
            case 1:
                {
                    flowchart.SetBooleanVariable("Isplayer", c0.isPlayer);
                    break;
                }
            case 2:
                {
                    flowchart.SetBooleanVariable("Isplayer", c1.isPlayer);
                    break;
                }
            case 3:
                {
                    flowchart.SetBooleanVariable("Isplayer", c2.isPlayer);
                    break;
                }
        }
    }
    public void GiveNum()
    {
        switch (NumofPlayer)
        {
            case 1:
                {
                    powerup(c0);
                    if (c0.isPlayer)
                        break;
                    else if (c1.isPlayer)
                        c1.relationships[0] += 5;
                    else if (c2.isPlayer)
                        c2.relationships[0] += 5;
                    break;
                }
            case 2:
                {
                    powerup(c1);
                    if (c1.isPlayer)
                        break;
                    else if (c0.isPlayer)
                        c0.relationships[1] += 5;
                    else if (c2.isPlayer)
                        c2.relationships[1] += 5;
                    break;
                }
            case 3:
                {
                    powerup(c2);
                    if (c2.isPlayer)
                        break;
                    else if (c1.isPlayer)
                        c1.relationships[2] += 5;
                    else if (c0.isPlayer)
                        c0.relationships[2] += 5;
                    break;
                }
        }

    }
    private void powerup(mCharacter character)
    {
        Debug.Log("powerup" + character.ID.ToString());
        switch (NumofIteam)
        {
            case 1:
                {//角色i增加生命
                    character.health += 20;
                    break;
                }
            case 2:
                {//角色i增加攻击力
                    character.attack += 10;
                    break;
                }
            case 3:
                {//角色i增加防御力
                    character.defense += 5;
                    break;
                }
        }
    }
    public void c0h()
    {
        c0.health += 20;
    }
    public void c1h()
    {
        c1.health += 20;
    }
    public void c2h()
    {
        c2.health += 20;
    }
    public void c0a()
    {
        c0.attack += 10;
    }
    public void c1a()
    {
        c1.attack += 10;
    }
    public void c2a()
    {
        c2.attack += 10;
    }
    public void c0d()
    {
        c0.defense += 5;
    }
    public void c1d()
    {
        c1.defense += 5;
    }
    public void c2d()
    {
        c2.defense += 5;
    }
    public void IsKeyplot()
    {
        //是否触发关键剧情
    }
}
