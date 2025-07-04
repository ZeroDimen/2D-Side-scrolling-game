using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Manager : MonoBehaviour
{
    [SerializeField] private Manager_UI manager_UI;
    [SerializeField] private Manager_Audio manager_Audio;
    public enum MoveType {Horizontal, Vertical}
    public MoveType moveType;

    private Animator boss_Ani;
    
    [SerializeField] private float boss_MaxHP;
    private float Boss_currentHP;
    
    [SerializeField] private Image boss_HPBar;
    [SerializeField] private GameObject attack_Prefab;
    [SerializeField] private Transform attack_Pos;
    
    private bool isHit;
    private bool isAttack;
    
    private void Start()
    {
        Boss_currentHP = boss_MaxHP;
        boss_Ani = GetComponent<Animator>();
        boss_HPBar.fillAmount = 1f;
    }

    private void Update()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        if (!isAttack && !isHit)
        {
            isAttack = true;
            boss_Ani.SetTrigger("Attack");
            yield return new WaitForSeconds(1.5f);
            isAttack = false;
        }
    }

    private void Make_Bullet()
    {
        manager_Audio.SFX_Play("Shoot_Boss");
        GameObject bullet = Instantiate(attack_Prefab, attack_Pos.position, attack_Pos.rotation);
        bullet.gameObject.transform.SetParent(null);
    }
    
    
  
    private void Hit(float damage) // 피격시 기능을 호출하는 함수
    {
        if (!isHit)
        {
            manager_Audio.SFX_Play("Hit_Boss");
            boss_Ani.SetTrigger("Hit");
            isHit = true;
        }
        
        Boss_currentHP -= damage;

        if (Boss_currentHP <= 0)
        {
            Destroy(gameObject);
            manager_UI.Ending(true);
        }

        UpdateHpBar();
    }
    private void UpdateHpBar() // 현재 체력에 따라 채력바 수치를 조정하는 함수
    {
        float Percentage_Boss_HP = (Boss_currentHP / boss_MaxHP);
        boss_HPBar.fillAmount = Percentage_Boss_HP;
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
