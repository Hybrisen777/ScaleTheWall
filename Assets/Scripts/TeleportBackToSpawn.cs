using DesignPatterns.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBackToSpawn : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject player;
    public Transform TeleportTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterController.enabled = false;
            player.transform.position = TeleportTarget.position;
            characterController.enabled = true;
        }
    }
}
