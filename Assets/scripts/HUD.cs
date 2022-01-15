using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] private Text scoreText;

    private const string Prefix = "Seconds that you're never getting back : ";
    private int _score;

    public bool StopGameTimer { get; set; }

    private float TimeSpent { get; set; }


    // Start is called before the first frame update
    void Start()    
    {
        scoreText.text = Prefix + _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StopGameTimer)
        {
            TimeSpent += Time.deltaTime;
            _score = (int) TimeSpent;
            scoreText.text = Prefix + _score.ToString();
        }
    }
}
