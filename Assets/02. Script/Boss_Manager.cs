using System;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Manager : MonoBehaviour
{
    [SerializeField] private float boss_MaxHP;
    private float Boss_currentHP;
    [SerializeField] private Image boss_HP;

    private void Start()
    {
        Boss_currentHP = boss_MaxHP;
        boss_HP.fillAmount = 1f;
    }

    private void Hit(float damage)
    {
        Boss_currentHP -= damage;

        if (Boss_currentHP <= 0)
        {
            Debug.Log("dest");
            Destroy(gameObject);
        }

        UpdateHpBar();
    }

    private void UpdateHpBar()
    {
        float Percentage_Boss_HP = (Boss_currentHP / boss_MaxHP);
        boss_HP.fillAmount = Percentage_Boss_HP;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Hit(5f);
        }
    }
}
