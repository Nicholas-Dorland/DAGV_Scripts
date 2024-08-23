using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    public AnimationCurve bulletTimeScale;
    bool m_IsUsingBulletTime;
    float m_UnscaledElapsedTime;
    public void StartBulletTime()
    {
        m_UnscaledElapsedTime = 0f;
        m_IsUsingBulletTime = true;
    }
    void Update()
    {
        if (m_IsUsingBulletTime)
        {
            Time.timeScale = bulletTimeScale.Evaluate(m_UnscaledElapsedTime);
            m_UnscaledElapsedTime += Time.unscaledDeltaTime;
            if (m_UnscaledElapsedTime > bulletTimeScale[bulletTimeScale.length - 1].time)
            {
                m_IsUsingBulletTime = false;
            }
        }

        else
        {
            Time.timeScale = 1f;
        }
    }
}
