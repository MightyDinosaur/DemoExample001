using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    //[SerializeField] private float velocityX;
    public override void Enter()
    {
        base.Enter();
        playerAudioManager.RunAudioClip();
    }
    public override void Exit()
    {
        playerAudioManager.RunAudioClipClose();
    }
    public override void LogicUpdate()
    {
        if(!playerInput.isMove)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Idle)]);
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
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_CoyoteTime)]);
        }
        if(playerInput.isAttack)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Attack)]);
        }
        if(playerInput.isThump)
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
        playerControl.Move(playerBasicData.GetPlayerMoveSpeed);
    }
}
