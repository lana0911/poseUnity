using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Gobal_TCP
{
//UI �]���Otext -------------------------------------------------------------------------------
    public static string text1 = "";
    public static string text2 = "";
    public static int text_cnt = 0;//��ӽ��yshowte text
    //scene Control
    public static int game_mode = 0;//��ӽ��yshowte text
//-------------------------------------------------------------------------------


//PSS-------------------------------------------------------------------------------
    public static int pss_name = 1; //�@�i�h��� "�ŤM���Y��"
    public static bool hint_over = false;
    public static bool hint2_over = false;
    public static bool back = false;
    //
    public static bool hint3_over = false;
    public static bool hint3_paper = false;
    public static bool hint3_sci = false;
    public static bool hint3_stone = false; 
    //�}�l�p�� + �ɶ���
    public static bool countdown = false;
    public static bool timeup = false;
    //�i�Dserver�i�H��pose��T�F
    public static bool scanPose = false;
    //server �ǨӪ�pose
    public static string model_pose = "";
    public static string player_pose = "";
    //winner �O��
    public static int PSS_winer = -1;
    //UI�i���server���w�ʧ@�W��text
    public static bool show_pose_text = false;
    //RESET
    public static bool reset = false;

    //-------------------------------------------------------------------------------



}
