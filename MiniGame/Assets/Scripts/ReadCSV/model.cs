using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class GameEvent
    {
        public string id;
        public string eventSign;
        public int eventType;
        public string eventName;
        public string eventTalk;
        public string eventGroup;
    }

    class GameMonster
    {
        public string id;
        public string MonsterName;
        public int TypeID;
        public string TeamHeadIcon;
        //public string BodyIcon;
        public int BaseLife;
        public int BaseDef;
        public int BaseAct;
        public float AttrProp;
    }

    class TalkResult
    {
        public string id;
        public int ResultType;
        public string ResultName;
        public string EventTalk;
    }

    class GameBattle
    {
        public string id;
        public string BattleObject;
        public string BattleWise;

    }
}
