using UnityEngine;

// 물체를 움직여 배경 화면과 함께 움직이는 하는 스크립트
public class Obj_Offset : MonoBehaviour
{
    [SerializeField] private float speedObject;

    private void FixedUpdate()
    {
        gameObject.transform.Translate(Vector3.left * speedObject);
    }
}
