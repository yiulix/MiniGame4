﻿using System;
using System.Collections.Generic;
using System.Text;

class NTalk{
    public Model.GameTalk nowTalk;
    public NTalk nextTalk = null;
}

//对话集操作
class NewTalk
{
    public List<NTalk> TalkTle = new List<NTalk>();//对话链表
    DataUse newData;

    public NewTalk()
    {
        newData = new DataUse();
        InitTalkTle();
    }

    //链表初始化
    private void InitTalkTle()
    {
        List<Model.GameTalk> gt = newData.gTalk;
        string TalkGroup = "";

        foreach (Model.GameTalk s in gt)
        {

            if (TalkTle.Count == 0)
            {
                NTalk q = new NTalk();
                q.nowTalk = s;
                TalkGroup = s.TalkGroup;
                TalkTle.Add(q);
            }
            else
            {
                NTalk temp = TalkTle[TalkTle.Count - 1];
                if (s.TalkGroup == TalkGroup)
                {
                    //Model.GameTalk temp = new Model.GameTalk();
                    NTalk q = new NTalk();
                    q.nowTalk = s;
                    while (temp.nextTalk != null)
                    {
                        temp = temp.nextTalk;
                    }
                    temp.nextTalk = q;
                    //TalkTle.Add();
                }
                else
                {
                    NTalk t = new NTalk();
                    t.nowTalk = s;
                    TalkGroup = s.TalkGroup;
                    TalkTle.Add(t);
                }
            }

        }
    }

    //根据TalkGroup返回对话链表
    public NTalk getTalk(string TalkGroup)
    {
        NTalk result = new NTalk();
        foreach (NTalk s in TalkTle)
        {
            if (s.nowTalk.TalkGroup == TalkGroup)
                result = s;
        }
        return result;
    }


}
