using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy FlyingEnemy;
    public Enemy GroundEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int countOfEnemies = FindObjectsOfType<Enemy>().Length;
        if(countOfEnemies < 3)
        {
            SpawnEnemy();
        }

    }


    public void SpawnEnemy()
    {
        Vector2 position = new Vector2(11.5f, Random.Range(-5.0f, 5.0f));
        Instantiate(FlyingEnemy.gameObject, position, Quaternion.identity);
    }

}
