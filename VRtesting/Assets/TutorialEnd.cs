using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnd : MonoBehaviour
{
    public LogicMovmentEnemy2 LME2;
    public GameObject MenuCongrats;

    void Update()
    {
        EndTuto();
    }
    public void EndTuto()
    {
        if (LME2.EnemyLife <= 0)
        {
            MenuCongrats.SetActive(true);

            StartCoroutine("terminarTuto");
        }
    }

    public IEnumerator terminarTuto()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(6);
    }
}
