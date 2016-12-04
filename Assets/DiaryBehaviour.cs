using UnityEngine;
using System.Collections;

public class DiaryBehaviour : MonoBehaviour
{
    public GameObject BigDiaryPrefab;

    private LevelManagerScript _levelManager;
    private float _startTimer;
    private bool _hasPickedUp;

    void Start()
    {
        _levelManager = FindObjectOfType<LevelManagerScript>();
    }

    void Update()
    {
        if (_hasPickedUp)
        {
            if (_startTimer - Time.time <= 0)
            {
                _levelManager.LoadNextLevel("Menu");
                DestroyObject(this.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(BigDiaryPrefab, Vector3.zero, Quaternion.identity);
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            _startTimer = Time.time + 3f;
            _hasPickedUp = true;
        }
    }
	
}
