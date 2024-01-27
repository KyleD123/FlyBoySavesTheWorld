using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy FlyingEnemy;
    public Enemy GroundEnemy;
    private GameObject Player;
    private Coroutine spawnCo;
    private int MaxEnemyCount = 5;
    private int EnemyCount { 
        get
        {
            return FindObjectsOfType<Enemy>().Length;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        spawnCo = StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Spawner()
    {
        while (EnemyCount < MaxEnemyCount)
        {
            if (Random.Range(0, 100) > 50)
            {
                SpawnFlyingEnemy();
            }
            else
            {
                SpawnGroundEnemy();
            }
            yield return new WaitForSeconds(2.0f);
        }

    }

    public void SpawnFlyingEnemy()
    {
        if(Player != null)
        {
            //Vector2 position = new Vector2(2.6f, Random.Range(-0.4f, 0.93f));
/*            if (Player.transform.position.y <= -0.74) { 
            }*/
            Vector2 position = new Vector2(2.6f, Player.transform.position.y);
            Instantiate(FlyingEnemy.gameObject, position, Quaternion.identity);
        }
    }

    public void SpawnGroundEnemy()
    {
        if(Player != null)
        {
            Vector2 position = new Vector2(2.6f, -0.74f);
            Instantiate(GroundEnemy.gameObject, position, Quaternion.identity);
        }
    }

}
