using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinboxCheck : MonoBehaviour
{

    public int numberOfCoins;
    public Transform coinboxHitbox;
    public float coinboxHitWidth;
    public float coinboxHitHeight;
    public LayerMask isPlayer;
    public bool coinboxHit = false;
    public bool coinboxEmpty = false;

    private AudioSource source;
    public AudioClip coinClip;
    private float volLowRange = 1f;
    private float volHighRange = 3.0f;

    // Use this for initialization
    void Start()
    {
    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        coinboxHit = Physics2D.OverlapBox(coinboxHitbox.position, new Vector2(coinboxHitWidth, coinboxHitHeight), 0, isPlayer);
        if (coinboxHit == true)
        {
            float vol = Random.Range(volLowRange, volHighRange); source.PlayOneShot(coinClip);
            numberOfCoins = numberOfCoins - 1;
        }
        

    }

    private void LateUpdate()
    {
        if (numberOfCoins <= 0)
        {
            coinboxEmpty = true;
        }
    }

}
