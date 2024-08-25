using DesignPatterns.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject endPrefab;
    public GameObject player;
    public PlayerController playerController;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            var allObjects = FindObjectsOfType<GameObject>();
            foreach (var obj in allObjects)
            {
                obj.SetActive(false);
            }
            endPrefab.SetActive(true);
        }
    }
}
