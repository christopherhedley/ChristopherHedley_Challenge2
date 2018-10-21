using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject player;
    public AudioClip deathClip;
    public AudioClip victoryClip;
    private AudioSource source;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {

        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void Awake()
    {
            source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()

    {
        if (player.transform.position.x >= 18f && player.transform.position.x <= 209f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }

        if (player.transform.position.x >= 209f)
        {
            transform.position = new Vector3(209f, 2.5f, -10f);
            source.PlayOneShot(victoryClip);
            player.GetComponent<AudioSource>().enabled = false;
        }

        if (player.transform.position.x <= 18f)
        {
            transform.position = new Vector3(18f, 2.5f, -10f);
        }


        if (player.gameObject.activeInHierarchy == false)
        {
            source.PlayOneShot(deathClip);
        }

    }
}
