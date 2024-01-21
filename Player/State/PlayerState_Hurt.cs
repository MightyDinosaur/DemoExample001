using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_Hurt",menuName ="StateMachine/PlayerState/Hurt")]
public class PlayerState_Hurt : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerControl.TakeRepel(playerInformationProcessing.playerRepelVector,playerBasicData.GetPlayerRepelDistance);
    }
    public override void Exit()
    {
        playerInformationProcessing.isHurt = false;
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
}
