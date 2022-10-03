using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnd = false;
    [SerializeField] GameObject inGame;
    private Player myPlayer;
    EndGameUI endGameUI;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
        endGameUI = FindObjectOfType<EndGameUI>();
        endGameUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.IsDead())
        {
            inGame.SetActive(false);
            endGameUI.gameObject.SetActive(true);
            gameHasEnd = true;
        }
    }
}
