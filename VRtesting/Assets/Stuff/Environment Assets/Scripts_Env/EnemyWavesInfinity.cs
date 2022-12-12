using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWavesInfinity : MonoBehaviour
{
    public GameObject[] Enemies;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int totalWaves;
    public int currentWave;
    static public int currentEnemies;
    public int viewCurrentEnemies;
    public GameObject menuWin;

    void Start()
    {
        StartCoroutine(WaveGenerator3());
    }

    void Update()
    {
        viewCurrentEnemies = currentEnemies;
        Win3();
    }

    public void Win3()
    {
        if (currentWave == 90000 && currentEnemies == 0)
        {
            Debug.Log("WIN");
            menuWin.SetActive(true);
            StartCoroutine("terminarLvl3");

        }
    }
    public IEnumerator terminarLvl3()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }



    IEnumerator WaveGenerator3()
    {
        totalWaves = 90000;
        currentWave = 1;
        while (totalWaves == 90000) //Numero de rondas totales.
        {
            if (currentWave <= 5)
            {
                while (enemyCount < 10) //Loop de enemigos y numero de enemigos a crear por ronda
                {
                    xPos = Random.Range(-7, -10);
                    zPos = Random.Range(-22, -25);
                    int rand = Random.Range(0, 1); //Enemigos que generará.
                    Instantiate(Enemies[rand], new Vector3(xPos, 20, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.3f); //Tiempo entre enemigo creado
                    enemyCount++;
                    currentEnemies++;
                }
                enemyCount = 0;
                currentWave++;
                //totalWaves++;
                yield return new WaitForSeconds(20); //Tiempo entre rondas
            }

            if (currentWave > 5 && currentWave <= 7) //
            {
                while (enemyCount < 5) //Loop de enemigos y numero de enemigos a crear por ronda
                {
                    xPos = Random.Range(-7, -10);
                    zPos = Random.Range(-22, -25);
                    int rand = Random.Range(1, 2);
                    Instantiate(Enemies[rand], new Vector3(xPos, 20, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.3f); //Tiempo entre enemigo creado 
                    enemyCount++;
                    currentEnemies++;
                }
                enemyCount = 0;
                currentWave++;
                //totalWaves++;
                yield return new WaitForSeconds(20); //Tiempo entre rondas               
            }

            if (currentWave > 7 && currentWave <= 90000)
            {
                while (enemyCount < 3) //Loop de enemigos y numero de enemigos a crear por ronda
                {
                    xPos = Random.Range(-7, -10);
                    zPos = Random.Range(-22, -25);
                    int rand = Random.Range(2, 3);
                    Instantiate(Enemies[rand], new Vector3(xPos, 20, zPos), Quaternion.identity);
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
