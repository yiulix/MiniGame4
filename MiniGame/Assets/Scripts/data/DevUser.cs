using System;
using System.Collections.Generic;
using System.Text;

class DevUser
{
    public DevUser()
    {}

    //检查是否跳转
    public static Boolean IsEnd(Model.TalkResult t)
    {
        if (t.ResultType == 4)
            return true;
        else
            return false;
    }

    //第一次切割
    public static string[] SUBString1(string s)
    {
        string[] strArr = s.Split(';');
        return strArr;
    }

    //第二次切割
    public static string[] SUBString2(string s)
    {
        string[] strArr = s.Split('|');
        return strArr;
    }


}

