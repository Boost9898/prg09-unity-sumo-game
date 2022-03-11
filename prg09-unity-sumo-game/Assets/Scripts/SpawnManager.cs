using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 11.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public int puntjes = 0;
    public Text puntjesText;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(1);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int amountOfEnemies)
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            // create a new enemyPrefab, use GenerateSpawnPosition
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            puntjes++;
            puntjesText.text = "PUNTJES: " + puntjes;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange + 1);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange + 1);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
