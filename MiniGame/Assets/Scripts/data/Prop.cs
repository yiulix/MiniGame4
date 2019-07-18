using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ItemApplication
{
    class Item
    {
        //道具类型：1.攻击、2.防御、3.生命
        private int ItemType;
        //道具效果值
        private int AttrEffect;
        //道具名称
        private string ItemName;
        //好感度效果
        private int ImpEffect;

        public Item()
        {
            this.ImpEffect = 5;
        }

        //返回随机装备
        public Item getProp()
        {
            Random ro = new Random(10);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            int k = ran.Next(1, 4);
            this.ItemType = k;
            if (k == 1)
            {
                this.AttrEffect = 5;
                this.ItemName = "防御精魄";
            }
            else if (k == 2)
            {
                this.AttrEffect = 20;
                this.ItemName = "生命精魄";
            }
            else
            {
                this.AttrEffect = 15;
                this.ItemName = "攻击精魄";
            } 
            return this;
        }

        //返回该随机装备的id
        public int getItemType()
        {
            return this.ItemType;
        }

        //返回该随机装备的属性数字
        public int getAttrEffect()
        {
            return this.AttrEffect;
        }

        //返回该随机装备的名字
        public string getItemName()
        {
            return this.ItemName;
        }

        //返回好感度效果
        public int getImpEffect()
        {
            return this.ImpEffect;
        }

    }
}
