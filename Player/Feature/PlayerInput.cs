using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputControl inputActions;
    Vector2 axes=>inputActions.GamePlay.Move.ReadValue<Vector2>();
    public float axesX=> axes.x;
    public bool isMove=>axesX != 0f;
    /***********跳跃***********/
    public bool isJump=>inputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool isStopJump=>inputActions.GamePlay.Jump.WasReleasedThisFrame();
    /***********攻击***********/
    public bool isAttack=>inputActions.GamePlay.Attack.WasPressedThisFrame();
    //public bool isStopAttack=>inputActions.GamePlay.Attack.WasReleasedThisFrame();
    /***********重击***********/
    public bool isThump=>inputActions.GamePlay.Thump.WasPressedThisFrame();
    public bool isStopThump=>inputActions.GamePlay.Thump.WasReleasedThisFrame();
    /***********技能***********/
    public bool isSkill=>inputActions.GamePlay.Skill.WasPressedThisFrame();
    // public bool isStopSkill=>inputActions.GamePlay.Skill.WasReleasedThisFrame();
    /***********冲刺***********/
    public bool isSprinting=>inputActions.GamePlay.Sprinting.WasPressedThisFrame();
    public bool isStopSprinting=>inputActions.GamePlay.Sprinting.WasReleasedThisFrame();
    void Awake()
    {
        inputActions = new PlayerInputControl();
    }
    public void EnableInputSystem()
    {
        inputActions.GamePlay.Enable();
    }
}
