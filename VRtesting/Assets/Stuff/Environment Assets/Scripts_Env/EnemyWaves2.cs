using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves2 : MonoBehaviour
{
    public GameObject[] Enemies;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int totalWaves;
    public int currentWave;
    static public int currentEnemies;
    public int viewCurrentEnemies;
    void Start()
    {
        StartCoroutine(WaveGenerator2());
    }

    void Update()
    {
        viewCurrentEnemies = currentEnemies;
        Win2();
    }

    public void Win2()
    {
        if (currentWave == 3 && currentEnemies == 0)
        {
            Debug.Log("WIN");
        }
    }



    IEnumerator WaveGenerator2()
    {
        totalWaves = 3;
        currentWave = 1;
        while (totalWaves == 3) //Numero de rondas totales.
        {
            if (currentWave <= 1)
            {
                while (enemyCount < 10) //Loop de enemigos y numero de enemigos a crear por ronda
                {
                    xPos = Random.Range(6, 12);
                    zPos = Random.Range(-4, 4);
                    int rand = Random.Range(0, 1); //Enemigos que generará.
                    Instantiate(Enemies[rand], new Vector3(xPos, -6, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.3f); //Tiempo entre enemigo creado
                    enemyCount++;
                    currentEnemies++;
                }
                enemyCount = 0;
                currentWave++;
                //totalWaves++;
                yield return new WaitForSeconds(3); //Tiempo entre rondas
            }

            if (currentWave > 1 && currentWave <= 2)
            {
                while (enemyCount < 5) //Loop de enemigos y numero de enemigos a crear por ronda
                {
                    xPos = Random.Range(6, 12);
                    zPos = Random.Range(-4, 4);
                    int rand = Random.Range(1, 2);
                    Instantiate(Enemies[rand], new Vector3(xPos, -6, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.3f); //Tiempo entre enemigo creado
                    enemyCount++;
                    currentEnemies++;
                }
                enemyCount = 0;
                currentWave++;
                //totalWaves++;
                yield return new WaitForSeconds(3); //Tiempo entre rondas               
            }

            if (currentWave == 3)
            {
                while (enemyCount < 1) //Loop de enemigos y numero de enemigos a crear por ronda
                {
                    xPos = Random.Range(6, 12);
                    zPos = Random.Range(-4, 4);
                    int rand = Random.Range(2, 3);
                    Instantiate(Enemies[rand], new Vector3(xPos, -6, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.3f); //Tiempo entre enemigo creado
                    enemyCount++;
                    currentEnemies++;
                }
                Debug.Log(currentWave);
                yield break;
            }
        }
    }
}
