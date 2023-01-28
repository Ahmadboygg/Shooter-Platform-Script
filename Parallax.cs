using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    private float startPosition;
    private float lenght;

    [SerializeField] private GameObject camera;
    
    void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1-parallaxEffect));
        float distance = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector2(startPosition + distance, transform.position.y);
        
        if(temp > startPosition + lenght)
        {
            startPosition += lenght;
        }
        else if(temp < startPosition - lenght)
        {
            startPosition -= lenght;
        }
    }
}
