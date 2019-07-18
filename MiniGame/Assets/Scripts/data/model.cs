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
        public string eventRoles;
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

        public string EventGroup;
    }

    class GameBattle
    {
        public string id;
        public string BattleObject;
        public string BattleWise;

    }

    class GamePartner
    {
        public string id;
        public string PartnerName;
        public int TypeId;
        public int BaseLife;
        public int BaseDef;
        public int BaseAct;
        public float TalentProp;
    }

    class GameTalk
    {
        public string id;
        public string TalkGroup;
        public string TalkRole;
        public int RoleHead;
        public string EventName;
        public string TalkSelect;
    }
}
