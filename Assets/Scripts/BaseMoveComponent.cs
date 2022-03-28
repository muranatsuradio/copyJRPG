using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoveComponent : MonoBehaviour
{
    public float VerticalInput;
    public float HorizontalInput;
    public float PreviousVerticalInput;
    public float PreviousHorizontalInput;
    public float Speed;

    public Collider2D HitInfo;
    
    private Animator _animator;
    private static readonly int HorizontalInputName = Animator.StringToHash("HorizontalInput");
    private static readonly int VerticalInputName = Animator.StringToHash("VerticalInput");
    private static readonly int LastHorizontalInput = Animator.StringToHash("LastHorizontalInput");
    private static readonly int LastVerticalInput = Animator.StringToHash("LastVerticalInput");
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        _animator.SetFloat(HorizontalInputName, HorizontalInput);
        _animator.SetFloat(VerticalInputName, VerticalInput);
        _animator.SetFloat(LastHorizontalInput, PreviousHorizontalInput);
        _animator.SetFloat(LastVerticalInput, PreviousVerticalInput);
        _animator.SetFloat(MoveSpeed, Mathf.Abs(HorizontalInput + VerticalInput));

        if (HorizontalInput == 0 && VerticalInput == 0) return;

        if (Mathf.Abs(HorizontalInput) > Mathf.Abs(VerticalInput))
        {
            PreviousVerticalInput = 0;
            PreviousHorizontalInput = HorizontalInput;
        }
        else
        {
            PreviousHorizontalInput = 0;
            PreviousVerticalInput = VerticalInput;
        }
        
        var origin = new Vector2(transform.position.x, transform.position.y);
        var end = new Vector2(transform.position.x + HorizontalInput, transform.position.y + VerticalInput);
        var direction = end - origin;
        Debug.DrawRay(origin,direction);
        var ray = Physics2D.Raycast(origin, direction, 0.2f);
        
        if (ray)
        {
            HitInfo = ray.collider;
            return;
        }

        transform.position +=
            new Vector3(HorizontalInput * Time.deltaTime * Speed, VerticalInput * Time.deltaTime * Speed);
    }
}