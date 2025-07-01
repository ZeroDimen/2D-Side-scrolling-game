using System;
using System.Collections;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    [SerializeField] float speedBullet;
    private void Start()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, -90));
        StartCoroutine("Dsetory_Bullet");
    }

    private void Update()
    {
        gameObject.transform.localPosition += gameObject.transform.up * (speedBullet * Time.deltaTime);
    }
    IEnumerator Dsetory_Bullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
