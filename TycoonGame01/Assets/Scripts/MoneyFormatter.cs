using System.Collections;
using System.Collections.Generic;
using System.Numerics;


public static class MoneyFormatter
{
    public static string FormatMoney(BigInteger value)
    {
        string moneyFormat = "{0}";

        if(value >= 1000000000)
        {
            moneyFormat = "{0:#,0,,, 억}";
        }
        else if(value >= 10000)
        {
            moneyFormat = "{0:#,0,, 만}";
        }
        else if(value >= 1000)
        {
            moneyFormat = "{0:#,0, 천}";
        }
        return string.Format(moneyFormat + "원", value);
    }
}

