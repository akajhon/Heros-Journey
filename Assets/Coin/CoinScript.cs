using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameManager.instance.IncreaseScore(coinValue);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
