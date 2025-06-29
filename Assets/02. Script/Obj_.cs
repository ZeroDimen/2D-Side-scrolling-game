using UnityEngine;

public class Obj_ : MonoBehaviour
{
    public Transform weapon_Pos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.SetParent(weapon_Pos);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}
