using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking_Text : MonoBehaviour
{
    //Text fade help https://answers.unity.com/questions/661882/blinking-gui-text-question.html
    
    float speed = 2.0f;
    public Text Text;
    Color currentColor;
 
    // Update is called once per frame
    void Update()
    {
        currentColor = Text.color;
        /////////////////////////////////////////////////////////////////////////////////////////////
        //Use this for blinking on and off
        //currentColor = Mathf.Round(Mathf.PingPong(Time.time * speed, 1.0f));

        //Use this for fade in and out
        //currentColor = = Mathf.PingPong(Time.time * speed, 1.0f);

        // Use this for fade in and out with smoother ends (sinusoidal)
        currentColor.a = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        Text.color = currentColor;

    }
}

/*
 * 
 * 
 */