using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class backtoui : MonoBehaviour
{
    Text pose;
    float show_winner_time = 5.0f;
    public AudioSource UnityChanVoice = null;
    public AudioClip[] UnityChanVoiceClips = null;
    float time2 = 2.0f;    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //�i�H���winner + pose
        if (Gobal_TCP.show_pose_text && Gobal_TCP.timeup == true)
        {        //win / lose
            if (Gobal_TCP.PSS_winer == 0)
            {
                UnityChanVoice.clip = UnityChanVoiceClips[0];
                UnityChanVoice.Play();


            }
            else if (Gobal_TCP.PSS_winer == 1)
            {
                UnityChanVoice.clip = UnityChanVoiceClips[0];
                UnityChanVoice.Play();
            }
            else if (Gobal_TCP.PSS_winer == 2)
            {
                UnityChanVoice.clip = UnityChanVoiceClips[1];
                UnityChanVoice.Play();
            }

            //��5���A���(��model�����ʧ@)
            Debug.Log("wait 5s ...");
            StartCoroutine(winner_show(show_winner_time)); //���� IEnumerator
        }
    

    }

    IEnumerator winner_show(float waitTime2)
    {
        yield return new WaitForSeconds(waitTime2);
        pose.text = "�^�D�e��...";
        StartCoroutine(wait2(time2));
    }


    //�̫�
    IEnumerator wait2(float waitTime2)
    {
        yield return new WaitForSeconds(waitTime2);
       

        //�Ҧ��W0
        Gobal_TCP.reset = true;




    }
}
