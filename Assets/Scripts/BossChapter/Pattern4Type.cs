using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern4Type : MonoBehaviour
{
    [SerializeField] private GameObject[] FirstShowObject;
    [SerializeField] private GameObject[] SecondShowObject;
    [SerializeField] private GameObject[] ThirdShowObject;
    [SerializeField] private float ShowDelayTime;

    public void TypeActionStart()
    {
        StartCoroutine(TypeCoroutine());
    }

    public void TypeActionEnd()
    {
        foreach (GameObject bomb in FirstShowObject)
        {
            bomb.SetActive(false);
        }

        foreach (GameObject bomb in SecondShowObject)
        {
            bomb.SetActive(false);
        }

        foreach (GameObject bomb in ThirdShowObject)
        {
            bomb.SetActive(false);
        }
    }

    private IEnumerator TypeCoroutine()
    {
        foreach (GameObject bomb in FirstShowObject)
        {
            bomb.SetActive(true);
        }

        yield return new WaitForSeconds(ShowDelayTime);

        foreach (GameObject bomb in SecondShowObject)
        {
            bomb.SetActive(true);
        }

        yield return new WaitForSeconds(ShowDelayTime);

        foreach (GameObject bomb in ThirdShowObject)
        {
            bomb.SetActive(true);
        }
    }
}
