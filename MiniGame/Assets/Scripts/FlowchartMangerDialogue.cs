using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowchartMangerDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    DataUse newData = new DataUse();
    public string talk = "111";//话
    public string people = "1111";//人
    public string chooId = "";
    string EventGroup;//事件组id
    public Fungus.Flowchart f;
    private bool isend;
    public string[,] s0;
    public int type;
    public mCharacter c0;
    public mCharacter c1;
    public mCharacter c2;
    public mCharacter c;
    string actor;
    public int style;
    public int floor;

    Model.GameEvent gEvent;//事件
    NewTalk nt;//对话集操作
    NewResult Nresult;
    NTalk s;//对话链表头节点
    NTalk key;//关键剧情
    NewConversation nConversation;//事件集操作
    NewResult nr;//结果集操作

    private void Start()
    {
        nt = new NewTalk();
        Nresult = new NewResult();
        nConversation = new NewConversation();
        nr = new NewResult();
        s0 = new string[3, 2];
        c0 = GameObject.Find("c0").GetComponent<mCharacter>();
        c1 = GameObject.Find("c1").GetComponent<mCharacter>();
        c2 = GameObject.Find("c2").GetComponent<mCharacter>();
        c = isplayer();
        if (c.ID == 0)
            actor = "Partner_1002";
        if (c.ID == 1)
            actor = "Partner_1001";
        if (c.ID == 2)
            actor = "Partner_1003";
        floor = GameData.floor;

    }

    //第一层开始随机事件
    public void startEvent()
    {
        gEvent = nConversation.InitAction(actor);
        s = nt.getTalk(gEvent.eventTalk);
        nextTalk();
    }


    //调用2-16层随机事件
    public void initCon()
    {

        nConversation.InitREV216(actor);
        gEvent = nConversation.getRandomREV216();
        s = nt.getTalk(gEvent.eventTalk);
        //nextTalk();
    }
    public void start()
    {
        if (floor == 2)
        {
            startEvent();
        } else
            initCon();
    }

    public mCharacter isplayer()
    {
        if (c0.isPlayer == true)
            return c0;
        else if (c1.isPlayer == true)
            return c1;
        else
            return c2;
    }

    //下一个话语
    void nextTalk()
    {
        talk = s.nowTalk.EventName; //话语
        people = s.nowTalk.TalkRole; //人物

        if (s.nowTalk.TalkSelect != "1")
        {
            isend = true;//是否结束；
            return;
        }
        s = s.nextTalk;
    }


    //最后
    void GetTalk()
    {


        string[] s1 = DevUser.SUBString1(s.nowTalk.TalkSelect);
        int i = 0;
        foreach (string str in s1)
        {
            string[] s2 = DevUser.SUBString2(str);
            if (i == 0)
            {
                f.SetStringVariable("menuA", s2[0]);

            }

            if (i == 1)
            {
                f.SetStringVariable("menuB", s2[0]);

            }

            if (i == 2)
            {
                f.SetStringVariable("menuC", s2[0]);//按键语句


            }

            s0[i, 1] = s2[1];//下一事件id
            i++;
        }
    }
    public void choice1()
    {
        style = getType(s0[1, 1]);
    }
    public void choice2()
    {
        style = getType(s0[2, 1]);
    }
    public void choice3()
    {
        style = getType(s0[3, 1]);
    }
    //输入选项result返回type
    public int getType(string s)
    {
        Model.TalkResult tr = new Model.TalkResult();
        tr = Nresult.getTalkResult(s);
        return tr.ResultType;
    }

    //关键事件开始
    public void NextKey()
    {
        gEvent = nConversation.StartKeyEvent(actor);
        key = nt.getTalk(gEvent.eventTalk);
    }

    //关键事件下一个话语
    void KeyNextTalk()
    {
        talk = key.nowTalk.EventName; //话语
        people = key.nowTalk.TalkRole; //人物

        if (key.nowTalk.TalkSelect != "1")
        {
            isend = true;//是否结束；
            return;
        }
        key = key.nextTalk;
    }


    //关键事件最后一句选择
    void KeyGetTalk()
    {


        string[] s1 = DevUser.SUBString1(key.nowTalk.TalkSelect);
        int i = 0;
        foreach (string str in s1)
        {
            string[] s2 = DevUser.SUBString2(str);
            if (i == 0)
                f.SetStringVariable("menuA", s2[0]);
            if (i == 1)
                f.SetStringVariable("menuB", s2[0]);
            if (i == 2)
                f.SetStringVariable("menuC", s2[0]);//按键语句
            s0[i, 1] = s2[1];//下一事件id
            i++;
        }
    }

    //关键事件选项之后
    void ChooseResult(string s1)
    {
        chooId = s1;//被选择的框id；


        Model.TalkResult tr = nr.getTalkResult(chooId);
        type = tr.ResultType;//结果类型

        //跳转到下一个事件
        //string NextEvent = tr.EventGroup;//切换的下一个事件组ID；
        if (tr.EventGroup != "1")//有下一个事件组
        {
            //寻找下一个事件
            EventGroup = tr.EventGroup;//切换事件组ID
            gEvent = nConversation.getKeyEV(EventGroup);
            key = nt.getTalk(gEvent.eventTalk);//节点
        }
        else//没有下一个事件组。结束。
        {
            key = null;
        }
    }

    public void getvalue()
    {
        if (isend == true)
        {
            GetTalk();
            f.SetIntegerVariable("style", type);
        }
        nextTalk();


        switch (people)
        {
            case "师兄":
                {
                    f.SetIntegerVariable("NumofSpeaker", 0);
                    break;
                }
            case "师姐":
                {
                    f.SetIntegerVariable("NumofSpeaker", 1);
                    break;
                }
            case "师妹":
                {
                    f.SetIntegerVariable("NumofSpeaker", 2);
                    break;
                }
            case "旁白":
                {
                    f.SetIntegerVariable("NumofSpeaker", 3);
                    break;
                }
        }
        f.SetStringVariable("Saying", talk);
        f.SetBooleanVariable("Isend", isend);

    }
    public void Keyplot()
    {
        switch (style)
        {
            case 1://跳转道具场景
                SceneManager.LoadScene("Iteam");
                break;
            case 2://跳转战斗时间
                SceneManager.LoadScene("Battle");
                break;
            case 5://好感度变化并跳转选关场景
                SceneManager.LoadScene("SelectDoor");
                break;
        }
    }
    public void ploatchange(int i)
    {
        switch (i)
        {
            case 1://传递S2[1];
                break;
            case 2://传递S2[3]
                break;
        }
    }
}
