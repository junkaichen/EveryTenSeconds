using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGameUI : MonoBehaviour
{
    private Timer timer;
    [SerializeField] TextMeshProUGUI TimerText;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            TimerText.text = timer.getSuvivalTime().ToString() + " Seconds";
        }
            
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
