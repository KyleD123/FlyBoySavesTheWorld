using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Enemy FlyingEnemy;
    public Enemy GroundEnemy;
    public GameObject PlayerPrefab;
    public GameObject BossPrefab;
    [HideInInspector]
    public GameObject Player;
    public GameObject collectable;
    private Coroutine spawnCo;
    private int MaxEnemyCount = 5;

    [HideInInspector]
    public bool BossBattle = false;

    [HideInInspector]
    public bool BossSpawned = false;

    private float TimeSpent = 0;

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
        if(Player == null)
        {
            SceneManager.LoadScene("EndScreen");
        }

        if(TimeSpent < 30)
        {
            TimeSpent += Time.deltaTime;
        }
        else
        {
            if (BossBattle)
            {
                if(FindObjectOfType<Boss>() != null)
                {
                    GameObject boss = FindObjectOfType<Boss>().gameObject;
                    GameObject hand = FindObjectOfType<Hand>().gameObject;
                    Destroy(boss);
                    Destroy(hand);
                    BossBattle = false;
                }
            }

            if (spawnCo != null)
            {
                StopCoroutine(spawnCo);
                BossBattle = true;
                if(!BossSpawned)
                {
                    SpawnBoss();
                    TimeSpent = 0;
                }
            }
        }
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
            //Vector2 position = new Vector2(2.6f, Random.Range(-0.4f, 0.96f));
            Vector2 position = new Vector2(2.6f, -0.635f);
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

    public void SpawnBoss()
    {
        BossSpawned = true;
        Vector2 pos = new Vector2(2.6f, -0.655f);
        Instantiate(BossPrefab, pos, Quaternion.identity);
    }

}
