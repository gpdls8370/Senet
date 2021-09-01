using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class password : MonoBehaviour
{

    public InputField m_InputField;
    public Text m_Text;
    public int cn = 0;
    public bool password2f = false;
    string answer = "HOPE";

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            /*if (m_InputField[i] != answer[i])
            {
                password2f = false;
                cn++;
            }
            else if(m_InputField[i] == answer[i] && cn==0)
                password2f = true;
        }*/

        }
    }
}
