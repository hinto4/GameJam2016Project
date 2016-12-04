using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{
    public GameObject PlayerHandPosition;

    private GameObject _itemInHand;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_itemInHand != null)
            {
                ThrowTheItem(_itemInHand);
                _itemInHand = null;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            if (col.gameObject.GetComponent<ObstacleBehaviour>()._destroyObject)
            {
                if (PlayerHandPosition.transform.childCount <= 0)
                    PickupTheItem(col.gameObject);
                else
                    Debug.Log("Player already has item.");
            }
        }
    }

    void PickupTheItem(GameObject obj)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.GetComponent<Rigidbody2D>().isKinematic = true;
        obj.transform.SetParent(PlayerHandPosition.transform);
        obj.transform.position = PlayerHandPosition.transform.position;
        obj.GetComponent<Collider2D>().isTrigger = true;

        _itemInHand = obj;
    }

    void ThrowTheItem(GameObject obj)
    {
        obj.transform.parent = null;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        rb.isKinematic = false;
        obj.GetComponent<Collider2D>().isTrigger = false;
        rb.AddForce(Vector2.up * 1000f);
    }
}
