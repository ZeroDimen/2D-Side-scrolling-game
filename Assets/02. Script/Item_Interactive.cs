using UnityEngine;

public class Item_Interactive : MonoBehaviour
{
    
    [SerializeField] private Manager_Audio manager_Audio;
    
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
                cat.GetComponent<Cat_Manager>().SetHp(1);
                manager_Audio.SFX_Play("Item");
            }
            else if (item_sprite.name == "item_Weapon")
            {
                GameObject newWeapon = Instantiate(weapon_Obj);
                newWeapon.GetComponent<Obj_Weapon>().Set_Weapon(cat);
                manager_Audio.SFX_Play("Item");
            }
            else if (item_sprite.name == "item_Bullet")
            {
                cat.GetComponent<Cat_Manager>().SetMagazine(false);
                manager_Audio.SFX_Play("Item");
            }
        }
        gameObject.SetActive(false);
    }
}
