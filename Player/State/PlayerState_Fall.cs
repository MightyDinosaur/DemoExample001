using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField] private AnimationCurve animationCurve;
    // [SerializeField] private float velocityX;
    // [SerializeField] private float velocityY;
    public override void Enter()
    {
        base.Enter();
    }
    public override void LogicUpdate()
    {
        if(playerGroundDetection.isGround)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Idle)]);
        }
        if(playerInput.isJump&&playerControl.canAirJump)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_AirJump)]);
        }
        if(playerInput.isSprinting && playerInformationProcessing.isCanSprinting)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_AirSprinting)]);
        }
        if(playerInput.isAttack)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_AirAttack)]);
        }
        if(playerInput.isSkill && playerInformationProcessing.isCanSkill)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_AirSkill)]);
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
        playerControl.SetVelocityY(animationCurve.Evaluate(playerBasicData.GetPlayerJumpSpeed));
        playerControl.Move(playerBasicData.GetPlayerMoveSpeed);
    }
}
