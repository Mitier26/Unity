using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string str = "ABC DE F G";
        Debug.Log(str.Substring(0,2));
        Debug.Log(str.Substring(2));

        char s = ' ';
        string[] strArr = str.Split(s);

        for(int i = 0 ; i < strArr.Length; i++)
        {
            Debug.Log(i + "번" + strArr[i]);
        }

        Debug.Log(str.IndexOf("D"));

        Debug.Log(str.Contains("DE"));
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
