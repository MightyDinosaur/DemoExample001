using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerControl.canAirJump = true;
    }
    public override void LogicUpdate()
    {
        if(playerInput.isMove)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Run)]);
        }
        if(playerInput.isSprinting && playerInformationProcessing.isCanSprinting)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Sprinting)]);
        }
        if(playerInput.isJump)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Jump)]);
        }
        if(my_Body2D.velocity.y<0 && !playerGroundDetection.isGround)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Fall)]);
        }
        if(playerInput.isAttack)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Attack)]);
        }
        if(playerInput.isThump && playerInformationProcessing.isCanThump)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Thump)]);
        }
        if(playerInput.isSkill && playerInformationProcessing.isCanSkill)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Skill)]);
        }
        if(playerInformationProcessing.isHurt)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Hurt)]);
        }
        if(playerInformationProcessing.isDeath)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Death)]);
        }
    }
    public override void PhysicalUpdate()
    {
        playerControl.SetVelocity(Vector2.zero);
    }
}
