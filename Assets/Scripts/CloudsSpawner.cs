using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    public GameObject [] cloudPrefab;

    public float cloud_Spawn_Timer = 5f;
    private float current_Cloud_Spawn_Timer;

    public float min_X = -2 , max_X = 2; 


    // Start is called before the first frame update
    void Start()
    {
        current_Cloud_Spawn_Timer = cloud_Spawn_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCloud();
    }

    void SpawnCloud()
    {
        current_Cloud_Spawn_Timer += Time.deltaTime;

        if(current_Cloud_Spawn_Timer >= cloud_Spawn_Timer)
        {
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newCloud = null;

            newCloud = Instantiate(cloudPrefab[Random.Range(0, cloudPrefab.Length)], temp, Quaternion.identity);

            current_Cloud_Spawn_Timer = 0f;
        }
    }
}
