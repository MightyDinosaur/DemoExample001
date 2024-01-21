using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_Attack",menuName ="StateMachine/PlayerState/Attack")]
public class PlayerState_Attack : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerAttack.SetColliderEnable(true);
        playerInformationProcessing.SetPlayerInvincibility(true);
    }
    public override void Exit()
    {
        playerAttack.SetColliderEnable(false);
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
        playerControl.Move(playerBasicData.GetPlayerMoveSpeed);
    }
}
