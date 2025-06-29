using UnityEngine;

// Cat의 움직임 제어 및 애니메이션을 관리하는 스크립트
public class Cat_Move : MonoBehaviour
{
    private Rigidbody2D Cat_Rb;
    private Animator Cat_Ani;

    [SerializeField]
    private float speedCatBack;
    [SerializeField]
    private float speedCatRun;
    [SerializeField]
    private float powerCatJump;
    [SerializeField]
    private int countCatJump;
    
    private int cat_JumpCount;
    private float cat_X;


    private void Start()
    {
        Cat_Rb = GetComponent<Rigidbody2D>();
        Cat_Ani = GetComponent<Animator>();
    }

    private void Update()
    {
        cat_X = Input.GetAxisRaw("Horizontal");

        if (cat_JumpCount != 0)
        {
            speedCatBack = 0;
        }
        else
        {
            speedCatBack = 1;
        }
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            cat_JumpCount = 0;
            
        }
    }
}
