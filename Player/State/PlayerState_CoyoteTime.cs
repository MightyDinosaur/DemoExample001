using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "StateMachine/PlayerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] private float coyoteTime;
    public override void Enter()
    {
        base.Enter();
        playerControl.SetUseGravity(false);
        playerInformationProcessing.SetPlayerInvincibility(true);
    }
    public override void Exit()
    {
        playerControl.SetUseGravity(true);
        playerInformationProcessing.SetPlayerInvincibility(false);
    }
    public override void LogicUpdate()
    {
        if(playerInput.isJump)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Jump)]);
        }
        if(stateDuration > coyoteTime || !playerInput.isMove)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_Fall)]);
        }
    }
    public override void PhysicalUpdate()
    {
        playerControl.Move(playerBasicData.GetPlayerMoveSpeed);
    }
}
