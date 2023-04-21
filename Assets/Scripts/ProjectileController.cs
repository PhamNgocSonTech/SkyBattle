using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Projectile();
    }

    private void Projectile()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }

    public void FireDestroy()
    {
        Destroy(gameObject, 2f);
    }
}
