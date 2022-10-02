using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    int TenSecondsLeft = 6;
    [SerializeField] float TimePass = 0;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] SpriteMask mySpriteMask;
    private Player myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimePass >= 10f)
        {
            TimePass = 0f;
            NextTenSeconds();


        }
        TimePass += Time.deltaTime;
        UpdateTimer(TimePass);
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
      /*  float minutes = Mathf.FloorToInt(currentTime / 60);*/
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerText.text = string.Format("{00}", seconds);
    }

    private void NextTenSeconds()
    {
        myPlayer.SpeedUp();
        mySpriteMask.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
    }
}
