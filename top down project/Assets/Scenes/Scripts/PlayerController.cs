using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;
    public bool hasKey = false;
    public AudioSource soundEffects;
    public AudioClip[] sounds;

    //sprite variables
    public Sprite MB_Butt;
    public Sprite MB_Left;
    public Sprite MB_Right;
    public Sprite MB_Front;

    public Rigidbody2D rb;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        if (instance != null) //if another instance of the player is in the scene
        {
            Destroy(gameObject); //then destroy it
        }

        instance = this; //reassign the instance to the current player
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        //go up
        if (Input.GetKey("w"))
        {
            newPosition.y += speed;
            sr.sprite = MB_Butt;
        }

        //go left
        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
            sr.sprite = MB_Left;
        }

        //go down
        if (Input.GetKey("s"))
        {
            newPosition.y -= speed;
            sr.sprite = MB_Front;
        }

        //go right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            sr.sprite = MB_Right;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if colliding with a game object with specific tag
        if (collision.gameObject.tag.Equals("door1"))
        {
            Debug.Log("go to scene 2");
            soundEffects.PlayOneShot(sounds[0], .7f); //play door sound effect
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.tag.Equals("key"))
        {
            Debug.Log("obtained key");
            soundEffects.PlayOneShot(sounds[0], .7f); //play item collect sound effect
            hasKey = true; //player has the key now
        }

        if (collision.gameObject.tag.Equals("door2") && hasKey == true)
        {
            Debug.Log("unlocked door!");
            soundEffects.PlayOneShot(sounds[0], .7f);
            SceneManager.LoadScene(3); //take to new scene
        }

        if (collision.gameObject.tag.Equals("door3") && hasKey == true)
        {
            Debug.Log("unlocked door!");
            //soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(2); //take to new scene
        }
    }
}