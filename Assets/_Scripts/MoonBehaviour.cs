using UnityEngine;
using System.Collections;

public class MoonBehaviour : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            _animator.SetTrigger("moonHit");
            this.GetComponent<Rigidbody2D>().isKinematic = false;
            DestroyObject(col.gameObject, 0.4f);
            DestroyObject(this.transform.gameObject, 1.5f);
        }
    }
}
