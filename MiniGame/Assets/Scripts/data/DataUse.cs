using System;
using System.Collections.Generic;
using System.Text;

class DataUse
{
    public List<Model.GameEvent> gEvent = new List<Model.GameEvent>();
    public List<Model.GameMonster> mEvent = new List<Model.GameMonster>();
    public List<Model.TalkResult> talkR = new List<Model.TalkResult>();
    public List<Model.GameBattle> gBattle = new List<Model.GameBattle>();
    public List<Model.GamePartner> gPartner = new List<Model.GamePartner>();
    public List<Model.GameTalk> gTalk = new List<Model.GameTalk>();

    public DataUse()
    {
        readGameEvent();
        readGameMonster();
        readTalkResult();
        readGameBattle();
        readGamePartner();
        readGameTalk();
    }




    //读取GameEvent表；
    void readGameEvent()
    {
        // Read sample data from CSV file
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("E://GameEvent.CSV"))
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
                    temp.eventRoles = row[5];
                    gEvent.Add(temp);
                }

                i++;
            }
        }
    }


    void readGameMonster()
    {
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("E://GameMonster.CSV"))
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
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("E://TalkResult.CSV"))
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
                    temp.EventGroup = row[4];
                    talkR.Add(temp);
                }

                i++;
            }
        }

    }

    void readGameBattle()
    {
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("E://GameBattle.CSV"))
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

    void readGamePartner()
    {
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("E://GamePartner.CSV"))
        {
            ReadWriteCsv.CsvRow row = new ReadWriteCsv.CsvRow();
            int i = 1;
            while (reader.ReadRow(row))
            {
                Model.GamePartner temp = new Model.GamePartner();
                if (i > 4)
                {

                    temp.id = row[0];
                    //int.TryParse(row[1], out temp.ResultType);
                    temp.PartnerName = row[1];
                    int.TryParse(row[2], out temp.TypeId);
                    int.TryParse(row[3], out temp.BaseLife);
                    int.TryParse(row[4], out temp.BaseDef);
                    int.TryParse(row[5], out temp.BaseAct);
                    float.TryParse(row[6], out temp.TalentProp);
                    gPartner.Add(temp);
                }

                i++;
            }
        }

    }


    void readGameTalk()
    {
        using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader("E://GameTalk.CSV"))
        {
            ReadWriteCsv.CsvRow row = new ReadWriteCsv.CsvRow();
            int i = 1;
            while (reader.ReadRow(row))
            {
                Model.GameTalk temp = new Model.GameTalk();
                if (i > 4)
                {

                    temp.id = row[0];
                    //int.TryParse(row[1], out temp.ResultType);
                    temp.TalkGroup = row[1];
                    temp.TalkRole = row[2];
                    int.TryParse(row[3], out temp.RoleHead);
                    temp.EventName = row[4];
                    temp.TalkSelect = row[5];
                    gTalk.Add(temp);
                }

                i++;
            }
        }

    }

}

