using System;
using System.Collections.Generic;
using System.Text;

class NewMonster
{
    DataUse newData;

    public NewMonster()
    {
        newData = new DataUse();
    }

    //0-7层返回随机怪物
    public Model.GameMonster get7Monster()
    {
        List<Model.GameMonster> g = newData.mEvent;
        Model.GameMonster result = new Model.GameMonster();
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(0, 3);
        return g[k];
    }


    //8-15层返回随机怪物
    public Model.GameMonster get15Monster()
    {
        List<Model.GameMonster> g = newData.mEvent;
        Model.GameMonster result = new Model.GameMonster();
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int k = ran.Next(3, 6);
        return g[k];
    }
}
