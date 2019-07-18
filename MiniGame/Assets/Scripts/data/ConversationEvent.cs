using System;
using System.Collections.Generic;
using System.Text;

namespace ConversationEventApplication
{
    //GameTalk
    class ConversationEvent
    {
        public int id;//块id
        public string name;//人物名字
        public string talk;//人物语言
        public ConversationEvent OneNext = null;//第一个子节点
        public ConversationEvent TwoNext = null;//第二个子节点
        public ConversationEvent ThreeNext = null;//第三个子节点
        

        int EventType;//事件类型
        string EventName;//事件名称

        int RoleHead;//角色立绘
        //伙伴id；
        string PartnerId;

        public ConversationEvent()
        {
            InitEventTalks();
         }

        //初始化话语链
        private void InitEventTalks()
        {
            
        }


        //添加话语链
        public void addEventTalks(int EventType, string EventName, int id, string name, string talk, 
            string partnerID,int RoleHead, ConversationEvent oneNext, ConversationEvent twoNext,
            ConversationEvent threeNext)
        {
            this.id = id;
            this.name = name;
            this.talk = talk;
            this.PartnerId = partnerID;
            this.EventType = EventType;
            this.EventName = EventName;
            this.OneNext = oneNext;
            this.TwoNext = twoNext;
            this.ThreeNext = threeNext;
            
     
        }

        public int getEventType()
        {
            return EventType;
        }
        
        public void setEventType(int eventType)
        {
            this.EventType = eventType;
        }

        public string getEventName()
        {
            return EventName;
        }

        public void setEventName(string eventName)
        {
            this.EventName = eventName;
        }
    }
}
