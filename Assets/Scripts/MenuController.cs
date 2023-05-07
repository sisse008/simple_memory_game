using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button startGame;

    public Button saveGame;

    public Button loadGame;

    private void OnEnable()
    {
        startGame.onClick.AddListener(()=>GameManager.Instance.StartGame(false));
        saveGame.onClick.AddListener(GameManager.Instance.SaveGame);
        loadGame.onClick.AddListener(() => GameManager.Instance.StartGame(true));

        GameManager.Instance.OnGameStarted += () => FreezeMenu(false);
        GameManager.Instance.OnGameEnded += () => FreezeMenu(true);

    }

    private void OnDisable()
    {
        startGame.onClick.RemoveAllListeners();
        saveGame.onClick.RemoveAllListeners();
        loadGame.onClick.RemoveAllListeners();
    }

    public void FreezeMenu(bool interactive)
    {
        startGame.interactable = interactive;
        saveGame.interactable = interactive;
        loadGame.interactable = interactive;
    }
}
