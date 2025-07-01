using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obj_Pipe : MonoBehaviour
{
    private enum itemSpawn
    {
        Health,
        Weapon,
        Bullet,
        Pipe
    }

    private itemSpawn item;

    public Sprite[] sprites;

    // [SerializeField] private SpriteRenderer item_Renderer;
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
        item = (itemSpawn)Random.Range(0, 4);
        item_Object.SetActive(false);
        
        switch (item)
        {
            case itemSpawn.Health:
                item_Renderer.sprite = sprites[0];
                break;
            case itemSpawn.Weapon:
                item_Renderer.sprite = sprites[1];
                break;
            case itemSpawn.Bullet:
                item_Renderer.sprite = sprites[2];
                break;
            case itemSpawn.Pipe:
                item_Renderer.sprite = sprites[3];
                return;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        item_Object.SetActive(true);
    }

}
