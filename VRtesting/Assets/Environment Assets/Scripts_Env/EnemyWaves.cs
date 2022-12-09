using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public GameObject[] Enemies;
    static  public GameObject[] Enemy;
    public int xPos;
    public int zPos;
    static public int enemyCount;
    static public int totalWaves;
    static public int currentWave;
    void Start()
    {
        StartCoroutine(WaveGenerator());
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    IEnumerator WaveGenerator()
    {
        currentWave = 1;
        while (totalWaves < 3) //Numero de rondas totales.
        {
            if (currentWave <= 1) 
            {
                while (enemyCount < 10) //Loop de enemigos y numero de enemigos a crear por ronda
                {
                    xPos = Random.Range(6, 12);
                    zPos = Random.Range(-4, 4);
                    int rand = Random.Range(0, 1); //Enemigos que generar�.
                    Instantiate(Enemies[rand], new Vector3(xPos, -6, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.3f); //Tiempo entre enemigo creado
                    enemyCount++;
                }
                enemyCount = 0;
                totalWaves++;
                currentWave++;
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
                }
                enemyCount = 0;
                totalWaves++;
                currentWave++;
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
                }
                enemyCount = 0;
                totalWaves++;
                currentWave++;
                yield return new WaitForSeconds(3); //Tiempo entre rondas
            }
        }
    }
}
