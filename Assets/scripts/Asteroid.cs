using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    private float _colliderHalfRadius;
    private const float MinImpulse = 1f;
    private const float MaxImpulse = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        _colliderHalfRadius = GetComponent<CircleCollider2D>().radius / 2;
    }

    public void Update()
    {
        WrapToEdges();
    }
    
    private void WrapToEdges()
    {
       
            var position = transform.position;
            const float screenError = 1.7f;
            //simple 4 side wrapping conditions
            if (position.x - _colliderHalfRadius < ScreenUtils.ScreenLeft - screenError)
            {
                position.x *= -1;
                position.x -= screenError * Time.deltaTime;
            }
            else if (position.x + _colliderHalfRadius > ScreenUtils.ScreenRight + screenError)
            {
                position.x *= -1;
                position.x += screenError * Time.deltaTime;
            }

            if (position.y + _colliderHalfRadius > ScreenUtils.ScreenTop + screenError)
            {
                position.y *= -1;
                position.y += screenError * Time.deltaTime;
            }
            else if (position.y - _colliderHalfRadius < ScreenUtils.ScreenBottom - screenError)
            {
                position.y *= -1;
                position.y -= screenError * Time.deltaTime;
            }
            transform.position = position;
        
    }

    public void Initialize(Direction direction)
    {
        var randomAngle30 = Random.Range(0, (30 * Mathf.PI) / 180);

        if (direction == Direction.Right)
        {
            var newAngle = (2 * Mathf.PI - (15 * Mathf.Deg2Rad)) + randomAngle30;
            var newDirection = new Vector2(Mathf.Cos(newAngle) , Mathf.Sin(newAngle));

            var magnitude = Random.Range(MinImpulse, MaxImpulse);
            GetComponent<Rigidbody2D>().AddForce(newDirection * magnitude, ForceMode2D.Impulse);
        }
        
        else if (direction == Direction.Up)
        {
            var newAngle = ( (Mathf.PI / 2) - (15 * Mathf.Deg2Rad)) + randomAngle30;
            var newDirection = new Vector2(Mathf.Cos(newAngle) , Mathf.Sin(newAngle));

            var magnitude = Random.Range(MinImpulse, MaxImpulse);
            GetComponent<Rigidbody2D>().AddForce(newDirection * magnitude, ForceMode2D.Impulse);
        }
        else if (direction == Direction.Left)
        {
            var newAngle = (Mathf.PI - (15 * Mathf.Deg2Rad)) + randomAngle30;
            var newDirection = new Vector2(Mathf.Cos(newAngle) , Mathf.Sin(newAngle));

            var magnitude = Random.Range(MinImpulse, MaxImpulse);
            GetComponent<Rigidbody2D>().AddForce(newDirection * magnitude, ForceMode2D.Impulse);
        }
        
        else if (direction == Direction.Down)
        {
            var newAngle = ( ((3 * Mathf.PI) / 2) - (15 * Mathf.Deg2Rad)) + randomAngle30;
            var newDirection = new Vector2(Mathf.Cos(newAngle) , Mathf.Sin(newAngle));

            var magnitude = Random.Range(MinImpulse, MaxImpulse);
            GetComponent<Rigidbody2D>().AddForce(newDirection * magnitude, ForceMode2D.Impulse);
        }
        
        else if (direction == Direction.unknown)
        {
            var randAngle = Random.Range(0, (2 * Mathf.PI));
            var biDirection = new Vector2(Mathf.Cos(randAngle) , Mathf.Sin(randAngle));
            
            var magnitude = Random.Range(MinImpulse , MaxImpulse);
            
            GetComponent<Rigidbody2D>().AddForce(biDirection * magnitude * 2 , ForceMode2D.Impulse);
            
        }
        
        
    }


    public void Destroy()
    {
        Destroy(gameObject);
    }
    
}    
