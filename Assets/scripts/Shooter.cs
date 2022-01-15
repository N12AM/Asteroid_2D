using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void InstantiateBullet(Vector2 angle , Vector3 playerPosition , Vector3 playerAngles)
    {
        GameObject bullet =  Instantiate(bulletPrefab);
        bullet.transform.position = playerPosition;
        bullet.transform.eulerAngles = playerAngles;

        var rd2d = bullet.GetComponent<Rigidbody2D>();
        rd2d.AddForce(angle * Bullet.BulletSpeedMultiplierPerSeconds , ForceMode2D.Impulse);
        
        AudioManager.Play(AudioClipName.PlayerShot);


    }
}
