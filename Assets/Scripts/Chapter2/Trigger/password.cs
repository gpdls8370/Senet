﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class password : MonoBehaviour
{

    public InputField m_InputField;
    public Text m_Text;
    public int cn = 0;
    public bool 2fpassword = false;
    string answer = "HOPE"

    void Update()
    {
    for(int i=0; i<4; i++)
        {
            if (m_InputField[i] != answer[i])
            {
                2fpassword = false;
                cn++;
            }
            else if(m_InputField[i] == answer[i] && cn==0)
                2fpassword = true;
        }

    }
}
