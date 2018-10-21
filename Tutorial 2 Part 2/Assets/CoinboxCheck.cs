using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinboxCheck : MonoBehaviour {

    public int numberOfCoins;
    public Transform coinboxHitbox;
    public float coinboxHitWidth;
    public float coinboxHitHeight;
    public LayerMask isPlayer;
    private bool coinboxHit = false;

    private AudioSource source;
    public AudioClip coinClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start() {
    }

    private void FixedUpdate()
    {
        coinboxHit = Physics2D.OverlapBox(coinboxHitbox.position, new Vector2(coinboxHitWidth, coinboxHitHeight), 0, isPlayer);
        if (coinboxHit == true)
        {
            numberOfCoins = numberOfCoins - 1;
            float vol = Random.Range(volLowRange, volHighRange); source.PlayOneShot(coinClip);
        }
        if (numberOfCoins <= 0)
        {
            gameObject.SetActive(false);
            float vol = Random.Range(volLowRange, volHighRange); source.PlayOneShot(coinClip);
        }

    }

}
