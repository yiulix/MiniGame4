using System;
using System.Collections.Generic;
using System.Text;

namespace RandonEventApplication
{


    class MajorLine
    {

    }

    class RandomEvent
    {
        //话语堆
        private List<ConversationEventApplication.ConversationEvent> RanCon;//普通话语块
        private List<ConversationEventApplication.ConversationEvent> KeyCon;//关键话语块
        private List<ConversationEventApplication.ConversationEvent> GeneralCon;//普通道具事件
        private List<ConversationEventApplication.ConversationEvent> ActCon;//战斗事件
        DataUse newData = new DataUse();

        public RandomEvent()
        {
            RanCon = new List<ConversationEventApplication.ConversationEvent>();
            KeyCon = new List<ConversationEventApplication.ConversationEvent>();
        }

        public void GeneralEventInit()
        {

        }


        //初始化随机对话堆
        public void RanConInit()
        {

            List<Model.GameEvent> mg = newData.gEvent;//事件集\
            List<Model.GameTalk> gTalk = newData.gTalk;
            foreach (Model.GameEvent s in mg)
            {
                string eventTalk = s.eventTalk;
                foreach(Model.GameTalk t in gTalk)
                {
                    if(eventTalk.Trim() == t.TalkGroup.Trim())
                    {
                        ConversationEventApplication.ConversationEvent OneNext = null;//第一个子节点
                        ConversationEventApplication.ConversationEvent TwoNext = null;//第二个子节点
                        ConversationEventApplication.ConversationEvent ThreeNext = null;//第三个子节点
                        ConversationEventApplication.ConversationEvent cc = new ConversationEventApplication.ConversationEvent();
                        cc.addEventTalks(s.eventType, s.eventName, 0, t.TalkRole, t.EventName, s.eventRoles, t.RoleHead
                            , OneNext, TwoNext, ThreeNext);
                        if(RanCon.Count == 0)
                        {
                            cc.addEventTalks(s.eventType, s.eventName, 0, t.TalkRole, t.EventName,
                                s.eventRoles, t.RoleHead, null, null, null);
                        }
                        else
                        {
                            if(t.TalkSelect != "1")
                            {

                            }
                            else
                            {

                            }
                        }

                    }
                }
            }
        }

        //初始化关键对话堆
        public void KeyConInit()
        {
            
        }

        //返回随机普通事件
        public ConversationEventApplication.ConversationEvent getRanCon()
        {
            List<Model.GameEvent> mg = newData.gEvent;//事件集
            int start, end;
            foreach(Model.GameEvent s in mg)
            {

            }
            Random ro = new Random(10);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            int k = ran.Next(0, RanCon.Count);
            return RanCon[k];
        }

        //返回随机关键事件
        public ConversationEventApplication.ConversationEvent getKeyCon()
        {
            Random ro = new Random(10);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            int k = ran.Next(0, RanCon.Count);
            return KeyCon[k];
        }
    }
}
