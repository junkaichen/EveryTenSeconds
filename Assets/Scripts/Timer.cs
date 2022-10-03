using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    int TenSecondsLeft = 6;
    float TimePass = 0;
    float TotalTime = 0;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] SpriteMask mySpriteMask;
    private InGameUI inGameUI;
    private Player myPlayer;
    private GameManager myGameManager;
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
        inGameUI = FindObjectOfType<InGameUI>();
        myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!myGameManager.gameHasEnd)
        {
            TotalTime += Time.deltaTime;
            if (TimePass >= 10f)
            {
                TimePass = 0f;
                NextTenSeconds();

                myPlayer.currentStage++;
                inGameUI.Damaged();


            }
            TimePass += Time.deltaTime;
            UpdateTimer(TimePass);
        }
        
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerText.text = string.Format("{00}", seconds);
    }

    private void NextTenSeconds()
    {
        myPlayer.SpeedUp();
        mySpriteMask.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
    }

    public float getSuvivalTime()
    {
        return Mathf.Round(TotalTime);
    }
}
