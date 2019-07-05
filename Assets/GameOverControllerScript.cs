using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverControllerScript : MonoBehaviour
{
    private GameObject[] coins;

    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        if (coins.Length == 0)
        {
            //Пускай так будет, ладно?
            print("YOU WIN");
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                Destroy(enemy);
        }
    }
}
