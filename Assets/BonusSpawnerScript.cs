using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnerScript : MonoBehaviour
{
    public GameObject[] bonusArray;
    public int bonusDelay;

    private int height;
    private int width;
    private float nextBonus;
    private GameObject target;

    void Start()
    {
        height = PlayerPrefs.GetInt("height");
        width = PlayerPrefs.GetInt("width");       
    }

    void Update()
    {
        if (height > 5 && width > 5)
        {
            CreateBonus();
        }
    }

    void CreateBonus()
    {
        if (Time.time > nextBonus)
        {
            nextBonus = Time.time + bonusDelay;
            Instantiate(bonusArray[Random.Range(0, bonusArray.Length)], GetBonusSpawnPoint(), Quaternion.identity).GetComponent<BonusScript>().SetTarget(target);
        }
    }

    Vector3 GetBonusSpawnPoint()
    {
        int xPosition, zPosition;

        xPosition = (int)Random.Range(1, width - 1);
        if (xPosition % 2 == 0) xPosition += 1;

        zPosition = (int)Random.Range(1, height - 1);

        return new Vector3(xPosition, 1, zPosition);
    }

    public void SetTarget (GameObject target)
    {
        this.target = target;
    }
}
