using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI; //�ϥ�Unity UI�{���w�C (Text�OUI���@�����@! �n�ϥδN�����n�[�A���M�|�X�{���~!)

public class textEffect2 : MonoBehaviour
{

    public Text UIText;

    private float timer;

    // Use this for initialization

    void Start()
    {

        timer = 0.0f;

    }

    // Update is called once per frame

    void Update()
    {

        timer += Time.deltaTime * 2;

        if (timer % 2 > 1.0f)

        {

            UIText.text = "";

        }

        else
        {
            if (Gobal_TCP.pss_name == 1)
            { 

                    UIText.text = "<color=#FF7167>�ŤM</color><color=#19B3B1>���Y</color><color=#FFD73D>��</color>";
            }
        

        }

    }

}