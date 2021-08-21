using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBase : MonoBehaviour
{

    public virtual void StartPattern()
    {

    }

    public virtual void StopPattern()
    {
        Reset();
    }

    public virtual void Reset()
    {

    }
}
