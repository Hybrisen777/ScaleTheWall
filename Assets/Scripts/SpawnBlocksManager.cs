using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBlocksManager : MonoBehaviour
{
    public event Action blockCountChanged;

    [SerializeField]
    private GameObject blockToSpawn;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Vector3 hitPoint;
    [SerializeField]
    private float blockOffsetMultiplier = 0.1f;
    [SerializeField]
    private float blockScaleMultiplier = 0.1f;
    [SerializeField]
    private int blockLimit = 5;
    [SerializeField]
    private int blockCount = 0;
    [SerializeField]
    private GameManager gameManagerSubjectToObserve;
    [SerializeField]
    private bool isGameOn = false;

    public int BlockCount
    {
        get { return blockCount; }
        set 
        { 
            blockCount = value;
            blockCountChanged?.Invoke();
        }
    }

    public int BlockLimit
    {
        get { return blockLimit; }
    }

    private void Awake()
    {
        gameManagerSubjectToObserve.PlayClicked += OnPlayClicked;
        gameManagerSubjectToObserve.MenuButtonClicked += OnMenuClicked;
    }
    void Update()
    {
        bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
        if (cam != null && isGameOn && !isOverUI)
        {
            Ray rayLeft = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitLeft;

            //if (Physics.Raycast(rayLeft, out hitLeft, 100))
            //{
            //    hitPoint = hitLeft.point;
            //}

            //Debug.DrawLine(rayLeft.origin, hitPoint, Color.red);


            if (Input.GetMouseButtonDown(0))
            {
                if(BlockCount < BlockLimit) 
                {
                    int blockLayerMask = 1 << 8;
                    int spawnedObjectsLayerMask = 1 << 7;
                    int groudLayerMask = 1 << 6;
                    if (Physics.Raycast(rayLeft, out hitLeft, 100, blockLayerMask))
                    {
                        return;
                    }
                    else if(Physics.Raycast(rayLeft, out hitLeft, 100, spawnedObjectsLayerMask))
                    {
                        OnSpawnBlock(rayLeft, hitLeft);
                    }
                    else if(Physics.Raycast(rayLeft, out hitLeft, 100, groudLayerMask))
                    {
                        OnSpawnBlock(rayLeft, hitLeft);
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray rayRight = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitRight;
                int spawnedObjectsLayerMask = 1 << 7;

                if (Physics.Raycast(rayRight, out hitRight, 100, spawnedObjectsLayerMask))
                {
                    if(hitRight.transform.gameObject.layer == 7)
                    {
                        Destroy(hitRight.transform.gameObject);
                        BlockCount -= 1;
                    }
                }
            }
        }
    }

    private void OnSpawnBlock(Ray rayLeft, RaycastHit hitLeft)
    {
        hitPoint = hitLeft.point;
        Vector3 cursorPos = hitPoint + Vector3.up * Vector3.Distance(hitPoint, rayLeft.origin) * blockOffsetMultiplier;
        var newBlock = Instantiate(blockToSpawn, cursorPos, Quaternion.identity);
        newBlock.transform.localScale = Vector3.one * Vector3.Distance(hitPoint, rayLeft.origin) * blockScaleMultiplier;
        BlockCount += 1;
    }
    public void OnPlayClicked()
    {
        isGameOn = true;
    }

    private void OnMenuClicked()
    {
        isGameOn = false;
    }
    private void OnDestroy()
    {
        if (gameManagerSubjectToObserve != null)
        {
            gameManagerSubjectToObserve.PlayClicked -= OnPlayClicked;
            gameManagerSubjectToObserve.PlayClicked -= OnMenuClicked;
        }
    }

}
