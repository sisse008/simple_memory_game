using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class MessageTextController : Singleton<MessageTextController>
{

    TMP_Text text;
    Coroutine DisplayMessageCoroutine;

    protected override void Awake()
    {
        text = GetComponent<TMP_Text>();
        Clean();
        base.Awake();
    }

    
    public void DisplayMessage(string message)
    {
        DisplayMessageCoroutine = StartCoroutine(IEDisplayMessage(message, 2f));
    }

    IEnumerator IEDisplayMessage(string message, float forSecond)
    { 
        text.text = message;
        yield return new WaitForSeconds(forSecond);
        Clean();
    }

    public void Clean()
    {
        if(DisplayMessageCoroutine != null)
            StopCoroutine(DisplayMessageCoroutine);
        text.text = "";
    }
}
