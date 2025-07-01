using UnityEngine;

public class Item_Interactive : MonoBehaviour
{
    private Sprite item_sprite;
    public GameObject cat;

    public GameObject weapon_Obj;
    
    private void OnEnable()
    {
        item_sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (item_sprite.name == "item_Health")
            {
                Debug.Log("Health");
            }
            else if (item_sprite.name == "item_Weapon")
            {
                GameObject newWeapon = Instantiate(weapon_Obj);
                newWeapon.GetComponent<Obj_Weapon>().Set_Weapon(cat);
            }
            else if (item_sprite.name == "item_Bullet")
            {
                Debug.Log("Bullet");
            }
        }
        gameObject.SetActive(false);
    }
}
