using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obj_Pipe : MonoBehaviour
{
    public Sprite[] sprites;

    [SerializeField] private GameObject item_Object;

    public float Loop_Speed = 3f;
    public float ReturnPosX = 15f;
    public float Random_PosY;

    private SpriteRenderer item_Renderer;

    private Vector3 initPos;

    private void Start()
    {
        item_Renderer = item_Object.GetComponent<SpriteRenderer>();
        Reset_Obj();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.left * (Loop_Speed * Time.deltaTime);
        if (transform.position.x <= -ReturnPosX)
        {
            Reset_Obj();
        }
    }

    private void Reset_Obj()
    {
        Random_PosY = Random.Range(-5f, -1.5f);
        transform.position = new Vector3(ReturnPosX, Random_PosY, 0f);
        int it = Random.Range(0, 12);

        item_Object.SetActive(false);

        if (it < 2) // 0 1이 나오면 Health Item 생성
        {
            item_Renderer.sprite = sprites[0];
        }
        else if (it < 5) // 2 3 4가 나오면 Weapon Item 생성
        {
            item_Renderer.sprite = sprites[1];
        }
        else if (it < 10) // 5 6 7 8 9가 나오면 Bullet Item 생성
        {
            item_Renderer.sprite = sprites[2];
        }
        else if (it < 12) // 10 11이 나오면 Pipe만 생성
        {
            item_Renderer.sprite = sprites[3];
        }
        else
        {
            Debug.Log("Err");
        }

        item_Object.SetActive(true);
    }
}
