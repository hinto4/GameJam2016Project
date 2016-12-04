using UnityEngine;
using System.Collections;

public class SpotlightBehaviour : ObstacleBehaviour
{
    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!_destroyObject)
        {
            DestroyObjectChangeRate(20, col.gameObject);
        }
    }

    public void  DestroyObjectChangeRate(int minPercentRate, GameObject obj)
    {
        float changeRate = Random.Range(1, 100);

        if (changeRate >= minPercentRate)
        {
            DestroyObject(this.transform.gameObject);
            if (obj.gameObject.GetComponent<SpotlightBehaviour>())
            {

                foreach (var item in obj.GetComponentsInChildren<Transform>())
                {
                    item.gameObject.AddComponent<PolygonCollider2D>();
                    item.gameObject.AddComponent<Rigidbody2D>();
                }
            }
            
        }
        else
        {
            _destroyObject = true;
        }
    }*/
}
