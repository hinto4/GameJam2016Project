using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{
    public GameObject MoonPrefab;
    public GameObject DiaryPrefab;
    public GameObject KardinsPrefabs;
    public GameObject[] SpawningManager;

    private readonly List<GameObject> _moonPieces = new List<GameObject>();
    private Animator _animator;
    private float _startTime;
    private bool _isSpawnActive;
    private bool _hasDiarySpawned;

    void Start()
    {
        _startTime = Time.time + 3;
        _animator = KardinsPrefabs.GetComponent<Animator>();
        _animator.SetBool("openKardins", true);

        foreach (var piece in MoonPrefab.GetComponentsInChildren<Rigidbody2D>())
        {
            _moonPieces.Add(piece.gameObject);
        }
    }

    void Update()
    {
        if (_startTime - Time.time <= 0 && !_isSpawnActive)
        {
            foreach (var spawn in SpawningManager)
            {
                spawn.SetActive(true);
                _isSpawnActive = true;
            }
        }
    }

    public void RemoveMoonPiece(GameObject obj)
    {
        _moonPieces.Remove(obj);
        if (_moonPieces.Count <= 0 && !_hasDiarySpawned)
        {
            Instantiate(DiaryPrefab, GetComponentInParent<Transform>().gameObject.transform.position, Quaternion.identity);
            _hasDiarySpawned = true;
        }
    }
}
