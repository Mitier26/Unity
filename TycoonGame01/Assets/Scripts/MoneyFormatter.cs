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
            moneyFormat = "{0:#,0,,, B}";
        }
        else if(value >= 1000000)
        {
            //1,000,000
            moneyFormat = "{0:#,0,, M}";
        }
        else if(value >= 1000)
        {
            //1,000
            moneyFormat = "{0:#,0, K}";
        }
        
        return string.Format(moneyFormat + "원", value);
    }
}

