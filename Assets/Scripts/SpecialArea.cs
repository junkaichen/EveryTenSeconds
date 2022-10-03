using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialArea : MonoBehaviour
{
    Player myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
        StartCoroutine(DestroySelf());
        myPlayer.SpecialEffecting = false;
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myPlayer.currentHealth++;
            myPlayer.SpecialEffecting = true;
            Destroy(gameObject);
        }
    }


}
