using System;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Manager : MonoBehaviour
{
    [SerializeField] private Manager_UI manager_UI;
    
    public enum MoveType {Horizontal, Vertical}
    public MoveType moveType;

    private Animator boss_Ani;
    
    [SerializeField] private float boss_MaxHP;
    private float Boss_currentHP;
    
    [SerializeField] private Image boss_HP;
    
    private bool isHit;
    
    private void Start()
    {
        Boss_currentHP = boss_MaxHP;
        boss_Ani = GetComponent<Animator>();
        boss_HP.fillAmount = 1f;
    }

  
    private void Hit(float damage) // 피격시 기능을 호출하는 함수
    {
        if (!isHit)
        {
            boss_Ani.SetTrigger("Hit");
            isHit = true;
        }
        
        Boss_currentHP -= damage;

        if (Boss_currentHP <= 0)
        {
            Destroy(gameObject);
            manager_UI.Ending(false);
        }

        UpdateHpBar();
    }
    private void UpdateHpBar() // 현재 체력에 따라 채력바 수치를 조정하는 함수
    {
        float Percentage_Boss_HP = (Boss_currentHP / boss_MaxHP);
        boss_HP.fillAmount = Percentage_Boss_HP;
    }
    private void EndHit() // 피격 애니메이션에 간격을 주기위한 함수 (애니메이션 이벤트에서 호출)
    {
        isHit = false;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Hit(5f);
        }
    }

}
