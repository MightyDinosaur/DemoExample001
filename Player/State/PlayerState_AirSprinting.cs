using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_AirSprinting",menuName ="StateMachine/PlayerState/AirSprinting")]
public class PlayerState_AirSprinting : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerControl.SetUseGravity(false);
        playerInformationProcessing.SetPlayerInvincibility(true);
        playerInformationProcessing.UseSpringting();
        playerAudioManager.SprintingAudioClip();
    }
    public override void Exit()
    {
        playerControl.SetUseGravity(true);
        playerInformationProcessing.SetPlayerInvincibility(false);
    }
    public override void LogicUpdate()
    {
        if(playerInput.isStopSprinting || isAnimationFinished)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Fall)]);
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
