using System;
using System.Collections.Generic;
using System.Text;

class DataUse
{
    public List<Model.GameEvent> gEvent = new List<Model.GameEvent>();
    public List<Model.GameMonster> mEvent = new List<Model.GameMonster>();
    public List<Model.TalkResult> talk = new List<Model.TalkResult>();
    public List<Model.GameBattle> gBattle = new List<Model.GameBattle>();

    public DataUse()
    {
        readGameEvent();
        readGameMonster();
        readTalkResult();
        readGameBattle();
    }




    //读取GameEvent表；
    void readGameEvent()
    {
        // Read sample data from CSV file
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("D://GameEvent.CSV"))
        {
            ReadWriteCsv.CsvRow row = new ReadWriteCsv.CsvRow();
            int i = 1;
            while (reader.ReadRow(row))
            {
                Model.GameEvent temp = new Model.GameEvent();
                if (i > 4)
                {

                    temp.id = row[0];
                    temp.eventSign = row[1];
                    int.TryParse(row[2], out temp.eventType);
                    temp.eventName = row[3];
                    temp.eventTalk = row[4];
                    temp.eventGroup = row[5];
                    gEvent.Add(temp);
                }

                i++;
            }
        }
    }


    void readGameMonster()
    {
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("D://GameMonster.CSV"))
        {
            ReadWriteCsv.CsvRow row = new ReadWriteCsv.CsvRow();
            int i = 1;
            while (reader.ReadRow(row))
            {
                Model.GameMonster temp = new Model.GameMonster();
                if (i > 4)
                {

                    temp.id = row[0];
                    temp.MonsterName = row[1];
                    int.TryParse(row[2], out temp.TypeID);
                    temp.TeamHeadIcon = row[3];
                    int.TryParse(row[4], out temp.BaseLife);
                    int.TryParse(row[5], out temp.BaseDef);
                    int.TryParse(row[6], out temp.BaseAct);
                    float.TryParse(row[7], out temp.AttrProp);
                    mEvent.Add(temp);
                }

                i++;
            }
        }

    }

    void readTalkResult()
    {
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("D://TalkResult.CSV"))
        {
            ReadWriteCsv.CsvRow row = new ReadWriteCsv.CsvRow();
            int i = 1;
            while (reader.ReadRow(row))
            {
                Model.TalkResult temp = new Model.TalkResult();
                if (i > 4)
                {

                    temp.id = row[0];
                    int.TryParse(row[1], out temp.ResultType);
                    temp.ResultName = row[2];
                    temp.EventTalk = row[3];
                    talk.Add(temp);
                }

                i++;
            }
        }

    }

    void readGameBattle()
    {
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("D://GameBattle.CSV"))
        {
            ReadWriteCsv.CsvRow row = new ReadWriteCsv.CsvRow();
            int i = 1;
            while (reader.ReadRow(row))
            {
                Model.GameBattle temp = new Model.GameBattle();
                if (i > 4)
                {

                    temp.id = row[0];
                    //int.TryParse(row[1], out temp.ResultType);
                    temp.BattleObject = row[1];
                    temp.BattleWise = row[2];
                    gBattle.Add(temp);
                }

                i++;
            }
        }

    }



}

