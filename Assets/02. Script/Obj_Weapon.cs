using UnityEngine;

public class Obj_Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform weapon_Pos;
    
    public GameObject bullet_Prefab;
    public Transform muzzle;

    private void Start()
    {
        weapon_Pos = GameObject.FindWithTag("Player").transform.GetChild(0);
    }

    public void Attack()
    {
        GameObject bullet = Instantiate(bullet_Prefab, muzzle.position, muzzle.rotation);
        bullet.gameObject.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int a = weapon_Pos.childCount;
            transform.SetParent(weapon_Pos);
            transform.localPosition = new Vector3(0, a * 3f, 0);
            other.gameObject.GetComponent<Cat_Move>().Get_Weapons();
        }
    }
}
