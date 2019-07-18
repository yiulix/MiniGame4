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
    DataUse newData;

    public NewConversation()
    {
        newData = new DataUse();
        InitEV();
    }

    //初始化事件堆
    private void InitEV()
    {
        List<Model.GameEvent> mg = newData.gEvent;//事件集\
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

    //根据编号返回任何事件
    public Model.GameEvent getEV(string EventSign)
    {
        Model.GameEvent result = new Model.GameEvent();
        List<Model.GameEvent> mg = newData.gEvent;//事件集\
        foreach (Model.GameEvent s in mg)
        {
            if (s.eventSign == EventSign)
            {
                result = s;
            }
        }
        return result;
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

    //返回时随机普通事件
    public Model.GameEvent getRandomRanEV()
    {
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, RanEV.Count);
        return RanEV[k];
    }

    //返回时随机关键事件
    public Model.GameEvent getRandomKeyEV()
    {
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, KeyEV.Count);
        return KeyEV[k];
    }

    //返回时随机道具事件
    public Model.GameEvent getRandomGeneralEV()
    {
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, GeneralEV.Count);
        return GeneralEV[k];
    }

    //返回时随机战斗事件
    public Model.GameEvent getRandomActEV()
    {
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, ActEV.Count);
        return ActEV[k];
    }

}

