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
    private Player myPlayer;
    private void Start()
    {
        myPlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(myPlayer.currentStage);
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
        yield return new WaitForSeconds(0.5f);
        DamagedEffect.gameObject.SetActive(false);
    }
}
