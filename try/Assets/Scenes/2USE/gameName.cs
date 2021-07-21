using System.Collections;

using System.Collections.Generic;
using System.IO;
using UnityEngine;

using UnityEngine.UI; //�ϥ�Unity UI�{���w�C (Text�OUI���@�����@! �n�ϥδN�����n�[�A���M�|�X�{���~!)

public class gameName : MonoBehaviour
{

    public Text NameText;
    public Text Intro_titleText;
    public Text Gift;
    private float timer;
    int gamName_cnt = 0;
    //img
    public GameObject img;
    public GameObject trash_img;
    public GameObject phone_img;
    public GameObject candy2_img;
    public GameObject bg2_img;
    public GameObject lose_img;
    public GameObject win_img; 
    public GameObject heart;
    public GameObject cry;

    public Animator UnityChanControl = null;
    //content
    public Text content;
    private string words; 
    private float timer2 = 0.01f;
    private bool isPrint = false;
    private float perCharSpeed = 0.5f;
    private float timer3 = 0.01f;
    private bool isPrint2 = false;
    private float perCharSpeed2 = 0.5f;

    //�ܽd
    int lineCount = 0;
    int lineCount2 = 0;
    public Text PSS_name ;
    public Text PSS_detail ;
    StreamReader sr;
    StreamReader sr2;

    //count donw
    public Text CountD; 
    int time_int = 4;

    //pose
    public Text pPose;
    public Text mPose;
    public Text Winner;
    //PRIZE
    //public Text prizeText;
    RectTransform rt;
    float scale = 1.6f;
    int y = 174;
    public Text backto;
    
    
    void Start()
    {
        //content
        words = "�Q�Ψ���ʧ@���ŤM���Y��\n" +
            "�ݷ|��unity chan�ܽd�ʧ@\n"
            + "�Цb�p�ɵ����e�\�n����!\n"
            + "�ӧQ�i�H��o�P��";
        isPrint = true;
        timer = 0.0f;
        // Gift.text.SetActive(false);
        Gift.text = "";

        rt = candy2_img.GetComponent<RectTransform>();
        img.SetActive(false);

        trash_img.SetActive(false);
        phone_img.SetActive(false);
        candy2_img.SetActive(false);
        bg2_img.SetActive(false);
        lose_img.SetActive(false);
        win_img.SetActive(false);
        heart.SetActive(false);
        cry.SetActive(false);

        backto.text = "";
    }

    // Update is called once per frame

    void Update()
    {
        ///"����ŤM���Y��"
        if (varName.gameName_show)
        {
            
            timer += Time.deltaTime * 2;
            gamName_cnt++;
            if (timer % 2 > 1.0f)

            {

                NameText.text = "";

            }

            else
            {
                
                //Debug.Log(timer);
                NameText.text = "����\n<color=#FF7167>�ŤM</color><color=#19B3B1>���Y</color><color=#FFD73D>��</color>";
                if(timer > 5.5)
                {
                    NameText.text = "";
                    varName.gameName_show = false;
                    varName.introTitle_show = true;
                }
            }
        }
        //"�C������"
        if(varName.introTitle_show)
        {
           
            Intro_titleText.text = "�C������";
            StartCoroutine(wait(1.5f,1));
            
        }
        //�C���������e
        if(varName.introContent_show)
        {
            printText(words);
        }

        //������ܽd
        if(varName.pss_detail_show && varName.pss_name_show)
        {
            Intro_titleText.text = "�ʧ@�ܽd";
            //Debug.Log("�ʧ@�ܽd");
            StartCoroutine(Display1());
            StartCoroutine(Display2());
        }

        //model�i�ܫ��w�ʧ@ (����openpose��������)
        if(varName.model_start_animation)
        {
            varName.model_start_animation = false;

            Debug.Log("model_start_animation");
            UnityChanControl.SetBool("start", true);
            //���ŤM
            if (varName.modelPose == "�ŤM Scissor")
            {
                UnityChanControl.SetBool("scissor", true);
                UnityChanControl.SetBool("stone", false);
                UnityChanControl.SetBool("paper", false);
                //StartCoroutine(win_lose(3.5f, 1));


            }//�����Y
            else if (varName.modelPose == "���Y Stone")
            {
                UnityChanControl.SetBool("scissor", false);
                UnityChanControl.SetBool("stone", true);
                UnityChanControl.SetBool("paper", false);
               // StartCoroutine(win_lose(3.5f, 2));
            }//����
            else if (varName.modelPose == "�� Paper")
            {
                UnityChanControl.SetBool("scissor", false);
                UnityChanControl.SetBool("stone", false);
                UnityChanControl.SetBool("paper", true);
               // StartCoroutine(win_lose(3.5f, 3));

            }
            //��1.5��b���ʧ@
            StartCoroutine(wait(3.0f, 4));
            //��1.5��bprint����pose

        }
  


    }



    IEnumerator wait(float waitTime,int type)
    {
       // Debug.Log("wait....");
        yield return new WaitForSeconds(waitTime);
       // Debug.Log("wait....over");
        if(type==1)//
        {
            //Intro_titleText.text = "";
            //varName.introTitle_show = false;
            varName.introContent_show = true;
        }
        if(type==2)// �����ܽd
        {
            Intro_titleText.text = "";
            NameText.text = "";
            content.text = "";
            varName.introTitle_show = false;
            varName.introContent_show = false;
            Gift.text = "";
            img.SetActive(false);

            //�Ұ�
            //PSS_detail.text = "�ŤM";
            varName.pss_detail_show = true;
            varName.pss_name_show = true;

        }
        if(type==4) //
        {
            Debug.Log("type4");

            pPose.text = varName.playerPose;
            mPose.text = varName.modelPose;

            //��Pose
            if (varName.modelPose == "�ŤM Scissor")
                UnityChanControl.SetBool("ScOver", true);

            else if (varName.modelPose == "���Y Stone")
                UnityChanControl.SetBool("StOver", true);

            else if (varName.modelPose == "�� Paper")
                UnityChanControl.SetBool("paOver", true);


            //�b��1.5s �L���嵲�G
            StartCoroutine(wait(1.5f, 5));
        }
        if(type==5)
        {
            Debug.Log("type5");
            if (varName.winner == 1)//model win
            {
                Winner.text = "YOU LOSE";
                UnityChanControl.SetBool("Win", true);
            }
            else if (varName.winner == 0)//model win
            {
                Winner.text = "TIE";
                UnityChanControl.SetBool("Win", true);
            }
            else if (varName.winner == 2)//player win
            {
                Winner.text = "YOU WIN";
                UnityChanControl.SetBool("Lose", true);
            }
            ////�b��2s �i�J�{�o���~
            StartCoroutine(wait(3.0f, 6));
            

        }
        if(type == 6)// �i�J�{�o���~
        {
            varName.getPrize = varName.winner;
            ceremony();
        }
        if(type==7)
        {
            backto.text = "�^�D�e����...";
            varName.game1Over = true;
            //3s��^UI
            StartCoroutine(wait(3.0f,8));
        }
        if(type==8)//just stop for candy go down
        {

            //�W0
            varName.gameName_show = true;
            varName.pss_name = 1;
            varName.introTitle_show = false;
            varName.introContent_show = false;
            varName.gift_show = false;
            varName.pss_name_show = false;
            varName.pss_detail_show = false;
            varName.cnt_start = false;
            varName.cnt_end = false;
            varName.modelPose = "";
            varName.playerPose = "";
            varName.model_start_animation = false;
            varName.winner = -1;
            varName.getPrize = -1;
            varName.game1Over = false;
     


            varName.mode = 0;
        }

    }



    // //�{�o���~-----------------------------------------------------------------------
    void ceremony ()
    {
        bg2_img.SetActive(true);

        if (varName.winner == 2 || varName.winner == 0)//pleyer win or tie �����~
        {
            win_img.SetActive(true);
            phone_img.SetActive(true);
            candy2_img.SetActive(true);
            InvokeRepeating("goDown", 1, 0.2f);

        }
        else if (varName.winner == 1)//model win �L���~
        {
     
            lose_img.SetActive(true);
            trash_img.SetActive(true);
            candy2_img.SetActive(true);
            InvokeRepeating("goDown", 1, 0.2f);
        }

    }
    //----------------------------------------------------------------------------------
    void goDown()
    {
  
        Debug.Log("scale=" + scale); 
        Debug.Log("y=" + y);
        scale -= 0.05f;
        y -= 35;
        rt.localScale = new Vector3(scale, scale, scale);
        rt.localPosition = new Vector3(44, y, 0);
        if(y <= -350)
        {
            CancelInvoke("goDown");
            if (varName.winner == 2 || varName.winner == 0)//pleyer win or tie �����~
                heart.SetActive(true);
            else
                cry.SetActive(true);

            //
            
            //1.5s��L "�^�D�e��"
            StartCoroutine(wait(1.5f, 7));

        }

    }


    //�@��@��-----------------------------------------------------------------------
    IEnumerator Display1()
    {
        varName.pss_name_show = false;
           sr = new StreamReader(Application.dataPath + "/name.txt");
        //�إߤ@�Ӭy�A�Τ_Ū�����
        StreamReader srLine = new StreamReader(Application.dataPath + "/name.txt");
        //�`����Ū����ơA���쬰null����
        while (srLine.ReadLine() != null)
        {
            lineCount++;
        }
        //����������y
        srLine.Close();
        srLine.Dispose();
        //Game name show over
        for (int i = 0; i < lineCount; i++)
        {
            string tempText = sr.ReadLine();
            PSS_name.text = tempText.Split('$')[0];
           // Debug.Log(PSS_name.text);
            //�]�N�O
            float tempTime;
            //�N�夤������$3����3Ū���X��
            if (float.TryParse(tempText.Split('$')[1], out tempTime))
            {
                //��{����
                yield return new WaitForSeconds(tempTime);
            }
            if (i == 0)
            {
                Debug.Log("Ĳ�o�ŤM");
                UnityChanControl.SetBool("showSc", true);
            }
            if (i == 2)
            {
                Debug.Log("Ĳ�o���Y");
                UnityChanControl.SetBool("showSt", true);
            }
            if (i == 4)
            {
                Debug.Log("Ĳ�o��");
                UnityChanControl.SetBool("showPa", true);
            }
            if (i == 6)
            {
                Debug.Log("Ĳ�o��");
                UnityChanControl.SetBool("back", true);
            }
            if (i == 16)
            {
                Intro_titleText.text = " ";
                varName.cnt_start = true;
                InvokeRepeating("countdown", 1, 1);
            }
        }


        //����������y
        sr.Close();
        sr.Dispose();
    }
    
  IEnumerator Display2()
  {
      sr2 = new StreamReader(Application.dataPath + "/detail.txt");
      //�إߤ@�Ӭy�A�Τ_Ū�����
      StreamReader srLine2 = new StreamReader(Application.dataPath + "/detail.txt");
      //�`����Ū����ơA���쬰null����
      while (srLine2.ReadLine() != null)
      {
          lineCount2++;
      }
      //����������y
      srLine2.Close();
      srLine2.Dispose();
      //Game name show over
      for (int i = 0; i < lineCount2; i++)
      {
          string tempText = sr2.ReadLine();
          PSS_detail.text = tempText.Split('$')[0];
         // Debug.Log(PSS_detail.text);
          //�]�N�O
          float tempTime;
          //�N�夤������$3����3Ū���X��
          if (float.TryParse(tempText.Split('$')[1], out tempTime))
          {
              //��{����
              yield return new WaitForSeconds(tempTime);
          }


      }


      //����������y
      sr2.Close();
      sr2.Dispose();
  }
  //-----------------------------------------------------------------------
  

    //�v�r--------------------------------------------------------------------------
    void printText(string words)
    {
        try
        {
            if (isPrint)
            {

                content.text = words.Substring(0, (int)(perCharSpeed * timer2));//�I��
               // Debug.Log(words.Substring(0, (int)(perCharSpeed * timer2)));
                timer2 += Time.deltaTime * 30;

            }
        }
        catch (System.Exception)
        {
            printEnd();
        }
    }
    
    void printEnd()
    {
        Gift.text = "�p§���I";
        img.SetActive(true);
        isPrint = false;


        //��n�� �����ܽd
        StartCoroutine(wait(3.0f, 2));
       
     

    }
    //----------------------------------------------------------------------------------------
    
    //�˼�--------------------------------------------------------------------------------------
    void countdown()
    {
        

        //Debug.Log("start cd" + time_int);
        time_int -= 1;
        if (time_int <= 5)
        {
            CountD.text = time_int + "";
        }

        if (time_int == 0)
        {

            CountD.text = "";
            CancelInvoke("countdown");
            varName.cnt_end = true;//�i�Dopenpose�i���y
        }


        

    }
    //----------------------------------------------------------------------------------------
}