using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class subtitle : MonoBehaviour
{
    //�Ψ���ܦr����TextUi
    public Text Titles;
    //�ɮ׬y,�Τ_Ū���奻
    StreamReader sr;
    //�奻�����r�������
    int lineCount=0;


    void Start()
    {
        StartCoroutine(Display());
    }

    IEnumerator Display()
    {
        sr= new StreamReader(Application.dataPath + "/text.txt");
        //�إߤ@�Ӭy�A�Τ_Ū�����
        StreamReader srLine = new StreamReader(Application.dataPath + "/text.txt");
        //�`����Ū����ơA���쬰null����
        while(srLine.ReadLine()!=null)
        {
            lineCount++;
        }
        //����������y
        srLine.Close();
        srLine.Dispose();
        for (int i = 0; i < lineCount; i++)
        {
            string tempText = sr.ReadLine();
            Titles.text = tempText.Split('$')[0];
            Debug.Log(Titles.text);
            //�]�N�O
            float tempTime = 0.5f;
            //�N�夤������$3����3Ū���X��
            if(float.TryParse(tempText.Split('$')[1], out tempTime))
            {
                //��{����
                yield return new WaitForSeconds(1);
            }
        }

        //����������y
        sr.Close();
        sr.Dispose();
    }
}