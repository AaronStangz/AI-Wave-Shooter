using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float spawntimer;
    public float waveTimer;
    public float nextWaveTimer;
    public float SpawnArea = 5;
    public int maxWaves;
    public int waves;
    public bool InRaid;
    public List<GameObject> Spawnpoints;
    public List<GameObject> Spawning;

    public void Start()
    {
        StartWave();
    }
    public void Update()
    {
       
    }
    public void StartWave()
    {
        if (InRaid == true) 
        {
            print("Start waves");
            StartCoroutine(Spawntimer());
            StartCoroutine(WaveTimer());
        }

    }

    IEnumerator Spawntimer()
    {
        Debug.Log(spawntimer);
        yield return new WaitForSeconds(spawntimer);
        foreach (GameObject p in Spawnpoints)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(-SpawnArea, SpawnArea), 0, Random.Range(-SpawnArea, SpawnArea));
            Instantiate(Spawning[Random.Range(0, Spawning.Count)], p.transform.position + spawnPoint, p.transform.rotation);
        }
        StartWave();
    }

    IEnumerator WaveTimer()
    {
        Debug.Log(waveTimer);
        yield return new WaitForSeconds(waveTimer);
        EndWave();
    }

    public void EndWave()
    {
        print("end waves");
        InRaid = false;
        StartCoroutine(NextWaveTimer());
    }
    IEnumerator NextWaveTimer()
    {
        print("Next waves");
        Debug.Log(nextWaveTimer);
        yield return new WaitForSeconds(nextWaveTimer);
        InRaid = true;
        StartWave();
    }

}
