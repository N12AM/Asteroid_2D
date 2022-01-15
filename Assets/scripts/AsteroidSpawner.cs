using System;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defaultAstroid;
    [SerializeField] private Sprite[] astroid1;
    private Asteroid _asteroid;
    private float _defaultWidth = 25f;
    private Camera _camera;

    
    // Start is called before the first frame update
    void Start()
    {

           _camera = Camera.main;
       
           //spawn Asteroid in the left middle
           LeftMiddle();
           
           //spawn Asteroid in the bottom middle
           BottomMiddle();
           
           //spawn Asteroid in the right middle
           RightMiddle();
           
           //spawn Asteroid in the top middle
           TopMiddle();
           
    }


    private void LeftMiddle()
    {
           //setting position in the Screen pixels to world location
           var location = new Vector2(_defaultWidth, (float)Screen.height / 2);
           location = _camera.ScreenToWorldPoint(location);
           
           //instantiating a asteroid prefab with the appropriate location 
           var spawnAsteroid =  Instantiate(defaultAstroid, location ,Quaternion.identity);
           
           _asteroid =  spawnAsteroid.GetComponent<Asteroid>();
           
           //setting the Asteroid Sprite to one of the 4 Sprites
           spawnAsteroid.GetComponent<SpriteRenderer>().sprite = astroid1[0];
           _asteroid.Initialize(Direction.Right);  
    }

    private void BottomMiddle()
    {
           var location = new Vector2 ((float)Screen.width / 2 , _defaultWidth);
           location = _camera.ScreenToWorldPoint(location);
           var spawnAsteroid =  Instantiate(defaultAstroid, location ,Quaternion.identity);
           
           _asteroid =  spawnAsteroid.GetComponent<Asteroid>();
           spawnAsteroid.GetComponent<SpriteRenderer>().sprite = astroid1[1];
           _asteroid.Initialize(Direction.Up); 
    }


    private void RightMiddle()
    {
           var location = new Vector2 (Screen.width - _defaultWidth , (float) Screen.height / 2);
           location = _camera.ScreenToWorldPoint(location);
           var spawnAsteroid =  Instantiate(defaultAstroid, location ,Quaternion.identity);
           
           _asteroid =  spawnAsteroid.GetComponent<Asteroid>();
           spawnAsteroid.GetComponent<SpriteRenderer>().sprite = astroid1[2];
           _asteroid.Initialize(Direction.Left);  
    }

    private void TopMiddle()
    {
           var location = new Vector2 ((float)Screen.width / 2 ,  Screen.height - _defaultWidth);
           location = _camera.ScreenToWorldPoint(location);
           var spawnAsteroid =  Instantiate(defaultAstroid, location ,Quaternion.identity);
           
           _asteroid =  spawnAsteroid.GetComponent<Asteroid>();
           spawnAsteroid.GetComponent<SpriteRenderer>().sprite = astroid1[3];
           _asteroid.Initialize(Direction.Down);  
    }
}
