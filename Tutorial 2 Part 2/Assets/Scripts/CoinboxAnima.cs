using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinboxAnima : MonoBehaviour
{
    public bool coinboxHit;
    public bool coinboxEmpty;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        if (GetComponent<CoinboxCheck>().coinboxHit)
        {
            anim.SetTrigger("isHit");
        }

        if (GetComponent<CoinboxCheck>().coinboxEmpty)
        {
            anim.SetBool("isEmpty", true);
        }

        else
        {
            anim.SetBool("isEmpty", false);
        }
    }
}
