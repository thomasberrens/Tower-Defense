using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

   [SerializeField] private Transform enemyPrefab;
   [SerializeField] private Transform SpawnPoint;
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private AudioClip AudioClip;
   [SerializeField] private float timeBetweenWaves = 5f;
   [SerializeField] private float countdown = 3f;
   [SerializeField] private int WaveNumber = 1;
   
   void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        WaveNumber++;
        countdown += 5f;
    }

    void SpawnEnemy()
    {
        audioSource.PlayOneShot(AudioClip);
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }


}
