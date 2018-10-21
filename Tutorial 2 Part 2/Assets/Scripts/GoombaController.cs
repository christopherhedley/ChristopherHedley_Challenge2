using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour {

    public float speed;
    //ground check
    private bool wallHit = false;
    public Transform wallHitbox;
    public float wallHitWidth;
    public float wallHitHeight;
    public LayerMask isGround;

    private AudioSource source;
    public AudioClip deathClip;
    public AudioClip stompClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    private bool headHit = false;
    public Transform headHitbox;
    public float headHitWidth;
    public float headHitHeight;
    public LayerMask isPlayer;



    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }

    private void FixedUpdate()
    {

        //wallHit is a bool similar to the ground one in the player code.
        //Physics2D.OverlapBox is similar to Physics2D.OverlapCircle but uses a box
        //The next is a Vector 2 with the box's Width and Height which are floats that I made public so I could edit them in the editor. 
        //The zero is the z value we don't need.
        //isGround is a LayerMask of everything that is ground.

        wallHit = Physics2D.OverlapBox(wallHitbox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if (wallHit == true)
        {
            speed = speed * -1;
        }
     


        headHit = Physics2D.OverlapBox(headHitbox.position, new Vector2(headHitWidth, headHitHeight), 0, isPlayer);
        if (headHit == true)
        {
            gameObject.SetActive(false);
            float vol = Random.Range(volLowRange, volHighRange); source.PlayOneShot(stompClip);
        }

       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            float vol = Random.Range(volLowRange, volHighRange); source.PlayOneShot(deathClip);
        }
    }

}
