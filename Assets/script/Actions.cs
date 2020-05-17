using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

    public bool walkPlayer;
    public bool firePlayer;


    private Animator playerAnimation;

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }
    

    void Update()
    {
        playerAnimation.SetBool("playerWalking",walkPlayer);
        playerAnimation.SetBool("playerFiring", firePlayer);
    }
}
