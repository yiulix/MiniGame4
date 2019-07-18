using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartMangerKeyplot : MonoBehaviour
{
    // Start is called before the first frame update
    DataUse newData = new DataUse();
    public string talk = "";//话
    public string people = "";//人
    public string chooId = "";
    string EventGroup;//事件组id
    public Fungus.Flowchart f;
    private bool isend;
    public string[,] s0;
    public int type;

    NewTalk nt;//对话集操作
    NTalk s;//对话链表头节点
    NewConversation nConversation;//事件集操作
    NewResult nr;//结果集操作

    private void Start()
    {
        nt = new NewTalk();
        s = nt.getTalk("TalkGroup_1003");
        nConversation = new NewConversation();
        nr = new NewResult();
        s0 = new string[3, 2];
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
                f.SetStringVariable("menuA", s2[0]);
            if (i == 1)
                f.SetStringVariable("menuB", s2[0]);
            if (i == 2)
                f.SetStringVariable("menuC", s2[0]);//按键语句
            s0[i, 1] = s2[1];//下一事件id
            i++;
        }


    }

    void ChooseResult(string s1)
    {
        chooId = s1;//被选择的框id；


        Model.TalkResult tr = nr.getTalkResult(chooId);
        type = tr.ResultType;//结果类型

        //跳转到下一个事件
        //string NextEvent = tr.EventGroup;//切换的下一个事件组ID；
        if (type == 4)//有下一个事件组
        {
            //寻找下一个事件
            EventGroup = tr.EventGroup;//切换事件组ID
            Model.GameEvent gEvent = nConversation.getEV(EventGroup);
            s = nt.getTalk(gEvent.eventTalk);//节点
        }
        else//没有下一个事件组。结束。
        {
            s = null;
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
            case "？？？":
                {
                    f.SetIntegerVariable("NumofSpeaker", 3);
                    break;
                }
        }
        f.SetStringVariable("Saying", talk);
        f.SetBooleanVariable("Isend", isend);

    }
    public void Keyplot(int i)
    {
        switch (i)
        {
            case 1://跳转道具场景
                break;
            case 2://跳转战斗时间
                break;
            case 5://好感度变化并跳转选关场景
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
