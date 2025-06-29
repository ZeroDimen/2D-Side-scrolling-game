using UnityEngine;

// Cat이 상호작용하는 물체에 대한 스크립트
public class Cat_Interactive : MonoBehaviour
{
    [SerializeField]
    private Transform weapon_Pos;
    private Rigidbody2D Cat_Rb;
    public GameObject[] weapons;

    private void Start()
    {
        Cat_Rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log(other.gameObject.name);
            Grab();
        }
    }

    private void Grab()
    {
        transform.SetParent(weapon_Pos);
        // transform.localPosition = Vector3.zero;
        // transform.localRotation = Quaternion.identity;
    }
}
