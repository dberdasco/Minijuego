using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{

    public GameObject jirenPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xlimit;
    public float maxTimeLife = 4f;

    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {

        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xlimit, xlimit);

            Vector2 spawnPosition = new Vector2(rand, 12);

            GameObject jiren = Instantiate(jirenPrefab, spawnPosition, Quaternion.identity);
            Destroy(jiren, maxTimeLife);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("No has golpeado un Jiren");
        }
    }


}
