using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] BoardController board;

    [SerializeField] GameAssetsHolder spritesHolder;

    [SerializeField] StopWatch stopWatch;

    [SerializeField] Image blocker;

    [SerializeField] MemoryManager memoryManager;

    [SerializeField] int gameTime = 30;


    GameData gameData;

    bool activeGame;

 
    public UnityAction OnGameStarted;
    public UnityAction OnGameEnded;

    public const int NUM_OF_CARDS = 16;
    public const int NUM_OF_ROWS = 4;
    public const int NUM_OF_COLUMNS = 4;
    public const int NUM_OF_SPRITES = 8;


    public Sprite GetSpriteFromIndex(int index)
    {
        if (index < 0 || index > NUM_OF_SPRITES-1)
        {
            MessageTextController.Instance.DisplayMessage("SpriteIndex out of Range. returning default sprite");
            return spritesHolder.Sprites[0];
        }
        return spritesHolder.Sprites[index];
    }

    private void OnEnable()
    {
        stopWatch.timerStopped += EndGame;
    }
    private void OnDisable()
    {
        stopWatch.timerStopped -= EndGame;
    }

    public void StartGame(bool load)
    {
        if (activeGame)
            return;

        if (load)
            gameData = memoryManager.GetGameData();
        else
            gameData = new GameData(true);


        if (gameData.newGame)
            SetCardSpritesIndexis(gameData);

        board.SetGameBoard(gameData);

        blocker.enabled = false;

        stopWatch.StartWatch(gameTime);

        activeGame = true;

        OnGameStarted?.Invoke();
    }

    void EndGame()
    {
        blocker.enabled = true;
        activeGame = false;
        OnGameEnded?.Invoke();
    }

    public void SaveGame()
    {
        if (activeGame || gameData == null)
            return;
        memoryManager.SaveGameData(gameData);
    }

    void SetCardSpritesIndexis(GameData gameData)
    {
        List<(int row, int column)> cardPositions = new List<(int, int)>()
        {
            (1,1), (1,2),(1,3), (1,4), 
            (2,1), (2,2), (2,3), (2,4),
            (3,1), (3,2), (3,3), (3,4),
            (4,1), (4,2), (4,3), (4,4)
        };

        for(int sprite_index=0; sprite_index<NUM_OF_SPRITES; sprite_index++)
        { 
            int _rand1 = Random.Range(0, cardPositions.Count);

            (int row, int column) rand1 = cardPositions[_rand1];
            gameData.cards[
               rand1.row - 1, rand1.column - 1].spriteIndex = sprite_index;
            cardPositions.Remove(rand1);

            int _rand2 = Random.Range(0, cardPositions.Count);

            (int row, int column) rand2 = cardPositions[_rand2];
            gameData.cards[
                rand2.row-1, rand2.column-1].spriteIndex = sprite_index; 
            cardPositions.Remove(rand2);
        }
    }

  

}
