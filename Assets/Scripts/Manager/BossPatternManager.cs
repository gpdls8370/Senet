using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossPatternManager : Singleton<BossPatternManager>
{
    public enum PatternStates { TwoEye, ThreeKnife }
    public PatternStates nowPatternState;

    private bool PatternRunning = false;
    private bool AllPatternsEnd = false;
    private int nextPatternNum = 0;

    private BossMovement bossMovement;

    [Serializable]
    private struct Pattern
    {
        public PatternStates PatternState;
        public float StartTime;
        public bool UseEndDelay;
        public float EndDelay; 
    }
    [SerializeField] private Pattern[] PatternTimeLine;

    [SerializeField] private PatternBase[] PatternClass;
    

    private void Update()
    {
        if (!PatternRunning && !AllPatternsEnd)
        {
            if (BossChapterManager.Instance.NowTime < PatternTimeLine[nextPatternNum].StartTime 
                && BossChapterManager.Instance.NowTime >= PatternTimeLine[nextPatternNum].StartTime - 0.1f)
            {
                StartPattern(PatternTimeLine[nextPatternNum].PatternState);
            }
        }
    }


    protected override void Awake()
    {
        bossMovement = BossStateManager.Instance.Boss.GetComponent<BossMovement>();
    }

    public void StartPattern(PatternStates pattern)
    {
        PatternRunning = true;
        nowPatternState = pattern;
        bossMovement.PatrolStop();

        PatternClass[(int)nowPatternState].StartPattern();

        if (PatternTimeLine[nextPatternNum].UseEndDelay)
        {
            StartCoroutine(PatternEndDelay(PatternTimeLine[nextPatternNum].EndDelay));
        }
    }

    private IEnumerator PatternEndDelay(float EndDelay)
    {
        yield return new WaitForSeconds(EndDelay);

        StopPattern();
    }

    public void StopPattern()
    {
        PatternRunning = false;
        bossMovement.PatrolStart();

        if (PatternTimeLine[nextPatternNum].UseEndDelay)
        {
            PatternClass[(int)nowPatternState].StopPattern();
        }

        nextPatternNum++;

        if (nextPatternNum >= PatternTimeLine.Length)
        {
            AllPatternsEnd = true;
        }
    }
}
