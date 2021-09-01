using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private RectTransform ClockHandTr;

    private float z;

    private void Update()
    {
        z = BossChapterManager.Instance.NowTime / BossChapterManager.Instance.TotalBossTime * 360;

        ClockHandTr.localEulerAngles = new Vector3(0, 0, z);
    }
}
