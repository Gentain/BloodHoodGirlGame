using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspsGenerator : MonoBehaviour
{
    public GameObject spawnEnemy;
    public GameObject generator;
    public float interval = 3.0f;
    public GameObject target;
    [SerializeField] private Transform targetTrans;
    [SerializeField] private Transform enemyTrans;
    public float speed = 1.5f;
    public float distanceGeneratorToPlayer_x;
    public float distanceGeneratorToPlayer_y;
    public float searchDistance_x = 5;
    public float searchDistance_y = 5;

    Vector3 enemyVector;

    // Start is called before the first frame update
    void Start()
    {
        enemyTrans = GetComponent<Transform>();
        try
        {
            target = GameObject.FindWithTag("Player");
            targetTrans = target.GetComponent<Transform>();
            distanceGeneratorToPlayer_x = Mathf.Abs(targetTrans.position.x - enemyTrans.position.x);
            distanceGeneratorToPlayer_y = Mathf.Abs(targetTrans.position.y - enemyTrans.position.y);
        }
        catch (NullReferenceException ex)
        {

        }
        InvokeRepeating("SpawnEnemy", 3.0f, interval);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        if (PauseSystem.paused == false)
        {
            try
            {
                target = GameObject.FindWithTag("Player");
                targetTrans = target.GetComponent<Transform>();
                distanceGeneratorToPlayer_x = Mathf.Abs(targetTrans.position.x - enemyTrans.position.x);
                distanceGeneratorToPlayer_y = Mathf.Abs(targetTrans.position.y - enemyTrans.position.y);
                if (distanceGeneratorToPlayer_x <= searchDistance_x && distanceGeneratorToPlayer_y <= searchDistance_y)
                {
                    GameObject newEnemy = Instantiate(spawnEnemy, generator.transform.position, Quaternion.identity) as GameObject;
                }
                else
                {
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }
    }
}
