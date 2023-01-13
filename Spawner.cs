using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Wave[] waves;
    public Enemy enemy;
    Wave currentWave;
    int currentWaveNumber;

    int remainingEnemiesToSpawn;
    int remainingEnemiesAlive;
    float nextSpawnTime;

    void Start() {
        NextWave();
    }
    void Update(){
        if(remainingEnemiesToSpawn > 0 && Time.time >nextSpawnTime) {
            remainingEnemiesToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath(){
        // print("Sethutaan");
        remainingEnemiesAlive --;

        if(remainingEnemiesAlive == 0){
            NextWave();
        }
    }
    void NextWave(){
        currentWaveNumber ++;
        print("Wave: " + currentWaveNumber);
        if(currentWaveNumber - 1 < waves.Length){
            currentWave = waves[currentWaveNumber - 1];

            remainingEnemiesToSpawn = currentWave.enemyCount;
            remainingEnemiesAlive = remainingEnemiesToSpawn;
        }
    }

    [System.Serializable]
    public class Wave {
        public int enemyCount;
        public float timeBetweenSpawns;
         
    }
}
