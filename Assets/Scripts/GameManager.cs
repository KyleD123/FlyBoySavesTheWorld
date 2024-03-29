using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera cam;
    public Enemy FlyingEnemy;
    public Enemy GroundEnemy;
    public GameObject VersusLogo;
    public GameObject PlayerPrefab;
    public GameObject BossPrefab;
    [HideInInspector]
    public GameObject Player;
    public GameObject collectable;
    private Coroutine spawnCo;
    private int MaxEnemyCount = 6;

    [HideInInspector]
    public bool BossBattle = false;

    [HideInInspector]
    public bool BossSpawned = false;

    [HideInInspector]
    public bool Winner = false;

    private float TimeSpent = 0;

    public int TimeLimitPerSection = 30;

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
        //SpawnBoss();
    }


    // Update is called once per frame
    void Update()
    {
        if(Player == null)
        {
            SceneManager.LoadScene("EndScreen");
        }

        if(TimeSpent < TimeLimitPerSection)
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
                    Winner = true;
                    Debug.Log("You Win!");
                    SceneManager.LoadScene("WinnerScreen");
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
        yield return new WaitForSeconds(5);
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
            yield return new WaitForSeconds(1.5f);
        }

    }

    public void SpawnCollectable(Vector2 pos)
    {
        if(Player != null)
        {
            //Vector2 position = new Vector2(2.6f, Random.Range(-0.4f, 0.96f));
            Instantiate(collectable, pos, Quaternion.identity);
        }
    }

    public void SpawnFlyingEnemy()
    {
        if(Player != null)
        {
            Vector2 position = new Vector2(2.3f, Random.Range(-0.4f, 0.92f));
            //Vector2 position = new Vector2(2.6f, Player.transform.position.y);
            GameObject bird = Instantiate(FlyingEnemy.gameObject, position, Quaternion.identity);
            float rnd = Random.Range(1.0f, 1.75f);
            bird.transform.localScale = new Vector3(rnd, rnd, rnd);
            SpawnCollectable(position + new Vector2(0.1f, 0));
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
        Vector2 pos = new Vector2(-1.7f, 0.151f);
        return Instantiate(PlayerPrefab, pos, Quaternion.identity);
    }

    public void SpawnBoss()
    {
        BossSpawned = true;
        Vector2 pos = new Vector2(2.6f, 0.17f);
        Instantiate(BossPrefab, pos, Quaternion.identity);
        VersusLogo.SetActive(true);
        cam.gameObject.GetComponent<DramaticTilt>().Tilt();
    }

}
