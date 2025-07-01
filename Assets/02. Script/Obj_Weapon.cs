using UnityEngine;

public class Obj_Weapon : MonoBehaviour
{
    private Transform weapon_Pos;
    
    public GameObject bullet_Prefab;
    public Transform muzzle;
    

    public void Attack()
    {
        GameObject bullet = Instantiate(bullet_Prefab, muzzle.position, muzzle.rotation);
        bullet.gameObject.transform.SetParent(null);
    }

    public void Set_Weapon(GameObject cat)
    {
        weapon_Pos = cat.transform.GetChild(0).transform;
        
        int a = weapon_Pos.childCount;
        
        transform.SetParent(weapon_Pos);
        transform.localPosition = new Vector3(0, a * 3f, 0);
        cat.GetComponent<Cat_Move>().Get_Weapons();
    }
    
}
