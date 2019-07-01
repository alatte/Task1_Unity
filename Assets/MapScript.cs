using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject ground;
    public GameObject obstacle;
    public GameObject border;

    public GameObject player;
    public GameObject enemy;

    public int height;
    public int width;

    public int numberOfEnemies;

    void Start()
    {
        GenerateMap();
        if (height > 5 && width > 5)
        {
            CreatePlayer();
            CreateEnemies();
        }
    }

    void GenerateMap()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                CreateGameObject(ground, new Vector3(j, 0, i));
                if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
                    CreateGameObject(border, new Vector3(j, 1, i));
                else if (j % 2 == 0 && i % 2 == 0 && i < height - 2 && j < width - 2)
                    CreateGameObject(obstacle, new Vector3(j, 1, i));
            }
        }            
    }

    void CreatePlayer()
    {
        Instantiate(player, GetPlayerSpawnPoint(), Quaternion.identity);
    }

    void CreateEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i ++)
        {
            Instantiate(enemy, GetEnemySpawnPoint(), Quaternion.identity);
        }
    }

    Vector3 GetPlayerSpawnPoint()
    {
        int xPosition, zPosition;
        if (height % 2 == 0) zPosition = height / 2 - 1;
        else zPosition = (height - 1) / 2;

        xPosition = (width - 1) / 2;

        return new Vector3(xPosition, transform.position.y + 1, zPosition);
        
    }

    Vector3 GetEnemySpawnPoint()
    {
        int xPosition, zPosition;

        xPosition = (int) Random.Range(transform.position.x + 1, width - 1);
        if (xPosition % 2 == 0) xPosition += 1;

        zPosition = (int) Random.Range(transform.position.z + 1, height - 1);

        return new Vector3(xPosition, transform.position.y + 1, zPosition);
    }

    void CreateGameObject (GameObject newObject, Vector3 position)
    {
        Instantiate(newObject, position, Quaternion.identity).transform.parent = gameObject.transform;
    }
}
