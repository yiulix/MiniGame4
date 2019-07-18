using System;
using System.Collections.Generic;
using System.Text;

//结果操作表
class NewResult
{
    DataUse newData;

    public NewResult()
    {
        newData = new DataUse();
    }

    //根据id返回结果
    public Model.TalkResult getTalkResult(string id)
    {
        Model.TalkResult thisResult = new Model.TalkResult();
        List<Model.TalkResult> gtr = newData.talkR;
        foreach (Model.TalkResult s in gtr)
        {
            if(s.id == id)
            {
                thisResult = s;
            }
        }
        return thisResult;
    }


}
