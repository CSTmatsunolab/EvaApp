using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class EditModeTest : MonoBehaviour
{
    //[Test]
    //public void Test1()
    //{
    //    float a = 2f;
    //    float b = 3f;

    //    float result = Mathf.Pow(a, b);

    //    Assert.That(result, Is.EqualTo(8f));
    //}

    [Test]
    public void Test1()
    {
        int[] Datas = new int[8];
        Datas[0] = 10;
        Datas[1] = 10;
        Datas[2] = 2;
        Datas[3] = 3;
        Datas[4] = 10;
        Datas[5] = 1;
        Datas[6] = 0;
        Datas[7] = 0;

        for (int i = 0; i < Datas.Length; i++)
        {
            Debug.Assert(Datas[i] >= 0);
            Debug.Log("正しい値です");
        }
    }
    [Test]
    public void Test2()
    {
        int[] Datas = new int[8];
        Datas[0] = -10;
        Datas[1] = 10;
        Datas[2] = -2;
        Datas[3] = 3;
        Datas[4] = -10;
        Datas[5] = 1;
        Datas[6] = 0;
        Datas[7] = 0;

        int count = 0;

        for (int i = 0; i < Datas.Length; i++)
        {
            if (Datas[i] < 0)
            {
                count++;
            }
        }
        Debug.Assert(count >= 0);
        Debug.Log(count + "個、値にマイナスを含んでいます");
    }
    [Test]
    public void Test3()
    {
        int[] Datas = new int[8];
        Datas[0] = 100;
        Datas[1] = 10;
        Datas[2] = 20;
        Datas[3] = 3;
        Datas[4] = 10;
        Datas[5] = 1;
        Datas[6] = 0;
        Datas[7] = 0;

        int count = 0;

        for (int i = 0; i < Datas.Length; i++)
        {
            if (Datas[i] > 10)
            {
                count++;
            }
        }
        Debug.Assert(count >= 0);
        Debug.Log(count + "個、値が上限を超えています");
    }
}
