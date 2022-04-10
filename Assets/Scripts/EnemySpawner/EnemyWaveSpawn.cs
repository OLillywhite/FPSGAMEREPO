using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class EnemyWaveSpawn : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    int waveCount = 0;

    public float spawnRate = 0.2f;
    public float timeBetweenWaves = 30f;

    public int enemyCount;

    public GameObject enemy;
    public GameObject spawnpoint;

    bool waveIsDone = true;

    void Update()
    {
        waveCountText.text = "Wave: " + waveCount.ToString();

        if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemyClone = Instantiate(enemy, spawnpoint.transform.position, spawnpoint.transform.rotation);

            yield return new WaitForSeconds(spawnRate);
        }

        spawnRate -= 0.1f;
        enemyCount += 2;
        waveCount += 1;
        timeBetweenWaves += 4f;
        enemy.GetComponent<EnemyDamage>().AddHP(5);


        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }
}