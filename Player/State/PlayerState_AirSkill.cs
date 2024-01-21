using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_AirSkill",menuName ="StateMachine/PlayerState/AirSkill")]
public class PlayerState_AirSkill : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerSkill.UsePlayerSkill();
        playerInformationProcessing.SetPlayerInvincibility(true);
        playerInformationProcessing.UseSkill();
        playerAudioManager.SkillAudioClip();
    }
    public override void Exit()
    {
        playerInformationProcessing.SetPlayerInvincibility(false);
    }
    public override void LogicUpdate()
    {
        if(isAnimationFinished)
        {
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
        playerControl.SetVelocity(new Vector2(0,my_Body2D.velocity.y));
    }
}
