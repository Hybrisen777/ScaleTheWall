using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    [SerializeField]
    private SpawnBlocksManager spawnBlocksManagerSubject;
    [SerializeField]
    private TextMeshProUGUI blockCounter;

    private void Awake()
    {
        spawnBlocksManagerSubject.blockCountChanged += OnBlockCountChanged;
    }

    private void OnBlockCountChanged()
    {
        var blocksLeft = spawnBlocksManagerSubject.BlockLimit - spawnBlocksManagerSubject.BlockCount;
        blockCounter.text = blocksLeft.ToString();
    }

    private void OnDestroy()
    {
        if (spawnBlocksManagerSubject != null)
        {
            spawnBlocksManagerSubject.blockCountChanged -= OnBlockCountChanged;
        }
    }
}
