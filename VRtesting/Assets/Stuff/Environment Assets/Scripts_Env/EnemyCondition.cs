using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCondition : MonoBehaviour
{

    private void OnDestroy()
    {
        EnemyWaves.currentEnemies--;
    }
}