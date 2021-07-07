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
using System.Collections.Concurrent;
/*
line 127: �ק���ܳӭt�ɶ�
line 53:�ק�model���ʧ@
*/
/*

public class PSS_contrrol : MonoBehaviour
{

    //animation
    public Animator UnityChanControl = null;
    public int player = 0;
    public int model = 0;
    int winner = -1;//Ĺ�a

    //TCP socket
    public string IP = "192.168.56.1";
    public int Port = 8000;
    public Socket client;

    //other
    public bool start = false; //update��
    public float waitTime = 5.0f;
    //TEXT
    public GameObject player_text;
    public GameObject model_text;
    //���wstring���e
    public string str_player = " ";
    public string str_model = " ";
    float model_move_time = 16.0f;
    float show_winner_time = 18.0f;


    // Start is called before the first frame update
    void Start()
    {


        //animation �ܼƪ�l��
        start = false;

        //�إ߳s�u
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(IP, Port);

        Thread t = new Thread(recvData);
        t.Start();
       

    }
    
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(tcpStart(model_move_time)); //���� IEnumerator
        if (start == true)
        {

 
            Debug.Log("showPse()::model==" + model);
            //�ŤM���Y�� animation Ĳ�o
            if (model == 1)
            {
                UnityChanControl.SetBool("start", true);
                UnityChanControl.SetBool("scissor", true);
                UnityChanControl.SetBool("stone", false);
                UnityChanControl.SetBool("paper", false);
                Debug.Log("�ŤM");
                str_model = "�ŤMScissor";

            }
            else if (model == 3)
            {
                UnityChanControl.SetBool("start", true);
                UnityChanControl.SetBool("scissor", false);
                UnityChanControl.SetBool("stone", false);
                UnityChanControl.SetBool("paper", true);
                str_model = "��Paper";
                Debug.Log("��");

            }
            else if(model == 2)
            {
                UnityChanControl.SetBool("start", true);
                UnityChanControl.SetBool("scissor", false);
                UnityChanControl.SetBool("stone", true);
                UnityChanControl.SetBool("paper", false);
                str_model = "���YStone";
                Debug.Log("���Y");
            }

            if (player == 1)
            {
                str_player = "�ŤMScissor";
            }
            else if (player == 2)
            {
                str_player = "���YStone";
            }
            else if (player == 3)
            {
                str_player = "��Paper";
            }

           
            start = false;
            

        }
        else
        {
            Debug.Log("Hi");


        }
        //��3���A���
        StartCoroutine(winner_show(show_winner_time)); //���� IEnumerator

    }


    //����server�ǰŤM���Y����T
    void recvData()
    {


        client.Send(Encoding.UTF32.GetBytes("PSS"));
        if (client.Connected)
        {
            Debug.Log("RECV:");
            var bytes = new byte[1024];
            var count = client.Receive(bytes);
            string msg = Encoding.UTF8.GetString(bytes, 0, count);

            if (msg != null)
            {
                Debug.Log("msg[0]" + msg[0]);//model��pose
                Debug.Log("msg[2]" + msg[2]);//player��pose
                //�ରint���A
                model = (Convert.ToInt32(msg[0])) - 48;
                player = (Convert.ToInt32(msg[2])) - 48;
                //�p��Ĺ�a�O��
                whoIsWinner();
                
                //��model���w�ʧ@
                
                //showPose();

            }

        }
    }
    void whoIsWinner()
    {
        //(�ŤM,���Y,��) = (1,2,3)
        //winner : 0=����, 1=model, 2=player
       
        //model�X�ŤM
        if (model==1 )
        {
            if (player == 1)
                winner = 0;
            else if (player == 2)
                winner = 2;
            else
                winner = 1;
        }
        //model�X���Y
        else if (model == 2)
        {
            if (player == 1)
                winner = 1;
            else if (player == 2)
                winner = 0;
            else
                winner = 2;
        }
        //model�X��
        else if (model==3)
        {
            if (player == 1)
                winner = 2;
            else if (player == 2)
                winner = 1;
            else
                winner = 0;
        }
      
    }

    //10���}�lmove
    IEnumerator tcpStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        start = true;
    }
    //3���b���pose && �ӭt
    IEnumerator winner_show(float waitTime2)
    {
        yield return new WaitForSeconds(waitTime2);

        //GET
        GameObject.Find("player_pose_text").GetComponent<Text>().text = str_player;
        GameObject.Find("model_pose_text").GetComponent<Text>().text = str_model;
        mode_num.effect = winner;
        Debug.Log(" mode_num.effect:" + mode_num.effect);
    }


    */

    /*
void showPose()
{
    Debug.Log("showPse()::model==" + model);
    if (model == 1)
    {
        scissors();
        Debug.Log("�ŤM");
    }
    else if (model == 2)
    {
        Stone();
        Debug.Log("���Y");
    }
    else if (model == 3)
    {
        Paper();
        Debug.Log("��");
    }
}*/

    /*
    //�ŤM���Y�� animation Ĳ�o
    public void scissors()
    {
        UnityChanControl.SetBool("scissor", true);
        UnityChanControl.SetBool("stone", false);
        UnityChanControl.SetBool("paper", false);

    }
    public void Stone()
    {
        UnityChanControl.SetBool("scissor", false);
        UnityChanControl.SetBool("stone", true);
        UnityChanControl.SetBool("paper", false);

    }
    public void Paper()
    {
        UnityChanControl.SetBool("scissor", false);
        UnityChanControl.SetBool("stone", false);
        UnityChanControl.SetBool("paper", true);
    }
    */


//}
