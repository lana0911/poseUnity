using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using System;

public class d : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rt;
    public int dis = 0;
    public float scale = 5.5f;
    void Start()
    {
        rt = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hi");
        var path = @"C:\Users\Lana\Desktop\TCP\test.txt";
        var txt = File.ReadAllText(path);
        Debug.Log(txt);
        Thread.Sleep(1000); //Delay 1��

        dis = Int32.Parse(txt);
        if (dis > 40000) scale = 5.5f;
        else if (dis < 40000 && dis >= 20000) scale = 8.5f;
        else if (dis < 20000) scale = 11.5f;




        rt.localScale = new Vector3(scale, scale, scale);
    }

}
