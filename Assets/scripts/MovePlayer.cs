using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Vector3 _playerPosition;
    private Vector3 _playerRotation;
    private float _shipThrust = 6f;
    private float _rotationMultiplier = 150f;
    private float _shipRadius;
    private bool _slowMow;

    [SerializeField] private GameObject asteroid;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private HUD hud;

    private Shooter _shooter;

    private Timer _timer;

    private Timer _timer2;
    private Timer _timer3;
//    private TouchFollow _touchFollowScript;
    // Start is called before the first frame update
    void Start()
    {
        //RigidBody2D instantiation  
        _rb = gameObject.GetComponent<Rigidbody2D>();
        
        //CircleCollider2D instantiation
        var circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        
        //collider radius
        _shipRadius = circleCollider2D.radius;

    //    _touchFollowScript = GetComponent<TouchFollow>();
        
        //reference to the shooter class
        _shooter = GetComponent<Shooter>();
  //      hud = gameObject.GetComponent<HUD>();
        
        _timer = gameObject.AddComponent<Timer>();
        _timer.Duration = 0.5f;
        _timer.Run();
        _timer2 = gameObject.AddComponent<Timer>();
        _timer3 = gameObject.AddComponent<Timer>();
    }
    
    private void FixedUpdate()
    {
                //Apply thrust to the ship
                
                var zValue =(float) (transform.eulerAngles.z * Math.PI) / 180;
                var angle = new Vector2(Mathf.Cos(zValue), Mathf.Sin(zValue));
                var verticalScale = Input.GetAxis("Vertical"); 
                if (verticalScale > 0)// || _touchFollowScript.UpArrowTriggered)
                {
                    _rb.AddForce(angle * _shipThrust , ForceMode2D.Force);
                }
                
                var fireInput = Input.GetAxis("Fire1");
                
                if (fireInput != 0f && _timer.Finished)
                {
                    _timer.Duration = 1f;
                    _timer.Run();
                    _shooter.InstantiateBullet(angle , transform.position , transform.eulerAngles);
                }
    }

    // Update is called once per frame
    void Update()
    {
        
        //for slow motion effect
        /*
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !_slowMow)
        {
            Time.timeScale = 0.4f;
            _slowMow = true;
            _timer2.Duration = 1f;
            _timer2.Run();
        }
        if (_timer2.Finished && _slowMow)    
        {
            print("finished");
            Time.timeScale = 1f;
            _timer3.Duration = 3f;
            _timer3.Run();
        }

        if (_timer3.Finished && _slowMow)
        {
            print("timer 3");
            _slowMow = false; 
        }
        */
        
    
        
        var horizontalScale = Input.GetAxis("Horizontal");
        float rotationSpeed = _rotationMultiplier * Time.deltaTime; 
        
        //change rotation based on User Input
        if (horizontalScale > 0)// || _touchFollowScript.RightArrowTriggered)
        {
            _playerRotation = transform.eulerAngles;
            _playerRotation.z -= rotationSpeed;
        }
        if (horizontalScale < 0)// || _touchFollowScript.LeftArrowTriggered)
        {
            _playerRotation = transform.eulerAngles;
            _playerRotation.z += rotationSpeed;
        }
        transform.eulerAngles = _playerRotation;
        
        //to wrap around the Edges
        WrapToEdges();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity); 
        Instantiate(gameOver);

        AudioManager.Play(AudioClipName.PlayerDied);
        hud.StopGameTimer = true;
        Destroy(gameObject);
    }


    private void WrapToEdges()
    {
        var position = transform.position;
        var ScreenError = 1f;
        //simple 4 side wrapping conditions
        if (position.x - _shipRadius < ScreenUtils.ScreenLeft - ScreenError)
        {
            position.x *= -1;
            position.x -= ScreenError * Time.deltaTime;
        }
        else if (position.x + _shipRadius > ScreenUtils.ScreenRight + ScreenError)
        {
            position.x *= -1;
            position.x += ScreenError * Time.deltaTime;
        }

        if (position.y + _shipRadius > ScreenUtils.ScreenTop + ScreenError)
        {
            position.y *= -1;
            position.y += ScreenError * Time.deltaTime;
        }
        else if (position.y - _shipRadius < ScreenUtils.ScreenBottom - ScreenError)
        {
            position.y *= -1;
            position.y -= ScreenError * Time.deltaTime;
        }
        transform.position = position;
    }
}