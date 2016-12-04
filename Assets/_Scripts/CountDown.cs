using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour
{
    public float Timer;

    private TextMesh _text;

    void Start()
    {
        _text = GetComponent<TextMesh>();
    }

    void Update()
    {
        float timeLeft = Timer - Time.time;
        _text.text = Mathf.Round(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            DestroyObject(this.gameObject);
        }
    }

}
