using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy FlyingEnemy;
    public Enemy GroundEnemy;
    public GameObject PlayerPrefab;
    [HideInInspector]
    public GameObject Player;
    public GameObject collectable;
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
        Player = SpawnPlayer();
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
                yield return new WaitForSeconds(1.0f);
                SpawnCollectable();
            }
            else
            {
                SpawnGroundEnemy();
            }
            yield return new WaitForSeconds(2.0f);
        }

    }

    public void SpawnCollectable()
    {
        if(Player != null)
        {
            Vector2 position = new Vector2(2.6f, Random.Range(-0.4f, 0.96f));
            Instantiate(collectable, position, Quaternion.identity);
        }
    }

    public void SpawnFlyingEnemy()
    {
        if(Player != null)
        {
            Vector2 position = new Vector2(2.6f, Player.transform.position.y);
            Instantiate(FlyingEnemy.gameObject, position, Quaternion.identity);
        }
    }

    public void SpawnGroundEnemy()
    {
        if(Player != null)
        {
            Vector2 position = new Vector2(2.6f, -0.635f);
            Instantiate(GroundEnemy.gameObject, position, Quaternion.identity);
        }
    }

    public GameObject SpawnPlayer()
    {
        Vector2 pos = new Vector2(-2f, 0.151f);
        return Instantiate(PlayerPrefab, pos, Quaternion.identity);
    }

}
