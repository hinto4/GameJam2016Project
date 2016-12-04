using UnityEngine;
using System.Collections;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] SpawnObjectPrefab;
    

    private float _startTimer;

    void Start()
    {
        _startTimer = Time.time + Random.Range(1,5);
    }

    void Update()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        if (_startTimer - Time.time <= 0)
        {
            Quaternion randomRotation = new Quaternion(
                this.transform.rotation.x, 
                this.transform.rotation.y,
                Random.rotation.z, 
                this.transform.rotation.w);

            GameObject obstaclePrefab = Instantiate(SpawnObjectPrefab[Random.Range(0,SpawnObjectPrefab.Length)], 
                this.transform.position, randomRotation) as GameObject;

            if(obstaclePrefab != null) 
                obstaclePrefab.GetComponentInChildren<Rigidbody2D>().AddForce(
                new Vector2(Random.Range(-200f, 200f), -Random.Range(350f, 400f)));

            _startTimer = Time.time + Random.Range(1, 5);
        }
    }

    
}
