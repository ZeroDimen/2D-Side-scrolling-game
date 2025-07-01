using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Cat의 움직임 제어 및 애니메이션을 관리하는 스크립트
public class Cat_Move : MonoBehaviour
{
    private Rigidbody2D Cat_Rb;
    private Animator Cat_Ani;
    private SpriteRenderer Cat_Sprite;

    [SerializeField]
    private float speedCatBack;
    [SerializeField]
    private float speedCatRun;
    [SerializeField]
    private float powerCatJump;
    [SerializeField]
    private int countCatJump;

    [SerializeField] private float speedWeapon;

    [SerializeField]
    private List<GameObject> weapons = new List<GameObject>();
    public int weapons_Count;
    private int cat_JumpCount;
    private float cat_X;
    private float weapon_angle;
    


    private void Start()
    {
        Cat_Rb = GetComponent<Rigidbody2D>();
        Cat_Ani = GetComponent<Animator>();
        Cat_Sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        cat_X = Input.GetAxisRaw("Horizontal");

        weapon_angle -= cat_X * speedWeapon;
        if (weapon_angle >= 180)
        {
            weapon_angle = 180;
        }
        else if (weapon_angle <= 0)
        {
            weapon_angle = 0;
        }
        
        if (cat_JumpCount != 0)
        {
            speedCatBack = 0;
        }
        else
        {
            speedCatBack = 1;
        }
        Jump();
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
        Move_Weapons();
    }

    private void Move()
    {
        Cat_Ani.SetFloat("cat_X" , cat_X);
        Cat_Rb.linearVelocityX = cat_X * speedCatRun - speedCatBack;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cat_JumpCount < countCatJump)
        {
            Cat_Rb.AddForceY(powerCatJump, ForceMode2D.Impulse);
            cat_JumpCount++;
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (var weapon in weapons)
            {
                weapon.GetComponent<Obj_Weapon>().Attack();
            }
            
        }
    }

    public void Get_Weapons() // 자식으로 생성된 무기 오브젝트를 리스트에 넣어 관리하기 위한 함수
    {
        weapons_Count = gameObject.transform.GetChild(0).childCount;
        weapons.Add(gameObject.transform.GetChild(0).GetChild(weapons_Count-1).gameObject);
    }

    private void Move_Weapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.transform.eulerAngles = new Vector3(0, 0, weapon_angle);
      
            
            if (weapon_angle >= 90 )
            {
                // Cat_Sprite.flipX = true;
                weapon.transform.localScale = new Vector3(10, -10, 1);
            }
            else if (weapon_angle <= 90)
            {
                // Cat_Sprite.flipX = false;
                weapon.transform.localScale = new Vector3(10, 10, 1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            cat_JumpCount = 0;
            
        }
    }
    
}
