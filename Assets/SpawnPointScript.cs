using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject shooterPrefab;

    private int height;
    private int width;
    private int numberOfEnemies;
    private BonusSpawnerScript bonusSpawnerScript;

    private GameObject player;
    
    public void Start()
    {
        bonusSpawnerScript = GetComponent<BonusSpawnerScript>();
        numberOfEnemies = PlayerPrefs.GetInt("numberOfEnemies");
        height = PlayerPrefs.GetInt("height");
        width = PlayerPrefs.GetInt("width");

        if (height > 5 && width > 5)
        {
            CreatePlayer();
            CreateEnemies();
        }
    }

    void CreatePlayer()
    {
        player = Instantiate(playerPrefab, GetPlayerSpawnPoint(), Quaternion.identity);
        bonusSpawnerScript.SetTarget(player);
    }

    void CreateEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GetEnemySpawnPoint(), Quaternion.identity).GetComponent<EnemyScript>().SetTarget(player);
        }        
    }

    Vector3 GetPlayerSpawnPoint()
    {
        int xPosition, zPosition;
        if (height % 2 == 0) zPosition = height / 2 - 1;
        else zPosition = (height + 1) / 2;

        xPosition = (width - 1) / 2;

        return new Vector3(xPosition, transform.position.y + 1, zPosition);
    }

    Vector3 GetEnemySpawnPoint()
    {
        int xPosition, zPosition;

        xPosition = (int)Random.Range(transform.position.x + 1, width - 1);
        if (xPosition % 2 == 0) xPosition += 1;

        zPosition = (int)Random.Range(transform.position.z + 1, height - 1);

        return new Vector3(xPosition, transform.position.y + 1, zPosition);
    }
}
