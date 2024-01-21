using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_Thump",menuName ="StateMachine/PlayerState/Thump")]
public class PlayerState_Thump : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerAttack.SetColliderEnable(true);
        playerAttack.IsThump(true);
        playerInformationProcessing.SetPlayerInvincibility(true);
        playerInformationProcessing.UseThump();
    }
    public override void Exit()
    {
        playerAttack.SetColliderEnable(false);
        playerAttack.IsThump(false);
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
