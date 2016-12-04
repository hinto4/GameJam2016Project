using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float Health = 100;
    public GameObject StunCountDownNotation;
    public GameObject StunIcon;
    public Slider HealthBar;


    public bool SwitchInput;
    public bool IsControllable;

    private float _timer;
    private float _stunTimer = 3.0f;
    private LevelManagerScript _levelManagerScript;
    private Animator _animator;
    

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _levelManagerScript = FindObjectOfType<LevelManagerScript>();
        _timer = Time.time + _stunTimer;
        IsControllable = true;
        HealthBar.value = Health;
    }

    void FixedUpdate()
    {
        InputManager();

        if (!IsControllable)
        {
            OnPlayerDamage();
        }
    }

    void InputManager()
    {
        float buttonHorizontal = Input.GetAxis("Horizontal");
        if (IsControllable == true)
        {
            if (buttonHorizontal < 0)   // Moving left
            {
                if (SwitchInput == true)
                {
                    this.transform.position -= Vector3.left*Speed*Time.deltaTime;
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    this.transform.position += Vector3.left*Speed*Time.deltaTime;
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                _animator.SetBool("isWalking", true);
                
            }
            else if (buttonHorizontal > 0) // Moving right
            {
                if (SwitchInput == true)
                {
                    this.transform.position -= -Vector3.left*Speed*Time.deltaTime;
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    this.transform.position += -Vector3.left*Speed*Time.deltaTime;
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                _animator.SetBool("isWalking", true);
                
            }
            if (buttonHorizontal == 0)
            {
                _animator.SetBool("isWalking", false);
            }
            
            StunIcon.SetActive(false);
        }
        else
        {
            StunIcon.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Moon")
        {
            _animator.SetBool("isWalking", false);
            if (!col.gameObject.GetComponent<ObstacleBehaviour>()._destroyObject && col.gameObject.tag == "Obstacle")
            {
                DisableControlsDeductHealth();
            }
            else if(!col.gameObject.GetComponent<ObstacleBehaviour>()._destroyObject)
            {
                DisableControlsDeductHealth();
            }
        }
    }

    private void DisableControlsDeductHealth()
    {
        IsControllable = false;
        Health -= 10;
        HealthBar.value = Health;
    }

    void OnPlayerDamage()
    {
        if (Health <= 0)
        {
            Debug.Log("Health 0");
            _levelManagerScript.LoadNextLevel("Menu");
        }

        if (_timer - Time.time <= 0)
        {
            IsControllable = true;
            _timer = Time.time + _stunTimer;
        }
    }
}
    