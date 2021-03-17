using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGridMovement : BaseGridObject
{
    public float movementSpeed;
    protected IntVector2 currentInputDirection;
    protected IntVector2 previousInputDirection;
    protected IntVector2 targetGridPosition;
    protected float progressToTarget = 1f;



    private void Start()
    {
        targetGridPosition = GridPosition;
    }

    protected virtual void Update()
    {
        //Check if we're arrived to the target position
        if (transform.position == targetGridPosition.ToVector3())
        {
            progressToTarget = 0f;
            GridPosition = targetGridPosition;
        }
        //If we update our grid position,and current input is valid
        
        if (GridPosition == targetGridPosition
            && LevelGeneratorSystem.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirection.y),
            Mathf.Abs(targetGridPosition.x + currentInputDirection.x)] != 1) //&& LevelGeneratorSystem.Grid[targetGridPosition.x, -targetGridPosition.y] != 1
            
        {
            targetGridPosition += currentInputDirection;
        }

        else if (GridPosition == targetGridPosition 
            && LevelGeneratorSystem.Grid[Mathf.Abs(targetGridPosition.y + previousInputDirection.y),
            Mathf.Abs(targetGridPosition.x + previousInputDirection.x)] != 1
            )
        {
            targetGridPosition += previousInputDirection;
        }

        if (GridPosition == targetGridPosition) return;

        progressToTarget += movementSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(GridPosition.ToVector3(), targetGridPosition.ToVector3(), progressToTarget);
    }
}

public static class ExtensionMethods
{
    public static Vector3 ToVector3(this IntVector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y);
    }
}