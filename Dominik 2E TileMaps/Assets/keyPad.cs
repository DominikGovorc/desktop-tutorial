using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPad : MonoBehaviour
{
    public Text text; 
    public doorKeyPad door;
    public int[] numberSaver;
    public int currentNumber;
    public int[] password;
    private float targetTime;
    public float startTargetTime;
    private void Start()
    {
        targetTime = startTargetTime;
    }
    private void Update()
    {
        if (currentNumber == 0)
        {
            text.text = "";
        }
        if (currentNumber==1)
        {
            text.text = "" + numberSaver[0];
        }
        else if(currentNumber==2)
        {
            text.text = "" + numberSaver[0] + numberSaver[1];
        }
        else if (currentNumber == 3)
        {
            text.text = "" + numberSaver[0] + numberSaver[1] + numberSaver[2];
        }
        else if (currentNumber == 4)
        {
            text.text = "" + numberSaver[0] + numberSaver[1] + numberSaver[2] + numberSaver[3];
        }
        else if (currentNumber == 5)
        {
            text.text = "" + numberSaver[0] + numberSaver[1] + numberSaver[2] + numberSaver[3] + numberSaver[4];
        }

        if (currentNumber == 5)
        {
            if (numberSaver[0] == password[0] && numberSaver[1] == password[1] && numberSaver[2] == password[2] && numberSaver[3] == password[3] && numberSaver[4] == password[4])
            {
                door.doorOpen = true;
            }
            else
            {
                targetTime -= Time.deltaTime;

                if (targetTime <= 0.0f)
                {
                    ResetSaver();
                    targetTime = startTargetTime;
                }
            }
        }
    }

    public void One()
    {
        numberSaver[currentNumber] = 1;
        currentNumber++;
    }
    public void Two()
    {
        numberSaver[currentNumber] = 2;
        currentNumber++;
    }
    public void Three()
    {
        numberSaver[currentNumber] = 3;
        currentNumber++;
    }
    public void Four()
    {
        numberSaver[currentNumber] = 4;
        currentNumber++;
    }
    public void Five()
    {
        numberSaver[currentNumber] = 5;
        currentNumber++;
    }
    public void Six()
    {
        numberSaver[currentNumber] = 6;
        currentNumber++;
    }
    public void Seven()
    {
        numberSaver[currentNumber] = 7;
        currentNumber++;
    }
    public void Eight()
    {
        numberSaver[currentNumber] = 8;
        currentNumber++;
    }
    public void Nine()
    {
        numberSaver[currentNumber] = 9;
        currentNumber++;
    }
    public void Zero()
    {
        numberSaver[currentNumber] = 0;
        currentNumber++;
    }
    public void ButtonValue(int value)
    {
        if(currentNumber-1<=numberSaver.Length)
        {
            numberSaver[currentNumber] = value;
            currentNumber++;
        }
    }
    public void ResetSaver()
    {
        currentNumber = 0;
        foreach(int a in numberSaver)
        {
            int i=0;
            numberSaver[i] = 0;
            i++;
        }
    }
}
