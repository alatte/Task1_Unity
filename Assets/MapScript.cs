using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject ground;
    public GameObject obstacle;
    public GameObject border;

    public void Start()
    {
        int height = PlayerPrefs.GetInt("height");
        int width = PlayerPrefs.GetInt("width");
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

    void CreateGameObject (GameObject newObject, Vector3 position)
    {
        Instantiate(newObject, position, Quaternion.identity).transform.parent = gameObject.transform;
    }
}
