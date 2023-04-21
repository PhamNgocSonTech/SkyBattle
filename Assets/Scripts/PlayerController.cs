using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private ProjectileController projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireCooldown;

    private float tempCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //kiem tra player an phim A-D hoac mui ten Trai-Phai
        float horizontal = Input.GetAxis("Horizontal");

        //kiem tra player an phim W-S hoac mui ten Len-Xuong
        float verical = Input.GetAxis("Vertical");
    
        //lay ra duoc quãng đường di chuyen cua Player
        Vector2 direction = new Vector2(horizontal, verical);

        //Để di chuyển Player dùng hàm Translate sẽ truyền vào
        //direction (quảng đường di chuyển) * Time.deltaTime (thời gian 1 frame hpặc thời gian mỗi lần update) * moveSpeed (giá trị vận tốc)
        transform.Translate(direction * Time.deltaTime * moveSpeed );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tempCooldown <= 0)
            {
                Fire();
                tempCooldown = fireCooldown;
            }
        }
        tempCooldown -= Time.deltaTime;
    }

    private void Fire()
    {
        //Instantiate được sử dụng để clone đối tượng(projectile) được xây dựng sẵn
        ProjectileController projectileController = Instantiate(projectile, firePoint.position, Quaternion.identity, null);
        projectileController.FireDestroy();
    }
}
