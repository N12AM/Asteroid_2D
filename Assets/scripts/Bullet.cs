using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    private static float bulletSpeedMultiplierPerSeconds = 20f;
    private GameObject _explosion;
    private float _bulletRadius;
    private Timer _timer;
    public static float BulletSpeedMultiplierPerSeconds => bulletSpeedMultiplierPerSeconds;
    

    // Start is called before the first frame update
    void Start()
    {

         _explosion = (GameObject)Resources.Load("explosion_0");
         _bulletRadius = GetComponent<CapsuleCollider2D>().size.x;
         var transform1 = transform;
         var scale = transform1.localScale;
         scale.x = 0.4f;
         scale.y = 0.4f;

         transform1.localScale = scale;

         _timer = gameObject.AddComponent<Timer>();
         _timer.Duration = 1f;
         _timer.Run();
         //   var rb2d = GetComponent<Rigidbody2D>();
         //    rb2d.AddForce(new Vector2(0,5 ) ,ForceMode2D.Impulse);
    }

 

    private void OnCollisionEnter2D(Collision2D other)
    {
        var asteroid = other.gameObject;
        var asteroidScript = asteroid.GetComponent<Asteroid>();
        if (asteroidScript != null)
        {
           

            //getting the references of the current collided asteroid
            var asteroidLastKnownPosition = asteroid.transform.position;
            var asteroidLastKnownSprite = asteroid.GetComponent<SpriteRenderer>().sprite;
            var asteroidLastKnownScale = asteroid.transform.localScale;
            
            //destroy the asteroid that collides with the bullet
            asteroidScript.Destroy();
            
            //this creates a explosion animation only in case of the child asteroids
            if (asteroidLastKnownScale.x < 1f && asteroidLastKnownScale.y < 1f)
            {
                var explosion =  Instantiate(_explosion);
                var bulletPosition = transform.position;
                var explosionPosition = explosion.transform.position;

                explosionPosition.x = bulletPosition.x + 0.5f;
                explosionPosition.y = bulletPosition.y - 0.2f;

                explosion.transform.position = explosionPosition;
            
                // explosion.transform.position = transform.position;
                var explosionScale = explosion.transform.localScale;
                explosionScale.x = 2f;
                explosionScale.y = 2f;
                explosion.transform.localScale = explosionScale; 
            }
            
            if (asteroidLastKnownScale.x >= 1f && asteroidLastKnownScale.y >= 1f)
            {
                //instantiate 2 new asteroids with bidirectional varying velocity when the bigger asteroid is destroyed
                var childAsteroidOne = Instantiate(asteroidPrefab);
                var childAsteroidTwo = Instantiate(asteroidPrefab);
            
                //setting the position of two newer child asteroid of the destroyed asteroid
                childAsteroidOne.transform.position = asteroidLastKnownPosition;
                childAsteroidTwo.transform.position = asteroidLastKnownPosition;
            
                //setting the sprite of the two newer child asteroids
                childAsteroidOne.GetComponent<SpriteRenderer>().sprite = asteroidLastKnownSprite;
                childAsteroidTwo.GetComponent<SpriteRenderer>().sprite = asteroidLastKnownSprite;
            
                //setting the scale of the two newer child asteroids 
                //which is half of the parent asteroid
                childAsteroidOne.transform.localScale = asteroidLastKnownScale / 2;
                childAsteroidTwo.transform.localScale = asteroidLastKnownScale / 2;
            
                //getting the reference of the two newer child asteroid scripts
                var childOneScript = childAsteroidOne.GetComponent<Asteroid>();
                var childTwoScript = childAsteroidTwo.GetComponent<Asteroid>();
            
                //finally setting the direction of the velocity of the two newer child asteroids
                childOneScript.Initialize(Direction.unknown);
                childTwoScript.Initialize(Direction.unknown);
                
            }           
            

            

            //plays a audio when an Asteroid is destroyed
            AudioManager.Play(AudioClipName.AsteroidBlast);
            
            //destroy the bullet after it collides with the asteroid
            Destroy(gameObject);
            
        }
        
    }

    private void Update()
    {
        if (_timer.Finished)
        {
            Destroy(gameObject);
        }
        
        
        WrapToEdges();
    }


    private void WrapToEdges()
    {
        var position = transform.position;
        var ScreenError = 0.5f;
        //simple 4 side wrapping conditions
        if (position.x  < ScreenUtils.ScreenLeft - ScreenError)
        {
            position.x *= -1;
            position.x -= ScreenError * Time.deltaTime;
        }
        else if (position.x > ScreenUtils.ScreenRight + ScreenError)
        {
            position.x *= -1;
            position.x += ScreenError * Time.deltaTime;
        }

        if (position.y > ScreenUtils.ScreenTop + ScreenError)
        {
            position.y *= -1;
            position.y += ScreenError * Time.deltaTime;
        }
        else if (position.y < ScreenUtils.ScreenBottom - ScreenError)
        {
            position.y *= -1;
            position.y -= ScreenError * Time.deltaTime;
        }
        transform.position = position;
    }
    
    
}
