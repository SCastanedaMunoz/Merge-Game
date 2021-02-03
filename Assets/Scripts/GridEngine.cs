using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEngine : MonoBehaviour {
    public int size = 10;
    public float inBetweenOffSet = 6f;
    public float heightOffset = -3f;
    private const float MidPointOffSet = 0.5f;
    public GameObject groundObject;

    [ContextMenu("Generate Grid")]
    public void GenerateGrid() {
        var gridHolder = new GameObject("GridHolder");

        gridHolder.transform.position = Vector3.zero;
        
        var midWidth = size / 2f;
        var midHeight = size / 2f;

        for (var i = -midHeight; i < midWidth; i++)
        {
            for (var j = -midWidth; j < midHeight; j++)
            {
                var position = new Vector3(i + MidPointOffSet , 0, j + MidPointOffSet) * inBetweenOffSet;
                var item = Instantiate(groundObject, position, Quaternion.identity, gridHolder.transform);
                item.transform.SetParent(gridHolder.transform);
            }
        }
        
        gridHolder.transform.position = new Vector3(0, heightOffset, 0);
    }

    private void Start() {
        GenerateGrid();
    }
}