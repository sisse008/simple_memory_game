using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Text))]
public class StopWatch : MonoBehaviour
{

    TMP_Text m_Text;

    public UnityAction timerStopped;

    private void Awake()
    {
        m_Text = GetComponent<TMP_Text>();
    }
    public void StartWatch(int seconds)
    {
        StartCoroutine(CountDown(seconds));
    }
    
    IEnumerator CountDown(int seconds)
    {
        int seconds_counter = seconds;

        while (seconds_counter >= 0)
        {
            m_Text.text = seconds_counter.ToString();

            seconds_counter--;

            yield return new WaitForSeconds(1);
        }

        timerStopped?.Invoke();
    }
}
