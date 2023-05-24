using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;

    private void Start()
    {
        GenerateCoin();
    }

    public void GenerateCoin()
    {
        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(0f, 0f));
        coin.SetActive(true);
    }
}
