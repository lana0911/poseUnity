using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class varName
{

    //ca
    public static bool came = false; //


    public static bool playing = false; //playing
    public static int mode = -1; //playing

    //UI����
    public static float img_dis = 0;//album iimg��
    //PSS
    public static int pss_name = 1; //�@�i�h��� "�ŤM���Y��"
    public static bool gameName_show = true;//"����ŤM���Y��"
    public static bool introTitle_show = false;//"�C������"
    public static bool introContent_show = false;//"�C���������e
    public static bool gift_show = false;//"�p§��"    
    public static bool pss_name_show = false;//�ܽd�ɪ��ŤM���Y���W��
    public static bool pss_detail_show = false;//�ܽd�ɪ��ŤM���Y������  
    public static bool cnt_start = false;//�˼ƶ}�l
    public static bool cnt_end = false;//�˼Ƶ���(openpose�^�ǵ��G)
    //PSS-model animation
    public static string modelPose = "";//
    public static string playerPose = "";//
    public static bool model_start_animation = false;//
    public static int winner = -1;//
    public static int getPrize = -1;//
    public static bool game1Over = false;


}
