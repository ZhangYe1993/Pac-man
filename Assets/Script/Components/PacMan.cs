using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PacMan : BaseGridMovement

    
{
    protected override void Update()
    {
        //public event Action CollectionEvent;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirection = new IntVector2(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirection = new IntVector2(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirection = new IntVector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirection = new IntVector2(1, 0);
        }
        base.Update();
    }


}
