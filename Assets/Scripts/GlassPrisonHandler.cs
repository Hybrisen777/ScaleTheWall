using DesignPatterns.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPrisonHandler : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> walls;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int currentIgnoreWall = 0;
    private void Awake()
    {
        playerInput.switchToRightEvent += OnSwitchRight;
        playerInput.switchToLeftEvent += OnSwitchLeft;
    }

    private void OnSwitchLeft()
    {

        walls[currentIgnoreWall].layer = LayerMask.NameToLayer("GroundLayer");
        if(currentIgnoreWall == 0) 
        {
            currentIgnoreWall = 4;
        }
        walls[currentIgnoreWall - 1].layer = LayerMask.NameToLayer("Ignore Raycast");
        currentIgnoreWall--;
    }

    private void OnSwitchRight()
    {
        walls[currentIgnoreWall].layer = LayerMask.NameToLayer("GroundLayer");
        if(currentIgnoreWall == 3)
        {
            currentIgnoreWall = -1;
        }
        walls[currentIgnoreWall + 1].layer = LayerMask.NameToLayer("Ignore Raycast");
        currentIgnoreWall++;
    }

    private void OnDestroy()
    {
        if (playerInput != null)
        {
            playerInput.switchToRightEvent -= OnSwitchRight;
            playerInput.switchToLeftEvent -= OnSwitchLeft;
        }
    }
}
