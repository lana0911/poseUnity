using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class m_pose : MonoBehaviour
{
    Text pose;
    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //�i�H���winner + pose
        if (Gobal_TCP.show_pose_text && Gobal_TCP.timeup ==true)
        {
            if (Gobal_TCP.model_pose == "1")
                pose.text = "�ŤMSicssor";
            else if (Gobal_TCP.model_pose == "2")
                pose.text = "���YStone";
            else if (Gobal_TCP.model_pose == "3")
                pose.text = "��Paper";
        }
        else
        {
            pose.text = " ";
        }
    }
}
