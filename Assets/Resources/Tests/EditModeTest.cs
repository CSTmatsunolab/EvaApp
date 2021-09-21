using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class EditModeTest : MonoBehaviour
{



    [Test]
    public void Test1()
    {
        float a = 2f;
        float b = 3f;

        float result = Mathf.Pow(a, b);

        Assert.That(result, Is.EqualTo(8f));
    }
    [Test]
    public void Test2()
    {
        float a = 2f;
        float b = 3f;

        float result = Mathf.Pow(a, b);

        Assert.That(result, Is.EqualTo(6f));
    }
}
