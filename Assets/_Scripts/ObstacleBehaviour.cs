using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour
{
    public bool _destroyObject;
    public GameObject TolmEffect;

    private float _startTimer;
    private GameManagerScript _gameManagerScript;
    private ItemManager _itemManager;

    void Start()
    {
        _startTimer = Time.time + 10f;
        _gameManagerScript = FindObjectOfType<GameManagerScript>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //GameObject tolm = Instantiate(TolmEffect, this.transform.position, Quaternion.identity) as GameObject;
        //DestroyObject(tolm,1f);

        if (col.gameObject.tag == "Moon")
        {
            _gameManagerScript.RemoveMoonPiece(col.gameObject);
        }

        if (!_destroyObject && col.gameObject.tag != "Player")
        {
            DestroyObjectChangeRate(30);
        }
    }

    void DestroyObjectChangeRate(int minPercentRate)
    {
        float changeRate = Random.Range(1, 100);

        if (changeRate >= minPercentRate)
        {
            DestroyObject(this.transform.gameObject,0.5f);
        }
        else
        {
            _destroyObject = true;
            DestroyObject(this.gameObject, 15f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
