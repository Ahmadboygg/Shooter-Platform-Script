using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletEffect;
    [SerializeField] private Transform bulletEffectPoint; 

    void Start()
    {
        Invoke("DestroyBullet", 3f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * 2f * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
