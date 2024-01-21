using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_Death",menuName ="StateMachine/PlayerState/Death")]
public class PlayerState_Death : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerControl.SetVelocity(Vector2.zero);
        playerInformationProcessing.SetPlayerInvincibility(true);
    }
    public override void LogicUpdate()
    {
        if(isAnimationFinished)
        {
            playerInformationProcessing.PlayerDeath();
        }
    }
}
