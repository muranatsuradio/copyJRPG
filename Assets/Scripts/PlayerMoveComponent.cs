using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : BaseMoveComponent
{
    protected override void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        
        if (HorizontalInput > 0)
        {
            VerticalInput = 0;
        }
        else if (VerticalInput > 0)
        {
            HorizontalInput = 0;
        }

        base.Update();
    }
}