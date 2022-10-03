using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InGameUI : MonoBehaviour
{
    [SerializeField] Sprite StageOne;
    [SerializeField] Sprite StageTwo;
    [SerializeField] Sprite StageThree;
    [SerializeField] Sprite StageFour;
    [SerializeField] Sprite StageFive;
    [SerializeField] Sprite StageSix;


    [SerializeField] Image CurrentImage;
    [SerializeField] Image DamagedEffect;
    public Image LowHealth;
    private Player myPlayer;
    private void Start()
    {
        myPlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (myPlayer.currentStage)
        {
            case 1:
                CurrentImage.sprite = StageOne;
                break;
            case 2:
                CurrentImage.sprite = StageTwo;
                break;
            case 3:
                CurrentImage.sprite = StageThree;
                break;
            case 4:
                CurrentImage.sprite = StageFour;
                break;
            case 5:
                CurrentImage.sprite = StageFive; 
                break;
            case 6:
                CurrentImage.sprite = StageSix;
                break;
        }
    }

    public void Damaged()
    {
        StartCoroutine(Hurting());
    }


    IEnumerator Hurting()
    {
        DamagedEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        DamagedEffect.gameObject.SetActive(false);
    }

    public void LowHealthing()
    {
       
        StartCoroutine(LowHealthFirstStage());
        
    }

    IEnumerator LowHealthFirstStage()
    {
        float flashTiming = 0;
        if (myPlayer.currentHealth <= 6 && myPlayer.currentHealth > 2)
        {
            flashTiming = 5f;
        }
        else 
        {
            flashTiming = 1f;
        }
        StartCoroutine(LowHealthFirstStage2());
        yield return new WaitForSeconds(flashTiming);
        StartCoroutine(LowHealthFirstStage());
    }
    IEnumerator LowHealthFirstStage2()
    {

        LowHealth.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        LowHealth.gameObject.SetActive(false);

    }
}
