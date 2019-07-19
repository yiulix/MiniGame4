using System;
using System.Collections.Generic;
using System.Text;

//事件集操作
class NewConversation
{
    private List<Model.GameEvent> KeyEV = new List<Model.GameEvent>();//1.关键事件
    private List<Model.GameEvent> RanEV = new List<Model.GameEvent>();//2.普通事件
    private List<Model.GameEvent> GeneralEV = new List<Model.GameEvent>();//3.普通道具事件
    private List<Model.GameEvent> ActEV = new List<Model.GameEvent>();//4.战斗事件
    private List<Model.GameEvent> RandomRanEV = new List<Model.GameEvent>();//个人随机普通事件
    private List<Model.GameEvent> RandomGeneralEV = new List<Model.GameEvent>();//个人随机普通道具事件
    private List<Model.GameEvent> RandomActEV = new List<Model.GameEvent>();//个人随机战斗事件

    private List<Model.GameEvent> REV216 = new List<Model.GameEvent>();//2-16层随机事件库
    DataUse newData;

    public NewConversation()
    {
        newData = new DataUse();
        InitEV();
    }

    //初始化事件堆
    private void InitEV()
    {
        List<Model.GameEvent> mg = newData.gEvent;//事件集
        foreach(Model.GameEvent s in mg)
        {
            if (s.eventType == 1)
                KeyEV.Add(s);
            if (s.eventType == 2)
                RanEV.Add(s);
            if (s.eventType == 3)
                GeneralEV.Add(s);
            if (s.eventType == 4)
                ActEV.Add(s);
        }
    }

    //用角色id确定该角色的随机事件库
    public void InitREV216(string EventRole)
    {
        List<Model.GameEvent> mg = newData.gEvent;//事件集
        foreach (Model.GameEvent s in mg)
            if (s.eventSign == "EventGroup_1234" && s.eventRoles == EventRole)
        {
            REV216.Add(s);//随机事件库
        }
    }

    //用角色id确定该角色的初始事件
    public Model.GameEvent InitAction(string EventRole)
    {
        Model.GameEvent result = new Model.GameEvent();
        List<Model.GameEvent> mg = newData.gEvent;//事件集
        foreach (Model.GameEvent s in mg)
            if (s.eventSign == "EventGroup_9999" && s.eventRoles == EventRole)
            {
                result = s;
            }
        return result;
    }

    //开始的关键事件
    public Model.GameEvent StartKeyEvent(string EventRole)
    {
        Model.GameEvent result = new Model.GameEvent();
        List<Model.GameEvent> mg = newData.gEvent;//事件集
        foreach (Model.GameEvent s in mg)
            if (s.eventSign == "EventGroup_1002" && s.eventRoles == EventRole)
            {
                result = s;
                break;
            }
        return result;
    }

    //先用角色id确定随机事件库。
    //返回该角色的随机事件。
    public Model.GameEvent getRandomREV216()
    {
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, REV216.Count);
        return REV216[k];
    }

    //根据编号返回战斗事件
    public Model.GameEvent getActEV(string EventSign)
    {
        Model.GameEvent result = new Model.GameEvent();
        foreach (Model.GameEvent s in ActEV)
        {
            if (s.eventSign == EventSign)
                result = s;
        }
        return result;
    }

    //根据编号返回道具事件
    public Model.GameEvent getGeneralEV(string EventSign)
    {
        Model.GameEvent result = new Model.GameEvent();
        foreach (Model.GameEvent s in GeneralEV)
        {
            if (s.eventSign == EventSign)
                result = s;
        }
        return result;
    }


    //根据编号返回关键事件
    public Model.GameEvent getKeyEV(string EventSign)
    {
        Model.GameEvent result = new Model.GameEvent();
        foreach (Model.GameEvent s in KeyEV)
        {
            if (s.eventSign == EventSign)
                result = s;
        }
        return result;
    }

    //根据编号返回普通事件

    public Model.GameEvent getRanEV(string EventSign)
    {
        Model.GameEvent result = new Model.GameEvent();
        foreach (Model.GameEvent s in RanEV)
        {
            if (s.eventSign == EventSign)
                result = s;
        }
        return result;
    }

    //返回时个人随机普通事件
    public Model.GameEvent getRandomRanEV(string EventRoles)
    {
        foreach (Model.GameEvent s in RanEV)
        {
            if (s.eventRoles == EventRoles)
                RandomRanEV.Add(s);
        }
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, RandomRanEV.Count);
        return RandomRanEV[k];
    }

    //返回....随机关键事件
    public Model.GameEvent getRandomKeyEV()
    {
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, KeyEV.Count);
        return KeyEV[k];
    }

    //返回个人随机道具事件
    public Model.GameEvent getRandomGeneralEV(string EventRoles)
    {
        foreach (Model.GameEvent s in GeneralEV)
        {
            if (s.eventRoles == EventRoles)
                RandomGeneralEV.Add(s);
        }
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, RandomGeneralEV.Count);
        return RandomGeneralEV[k];
    }

    //返回个人随机战斗事件
    public Model.GameEvent getRandomActEV(string EventRoles)
    {
        foreach (Model.GameEvent s in ActEV)
        {
            if (s.eventRoles == EventRoles)
                RandomActEV.Add(s);
        }
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, RandomActEV.Count);
        return RandomActEV[k];
    }

}

