using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Player player;
    public GameObject coinPrefab;

    Dictionary<Vector3, bool> coinPositionsFound;
    

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnPlayerDeath += RespawnCoins;
        player.OnAcquireCoin += CoinFound;
        player.OnCheckpointEntered += CheckpointEntered;

        coinPositionsFound = new Dictionary<Vector3, bool>();

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Coin"))
        {
            coinPositionsFound.Add(obj.transform.position, false);
        }
    }

    public void CheckpointEntered()
    {
        // Reform dictionary with only the coins left in the level
        coinPositionsFound.Clear();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Coin"))
        {
            coinPositionsFound.Add(obj.transform.position, false);
        }
    }

    public void CoinFound(GameObject coinObj)
    {
        // Find the coin position in the dictionary, and mark it as found
        Vector3 foundCoinPos = coinObj.transform.position;
        coinPositionsFound[foundCoinPos] = true;
    }

    public void RespawnCoins()
    {
        // Respawn only the coins that the player collected

        /*Dictionary<Vector3, bool>.KeyCollection keys = coinPositionsFound.Keys;
        foreach(Vector3 pos in keys)
        {
            if(coinPositionsFound[pos] == true)
            {
                Instantiate(coinPrefab, pos, Quaternion.Euler(Vector3.up));
            }
            coinPositionsFound[pos] = false;
        }*/


        /*for(int i = 0; i < coinPositionsFound.Count; i++)
        {
            if(coinPositionsFound.Keys )
        }*/

        // TODO: Improve this implementation

        // Check all entries in dictionary, recreate all coins that the player found
        foreach (KeyValuePair<Vector3, bool> pair in coinPositionsFound)
        {
            if (pair.Value == true)
            {
                Instantiate(coinPrefab, pair.Key, Quaternion.Euler(Vector3.up));
            }
        }

        // Clear dictionary then add back all entries, with the values set to false
        coinPositionsFound.Clear();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Coin"))
        {
            coinPositionsFound.Add(obj.transform.position, false);
        }



    }

}
