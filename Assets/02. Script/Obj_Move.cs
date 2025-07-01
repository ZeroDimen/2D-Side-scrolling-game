using UnityEngine;

public class Obj_Move : MonoBehaviour
{
    [SerializeField]
    private float theta;
    [SerializeField]
    private float power;
    [SerializeField]
    private float speed;
    
    
    private Vector3 initPos;

    private void OnEnable()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        theta += Time.deltaTime * speed;
        Move();
    }
    
    
    private void Move() // 보스 오브젝트의 움직임을 제어하는 함수
    {
        transform.position = new Vector3(gameObject.transform.position.x , initPos.y + power * Mathf.Sin(theta), gameObject.transform.position.z);
    }
}
