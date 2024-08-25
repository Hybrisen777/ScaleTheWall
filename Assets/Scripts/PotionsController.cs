using DesignPatterns.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsController : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerController.PotionCollected();
        }
    }
}
