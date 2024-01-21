using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_AirJump",menuName ="StateMachine/PlayerState/AirJump")]
public class PlayerState_AirJump : PlayerState
{
    // [SerializeField] private float velocityX;
    // [SerializeField] private float velocityY;
    public override void Enter()
    {
        base.Enter();
        playerControl.SetVelocityY(playerBasicData.GetPlayerJumpSpeed);
        playerControl.canAirJump = false;
        playerAudioManager.JumpAudioClip();
    }
    public override void LogicUpdate()
    {
        if(my_Body2D.velocity.y<0 && !playerGroundDetection.isGround)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Fall)]);
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
        playerControl.Move(playerBasicData.GetPlayerMoveSpeed);
    }
}
