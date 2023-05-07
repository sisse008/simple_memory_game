using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class Hoverrable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    [Serializable]
    public class ButtonHoverEvent : UnityEvent { }

    [SerializeField]
    public ButtonHoverEvent OnHover;

    public ButtonHoverEvent OnExit;

    Button b;

    private void Awake()
    {
        b = GetComponent<Button>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(b.IsInteractable())
            OnExit?.Invoke();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (b.IsInteractable())
            OnHover?.Invoke();
    }
}
