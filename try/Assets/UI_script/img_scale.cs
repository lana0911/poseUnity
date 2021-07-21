using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using System;
using UnityEngine.Events;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;
using System.Text;



public class img_scale: MonoBehaviour
{


    RectTransform rt;
    public float scale = 4.0f;


    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        //500up:�H�̪� : ��̤p��3.0��
        //350~500:�H������ : �Ϩ�3.8
        //250~350:�H������ : �Ϩ�4.5
        //250down:�H�̻� : ���5.3��
        if (varName.img_dis > 50000) scale = 3.5f;
        else if (varName.img_dis > 35000) scale = 4.3f;
        else if (varName.img_dis > 25000) scale = 4.8f;
        else if (varName.img_dis <= 25000 && varName.img_dis != 0) scale = 5.8f;
        else if (varName.img_dis == 0) scale = 4.7f;
        rt.localScale = new Vector3(scale, scale, scale);

    }













    /* RectTransform rt;
    public float scale = 4.0f;
    //
    // public string msg;
    float up = 5.0f;
    float low = 3.0f;
    bool add = true;
    bool sub = false;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {

        if(add)
            scale += 0.01f;
        if(sub)
            scale -= 0.01f;

        rt.localScale = new Vector3(scale, scale, scale);
        //Debug.Log("Scale="+scale);
        if(scale >= 5.1)
        {
            add = false;
            sub = true;
        }
        if (scale <= 3.0)
        {
            sub = false;
            add = true;
        }
    }
  
    */


}
