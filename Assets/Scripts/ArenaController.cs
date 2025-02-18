using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class ArenaWallsScript : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject bottomWall;
    [SerializeField] private GameObject topWall;
    
    [SerializeField] private GameObject startCheckpoint;
    [FormerlySerializedAs("endCheckpoint")] [SerializeField] private GameObject finishCheckpoint;
    
    [SerializeField] [CanBeNull] private GameObject leftRamp;
    [SerializeField] [CanBeNull] private GameObject rightRamp;

    [SerializeField] private float wallHeight = 1;
    [SerializeField] private float wallWidth = 1;

    [SerializeField] private float planeWidth = 1;
    [SerializeField] private float planeDepth = 1;
    
    [SerializeField] private float rampAngle = 35;
    [SerializeField] private Vector3 rampsSize = new(8.7f, 1);
    // Start is called before the first frame update
    void Start()
    {
        TransformArena();
    }

    private void OnValidate()
    {
        TransformArena();
    }

    private void TransformArena()
    {
        Vector3 planeSize = ScalePlane();

        ScaleWalls(planeSize);
        PositionWalls(planeSize);

        if (leftRamp != null && rightRamp != null)
        {
            PositionRamps();
        }
        
        PositionCheckpoints(planeSize);
    }

    private void PositionCheckpoints(Vector3 planeSize)
    {
        startCheckpoint.transform.position = new Vector3(
            -planeSize.x / 2 + startCheckpoint.transform.localScale.x / 2, 
            0, 
            planeSize.z / 2 - startCheckpoint.transform.localScale.z / 2);
        
        finishCheckpoint.transform.position = new Vector3(
            planeSize.x / 2 - finishCheckpoint.transform.localScale.x / 2, 
            0, 
            -planeSize.z / 2 + finishCheckpoint.transform.localScale.z / 2);
    }

    private void PositionRamps()
    {
        rampsSize.x = leftWall.transform.localScale.x;

        float angleRad = Mathf.Deg2Rad * rampAngle;

        float halfRampLength = rampsSize.x / 2;
        float halfRampHeight = rampsSize.z / 2;

        float leftRampOffsetX = halfRampHeight * Mathf.Cos(angleRad);
        float leftRampOffsetY = halfRampHeight * Mathf.Sin(angleRad);

        leftRamp.transform.localScale = rampsSize;
        rightRamp.transform.localScale = rampsSize;

        leftRamp.transform.rotation = Quaternion.Euler(-rampAngle, 0, 0);
        rightRamp.transform.rotation = Quaternion.Euler(rampAngle, 0, 0);

        Vector3 leftWallEdges = new Vector3(
            x: leftWall.transform.position.x,
            y: leftWall.transform.position.y + leftWall.transform.localScale.y / 2,
            z: leftWall.transform.position.z + leftWall.transform.localScale.z / 2);

        leftRamp.transform.position = new Vector3(
            x: leftWallEdges.x,
            y: leftWallEdges.y + leftRampOffsetY,
            z: leftWallEdges.z + leftRampOffsetX - rightWall.transform.localScale.z);

        Vector3 rightWallEdges = new Vector3(
            x: rightWall.transform.position.x,
            y: rightWall.transform.position.y + rightWall.transform.localScale.y / 2,
            z: rightWall.transform.position.z - rightWall.transform.localScale.z / 2);

        rightRamp.transform.position = new Vector3(
            x: rightWallEdges.x,
            y: rightWallEdges.y + leftRampOffsetY,
            z: rightWallEdges.z - leftRampOffsetX + rightWall.transform.localScale.z);
        
        rightRamp.transform.Translate(new Vector3(0, -rightRamp.transform.localScale.y / 2,0), Space.Self);
        leftRamp.transform.Translate(new Vector3(0, -leftRamp.transform.localScale.y / 2,0), Space.Self);
    }

    
    private void ScaleWalls(Vector3 planeSize)
    {
        Vector3 verticalWallSize = new Vector3(planeSize.x + wallWidth * 2, wallHeight, 1);
        Vector3 horizontalWallSize = new Vector3(planeSize.z, wallHeight, wallWidth);

        
        leftWall.transform.localScale = verticalWallSize;
        rightWall.transform.localScale = verticalWallSize;
        topWall.transform.localScale = horizontalWallSize;
        bottomWall.transform.localScale = horizontalWallSize;
    }

    private Vector3 ScalePlane()
    {
        plane.transform.localScale = new Vector3(planeDepth, 1, planeWidth);
        Renderer planeRenderer = plane.GetComponent<Renderer>();
        return planeRenderer.bounds.size;
    }

    private void PositionWalls(Vector3 planeSize)
    {
        float wallYPosition = 0;

        
        bottomWall.transform.position = new Vector3(-(planeSize.x / 2 + wallWidth / 2), wallYPosition, 0);
        topWall.transform.position = new Vector3(planeSize.x / 2 + wallWidth / 2, wallYPosition, 0);
        leftWall.transform.position = new Vector3(0, wallYPosition, planeSize.z / 2 + wallWidth / 2);
        rightWall.transform.position = new Vector3(0, wallYPosition, -(planeSize.z / 2 + wallWidth / 2));
        
        topWall.transform.rotation = Quaternion.Euler(0, 90, 0);
        bottomWall.transform.rotation = Quaternion.Euler(0, -90, 0);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
