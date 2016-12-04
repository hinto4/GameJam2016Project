using UnityEngine;
using System.Collections;

public class PuppetMaster : MonoBehaviour
{
    public GameObject PuppeteerControlIcon;

    private float _startTimer;
    private float _puppetControlTimer;
    private bool _isPuppetControlActive;

    private PlayerController _playerController;

    void Start()
    {
        _puppetControlTimer = Time.time + 2f;
        _startTimer = Time.time + 6f;
        _playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        ActivatePuppetMasterControl();
    }

    void ActivatePuppetMasterControl()
    {
        if (_startTimer - Time.time <= 0 && !_isPuppetControlActive)
        {
            _playerController.SwitchInput = true;
            _isPuppetControlActive = true;
            _puppetControlTimer = Time.time + Random.Range(4, 10);
        }
        if (_isPuppetControlActive)
        {
            PuppeteerControlIcon.SetActive(true);
            if (_puppetControlTimer - Time.time <= 0)
            {
                _playerController.SwitchInput = false;
                _startTimer = Time.time + Random.Range(6, 20);
                _isPuppetControlActive = false;
                PuppeteerControlIcon.SetActive(false);
            }
        }
    }
}
