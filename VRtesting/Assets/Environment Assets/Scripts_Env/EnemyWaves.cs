using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public GameObject[] Enemies;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int waveCount;
    void Start()
    {
        StartCoroutine(WaveGenerator());
    }

    IEnumerator WaveGenerator()
    {
        while(waveCount < 3) //Loop de rondas
        {
            while(enemyCount < 8) //Loop de enemigos
            {
                xPos = Random.Range(6, 12);
                zPos = Random.Range(-4, 4);
                int rand = Random.Range(0, 3);
                Instantiate(Enemies[rand], new Vector3(xPos, -6, zPos), Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
                enemyCount++;
            }
            enemyCount = 0;
            waveCount++;
            yield return new WaitForSeconds(5);
        }
    }
}
