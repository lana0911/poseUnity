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
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //int game = mode_num.mode;
    public string IP = "192.168.56.1";
    public int Port = 8000;
    public int mode_int = 0;
    public Socket client;
    int i = 0;
    string msg = "";
    string pose = "";
    int now_cnt = Gobal_TCP.text_cnt;
    int winner;

    static GameManager instance;
    //TCP socket �h����
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            name = "first_game";
        }
        else if (this != instance && instance != null)
        {
            string ScenName = SceneManager.GetActiveScene().name;
            Debug.Log("�R��" + ScenName + "��" + name);
            Destroy(gameObject);
        }

    }
    /// <summary>
    /// ////////////////////////////////////////////////////////
    /// </summary>
    //�Nserver���e��s�W�h
    void Update()
    {
        //��������
        if (Gobal_TCP.game_mode == 0)
        {
            SceneManager.LoadScene(0);
            Debug.Log("switch Sence 0 (UI)");
        }
        else if (Gobal_TCP.game_mode == 1)
        {
            SceneManager.LoadScene(1);
            Debug.Log("switch Sence 1 (PSS Game)");
        }
        else if (Gobal_TCP.game_mode == 2)
        {
            SceneManager.LoadScene(2);
            Debug.Log("switch Sence 2 (Dance Game)");
        }
        //���y�ŤM���Y��
        if (Gobal_TCP.scanPose)
        {
            //�i�Dserver�i�H��
            client.Send(Encoding.UTF8.GetBytes("pose;"));

            //
            Gobal_TCP.scanPose = false;
            
        }

    }
    //�إ߳s�u
    void Start()
    {
        Debug.Log("hi" + i);
        i++;
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(IP, Port);
        Thread t = new Thread(recvData);
        t.Start();
        SceneManager.LoadScene(3);

    }
    //�j�馬���
    void recvData()
    {
        int im = 1;
        //�i���Ounity �ݪO
        client.Send(Encoding.UTF8.GetBytes("1"));
        while (client.Connected)
        {
            Debug.Log("switch recv:");
            //����T���d�� : text;welcome
            var bytes = new byte[1024];
            var count = client.Receive(bytes);
            msg = Encoding.UTF8.GetString(bytes, 0, count);
            //����
            string[] msg_split = msg.Split(';');
            Debug.Log("����" + msg);
            Debug.Log("msg[0]" + msg_split[0]);
            //Debug.Log("msg[1]" + msg_split[1]);

            
            if (msg != null)
            {
                if (msg_split[0] == "text")
                {
                    pamadan(msg_split[1]);
                }
                else if(msg_split[0] == "game1")
                {
                    Debug.Log("����game1");
                    loadToPSS();
                }
                //�p�G�O���ŤM���Y�� �� �^�Ǹ��
                if(msg_split[0]=="pose")
                {
                    Debug.Log("Scan���G" + msg_split[1]);
                    //�Ұ�model�����w�ʧ@
                    
                    //�P�_��Ĺ
                    whoWin(msg_split[1]);
                }


            }

        }
    }
    ////�P�_��Ĺ
    void whoWin(string pose)
    {
        string[] P = pose.Split(' ');
        string player = P[0];
        string model = P[1] ;
        Gobal_TCP.player_pose = player;
        Gobal_TCP.model_pose = model;
        //winner : 0=����, 1=model, 2=player
        //model�X�ŤM
        if (model == "1")
        {
            if (player == "1")
                Gobal_TCP.PSS_winer = 0;
            else if (player == "2")
                Gobal_TCP.PSS_winer = 2;
            else
                Gobal_TCP.PSS_winer = 1;
        }
        //model�X���Y
        else if (model == "2")
        {
            if (player == "1")
                Gobal_TCP.PSS_winer = 1;
            else if (player == "2")
                Gobal_TCP.PSS_winer = 0;
            else
                Gobal_TCP.PSS_winer = 2;
        }
        //model�X��
        else if (model == "3")
        {
            if (player == "1")
                Gobal_TCP.PSS_winer = 2;
            else if (player == "2")
                Gobal_TCP.PSS_winer = 1;
            else
                Gobal_TCP.PSS_winer = 0;
        }
        Debug.Log("winner=" + Gobal_TCP.PSS_winer);
        
    }
    void loadToPSS()
    {

        Gobal_TCP.game_mode = 1;
    }

    //--UI--�]���O
    void pamadan(string content)
    {
        Debug.Log("PamaDan center = " + content);
       
        Debug.Log("Gobal_TCP.text_cnt = " + Gobal_TCP.text_cnt);
        if (Gobal_TCP.text_cnt == now_cnt)
        {
           if (Gobal_TCP.text_cnt % 2 == 0)
                {
                    Gobal_TCP.text1 = content;
                    Gobal_TCP.text_cnt++;
                    now_cnt = Gobal_TCP.text_cnt;
                }
                else if (Gobal_TCP.text_cnt % 2 == 1)
                {
                    Gobal_TCP.text2 = content;
                    Gobal_TCP.text_cnt++;
                    now_cnt = Gobal_TCP.text_cnt;
                }
        }
     
    }




}