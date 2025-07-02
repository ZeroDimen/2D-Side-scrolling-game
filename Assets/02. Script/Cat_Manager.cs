using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Cat의 움직임 제어 및 애니메이션을 관리하는 스크립트
public class Cat_Manager : MonoBehaviour
{
    [SerializeField] private Manager_UI manager_UI;
    
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

    [SerializeField] private GameObject hp_Bar;
    [SerializeField] private GameObject magazine_Bar;

    [SerializeField] private Sprite[] hp_Sprite;
    [SerializeField] private Sprite mag_Sprite;
    
    private int cat_MaxHp;
    private int cat_CurrentHp;

    private int cat_MaxMag;
    private int cat_CurrentMag;
    
    private int cat_JumpCount;
    private float cat_X;
    private float weapon_angle;
    
    public int weapons_Count;


    private void Start()
    {
        Cat_Rb = GetComponent<Rigidbody2D>();
        Cat_Ani = GetComponent<Animator>();
        Cat_Sprite = GetComponent<SpriteRenderer>();
        
        cat_MaxHp = 3;
        cat_CurrentHp = cat_MaxHp;

        cat_MaxMag = 9;
        
        SetHp();
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
        if (Input.GetKeyDown(KeyCode.K) && cat_CurrentMag > 0) // 조건 추가
        {
            foreach (var weapon in weapons)
            {
                weapon.GetComponent<Obj_Weapon>().Attack();
            }
            cat_CurrentMag--;
            SetMagazine(true);
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
                Cat_Sprite.flipX = true;
                weapon.transform.localScale = new Vector3(10, -10, 1);
            }
            else if (weapon_angle <= 90)
            {
                Cat_Sprite.flipX = false;
                weapon.transform.localScale = new Vector3(10, 10, 1);
            }
        }
    }

    public void SetHp(int velue = 0)
    {
        cat_CurrentHp += velue;

        if (cat_CurrentHp > cat_MaxHp)
        {
            cat_CurrentHp = cat_MaxHp;
        }
        else if (cat_CurrentHp < 0)
        {
            Debug.Log("Dead");
        }
        
        for (int i = cat_MaxHp; i > cat_CurrentHp; i--)
        {
            hp_Bar.transform.GetChild(i).GetComponent<Image>().sprite = hp_Sprite[0]; 
        }
        
        for (int i = 0; i < cat_CurrentHp; i++)
        {
            hp_Bar.transform.GetChild(i).GetComponent<Image>().sprite = hp_Sprite[1]; 
        }

    }

    public void SetMagazine(bool use = false)
    {
        if (use == true)
        {
            for (int i = cat_MaxMag; i > cat_CurrentMag; i--)
            {
                Debug.Log("Sott");
                magazine_Bar.transform.GetChild(i-1).gameObject.SetActive(false);
            }
        }
        else
        {
            cat_CurrentMag = cat_MaxMag;
            for (int i = 0; i < cat_MaxMag; i++)
            {
                magazine_Bar.transform.GetChild(i).gameObject.SetActive(true);
                magazine_Bar.transform.GetChild(i).GetComponent<Image>().sprite = mag_Sprite;
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
