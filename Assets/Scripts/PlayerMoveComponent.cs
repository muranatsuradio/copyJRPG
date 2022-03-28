using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : BaseMoveComponent
{
    protected override void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        base.Update();
    }
}
