using UnityEngine;

// 머터리얼을 움직여 배경 화면을 움직이게 하는 스크립트
public class BG_Offset : MonoBehaviour
{
    [SerializeField] float offsetSpeed;
    private MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Vector2 offset = Vector2.right * (offsetSpeed * Time.deltaTime);
        
        renderer.material.SetTextureOffset("_MainTex", renderer.material.mainTextureOffset + offset);
    }
    
}
