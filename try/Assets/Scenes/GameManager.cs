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
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{
    //cama
    int fi = 0;
    public AudioSource Voice = null;
    public AudioClip[] VoiceClips = null;
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
        /*//��������
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
        }*/
        //���y�ŤM���Y��
        if (varName.cnt_end)
        {
            //�i�Dserver�i�H��
            client.Send(Encoding.UTF8.GetBytes("pose;"));
            varName.cnt_end = false;


        }
        if (varName.game1Over && fi==0)//�i�Dserver�C������
        {
            client.Send(Encoding.UTF8.GetBytes("over;"));
            //fi = 1;
            varName.game1Over = false;
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
        

    }
    /*void recvIMG()
    {
        Debug.Log("recvIMG start");
        while (client.Connected)
        {
            
            var bytes = new byte[1024];
            var count = client.Receive(bytes);
            float dis;
            msg = Encoding.UTF8.GetString(bytes, 0, count);
            //���� scale;123456
            string[] msg_split = msg.Split(';');
            //Debug.Log("����" + msg);
           // Debug.Log("msg[0]" + msg_split[0]);
            //Debug.Log("msg[1]" + msg_split[1]);


            if (msg != null)
            {
                //������openpose �� �^�Ǹ��
                if (msg_split[0] == "scale")
                {
                    //Debug.Log("scale��" + msg_split[1]);
                    dis = (Convert.ToInt32(msg_split[1]));
                    //Debug.Log("scale��(dis)" + dis);
                    varName.img_dis = dis;
                }


            }

        }
       
    }*/
    //�j�馬���
    void recvData()
    {
        int im = 1;
        //�i���Ounity �ݪO
        client.Send(Encoding.UTF8.GetBytes("1"));
        // Thread t_img = new Thread(recvIMG);
        //t_img.Start();
        float dis;
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
                //������openpose �� �^�Ǹ��
                if(msg_split[0]=="pose")
                {
                    Debug.Log("Scan���G" + msg_split[1]);
                    //�Ұ�model�����w�ʧ@
                    
                    //�P�_��Ĺ
                    whoWin(msg_split[1]);
                }                
                if (msg_split[0] == "scale")
                {
                    //Debug.Log("scale��" + msg_split[1]);
                    dis = (Convert.ToInt32(msg_split[1]));
                    Debug.Log("scale��(dis)" + dis);
                    varName.img_dis = dis;
                }


            }

        }
    }
    ////�P�_��Ĺ
    void whoWin(string pose)
    {
        //1st: player 2nd:model
        string[] P = pose.Split(' ');
        string player = P[0];
        string model = P[1] ;
        
        
        //winner : 0=����, 1=model, 2=player
        //model�X�ŤM
        if (model == "1")
        {
            varName.modelPose = "�ŤM Scissor";
            if (player == "1")
            {
                varName.playerPose = "�ŤM Scissor";
                varName.winner = 0;
            }
                
            else if (player == "2")
            {
                varName.winner = 2;
                varName.playerPose = "���Y Stone";

            }
            else
            {
                varName.winner = 1;
                varName.playerPose = "�� Paper";

            }
        }
        //model�X���Y
        else if (model == "2")
        {
            varName.modelPose = "���Y Stone";
            if (player == "1")
            {
                varName.winner = 1;
                varName.playerPose = "�ŤM Scissor";

            }
            else if (player == "2")
            { 
                varName.winner = 0;
                varName.playerPose = "���Y Stone";
            }
            else
            {
                varName.winner = 2;
                varName.playerPose = "�� Paper";
            }
        }
        //model�X��
        else if (model == "3")
        {
            varName.modelPose = "�� Paper";
            if (player == "1")
            {
                varName.winner = 2;
                varName.playerPose = "�ŤM Scissor";
            }
            else if (player == "2")
            {
                varName.winner = 1;
                varName.playerPose = "���Y Stone";
            }
            else
            {
                varName.winner = 0;
                varName.playerPose = "�� Paper";

            }
        }
        Debug.Log("winner=" + varName.winner);
        //1.��model�����w�ʧ@
        varName.model_start_animation = true;


    }
    void loadToPSS()
    {

        varName.mode = 1;
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