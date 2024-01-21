using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_Sprinting",menuName ="StateMachine/PlayerState/Sprinting")]
public class PlayerState_Sprinting : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerInformationProcessing.SetPlayerInvincibility(true);
        playerInformationProcessing.UseSpringting();
        playerAudioManager.SprintingAudioClip();
    }
    public override void Exit()
    {
        playerInformationProcessing.SetPlayerInvincibility(false);
    }
    public override void LogicUpdate()
    {
        if(playerInput.isStopSprinting || isAnimationFinished)
        {
            if(playerInput.isMove)
            {
                stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Run)]);
            }
            if(!playerGroundDetection.isGround&&my_Body2D.velocity.y<0)
            {
                stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Fall)]);
            }
            if(playerGroundDetection.isGround)
            {
                stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Idle)]);
            }
        }
    }
    public override void PhysicalUpdate()
    {
        playerControl.Sprinting(playerBasicData.GetPlayerSprintingSpeed);
    }
}
