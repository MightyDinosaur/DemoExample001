using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    [Header("变量")]
    private Vector2 originalVelocity;                 //保存速度
    public bool canAirJump{get;set;} = true;          //玩家是否可以二段跳
    [Header("组件")]
    private PlayerInputControl playerInputControl;
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private void Awake()
    {
        playerInputControl = new PlayerInputControl();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void Start()
    {
        //输入控制类激活
        playerInput.EnableInputSystem();
    }
    private void OnEnable()
    {
        //玩家新输入系统控制器激活
        playerInputControl.Enable();
    }
    private void OnDisable()
    {
        playerInputControl.Disable();
    }
    /// <summary>
    /// 玩家移动,由状态机调用
    /// </summary>
    /// <param name="velocityX">移动速度</param>
    public void Move(float velocityX)
    {
        if(playerInput.isMove)
        {
            /*****执行玩家转向*****/
            int flipTag = (int)transform.localScale.x;   //获取当前Scale
            if (playerInput.axesX < 0)
            {
                flipTag = -1;      //向左
            }
            else if (playerInput.axesX > 0)
            {
                flipTag = 1;       //向右
            }
            //玩家转向
            transform.localScale = new Vector3(flipTag,1,1);
        }
        SetVelocityX(velocityX*playerInput.axesX);
    }
    /// <summary>
    /// 玩家冲刺
    /// </summary>
    /// <param name="velocityX">冲刺速度</param>
    public void Sprinting(float velocityX)
    {
        int flipTag = (int)transform.localScale.x;   //获取当前Scale
        SetVelocityX(velocityX*flipTag);
    }
    //设置速度
    public void SetVelocity(Vector2 moveValue)
    {
        rb.velocity = moveValue;
    }
    //设置X轴速度
    private void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX,rb.velocity.y);
    }
    //设置Y轴速度
    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x,velocityY);
    }
    /// <summary>
    /// 轴锁定,玩家冲刺时,Y轴锁定,由状态机调用
    /// </summary>
    /// <param name="value"></param>
    public void SetUseGravity(bool value)
    {
        originalVelocity = rb.velocity;
        if(value)
        {
            rb.constraints |= RigidbodyConstraints2D.FreezeRotation;
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            rb.velocity = new Vector2(rb.velocity.x, originalVelocity.y);
        }
        else
        {
            rb.constraints |= RigidbodyConstraints2D.FreezeRotation;
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
        }
    }
    /// <summary>
    /// 击退,由状态机调用
    /// </summary>
    /// <param name="vector2">击退方向</param>
    /// <param name="repelDistance">击退距离</param>
    public void TakeRepel(Vector2 vector2,float repelDistance)
    {
        rb.AddForce(vector2*repelDistance,ForceMode2D.Impulse);
    }
}
