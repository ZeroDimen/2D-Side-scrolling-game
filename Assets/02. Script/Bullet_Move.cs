using System.Collections;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    [SerializeField] float speedBullet;
    private void Start()
    {
        StartCoroutine("Dsetory_Bullet");
    }

    private void Update()
    {
        gameObject.transform.localPosition += gameObject.transform.right * (speedBullet * Time.deltaTime);
    }
    IEnumerator Dsetory_Bullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
