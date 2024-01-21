using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_Skill",menuName ="StateMachine/PlayerState/Skill")]
public class PlayerState_Skill : PlayerState
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
        playerControl.SetVelocity(Vector2.zero);
    }
}
