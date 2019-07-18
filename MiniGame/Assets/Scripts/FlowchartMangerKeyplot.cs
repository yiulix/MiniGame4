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
    public string[] s1;
    public string[] s2;
    public int type;

    NewTalk nt;
    NTalk s;


    private void Start()
    {
        nt = new NewTalk();
        s = nt.getTalk("TalkGroup_1001");
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
    


    void GetTalk()
    {
        
        s1 = DevUser.SUBString1(s.nowTalk.TalkSelect);
            foreach (string str in s1)
            {
                s2 = DevUser.SUBString2(str);
                string choose = s2[0];//按键语句
                string result = s2[1];//下一事件id
            }
    }

    void ChooseResult(string s)
    {
        chooId = s;//被选择的框id；

        NewResult nr = new NewResult();
        Model.TalkResult tr = nr.getTalkResult(chooId);
        type = tr.ResultType;//结果类型

        EventGroup = tr.EventGroup;//切换事件组ID

        //跳转到下一个事件
        string NextEvent = tr.EventGroup;//切换的下一个事件组ID；
        if (type == 4)//有下一个事件组
        {
            NewConversation nc = new NewConversation();
            Model.GameEvent mmg = nc.getEV(tr.EventGroup);
        }
        else//没有下一个事件组。结束。
        {

        }
    }

    public void getvalue()
    {
        GetTalk();
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
        }
        f.SetStringVariable("Saying", talk);
        f.SetBooleanVariable("Isend", isend);
        f.SetStringVariable("menuA", s2[0]);
        f.SetStringVariable("menuB", s2[2]);
        f.SetStringVariable("menuC", s2[4]);
        f.SetIntegerVariable("style", type);

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
