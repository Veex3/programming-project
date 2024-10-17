using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //private SpriteRenderer sr;
    public bool hasKey = false;


    //sprite variables
    //public Sprite upSprite;
    //public Sprite leftSprite;
    //public Sprite rightSprite;
    //public Sprite frontSprite;

    //public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        //go up
        if (Input.GetKey("w"))
        {
            newPosition.y += speed;
            //change sprite to up sprite
            //sr.sprite = upSprite;
        }

        //go left
        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
            //sr.sprite = leftSprite;
        }

        //go down
        if (Input.GetKey("s"))
        {
            newPosition.y -= speed;
            //sr.sprite = frontSprite;
        }

        //go right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            //sr.sprite = rightSprite;
        }

        transform.position = newPosition;
    }
}