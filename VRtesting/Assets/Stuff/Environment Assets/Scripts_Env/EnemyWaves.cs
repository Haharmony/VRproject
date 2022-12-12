using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWaves : MonoBehaviour
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
        StartCoroutine(WaveGenerator());       
    }

    void Update()
    {
        viewCurrentEnemies = currentEnemies;
        Win();
    }

    public void Win()
    {
        if(currentWave == 2 && currentEnemies == 0)
        {
            Debug.Log("WIN");
            menuWin.SetActive(true);
            StartCoroutine("terminarLvl1");
        }
    }
    public IEnumerator terminarLvl1()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }



    IEnumerator WaveGenerator()
    {
        totalWaves = 2;
        currentWave = 1;
        while (totalWaves == 2) //Numero de rondas totales.
        {
            if (currentWave <= 1) 
            {
                while (enemyCount < 10) //Loop de enemigos y numero de enemigos a crear por ronda
                {
                    //Vector3(-7.21391153,12.3270626,-22.1017914)
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

            if (currentWave == 2)
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
                //totalWaves++;
                yield break;            
            }

            /*if (currentWave == 3)
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
            }*/
        }
    }
}
