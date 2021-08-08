using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPowerupPrefab;

    private bool _stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //spawn game objects every  secs
    //create a coroutine of type IEnumerator -- Yield Events
    //while loop


    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(4.0f);

        }

    }

    IEnumerator SpawnPowerupRoutine()
    {
        //every 3-7 seconds, spawn in a powerup
        while (_stopSpawning == false)
        {
            Vector3 postToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_tripleShotPowerupPrefab, postToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(6, 10));

        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
