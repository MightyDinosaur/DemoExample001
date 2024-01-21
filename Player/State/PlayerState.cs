using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    /********变量*********/
    float stateStartTime;
    [SerializeField] private string stateName;
    [SerializeField,Range(0,1)] private float transitionDuration = 0.1f;
    protected int stateHash;
    /*************相关组件*************/
    protected Rigidbody2D my_Body2D;                  //刚体组件，用于获取物体刚体属性
    protected Animator animator;                      //动画组件，用来播放动画
    protected PlayerInput playerInput;
    protected PlayerControl playerControl;
    protected PlayerGroundDetection playerGroundDetection;
    protected PlayerBasicData playerBasicData;
    protected PlayerAttack playerAttack;
    protected PlayerSkill playerSkill;
    protected PlayerInformationProcessing playerInformationProcessing;
    protected PlayerAudioManager playerAudioManager;
    protected PlayerStateMachine stateMachine;        //PlayerStateMachine，玩家状态机类，执行状态间的切换
    /*************相关信息*************/
    protected bool isAnimationFinished => stateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    protected float stateDuration => Time.time - stateStartTime;
    /*******组件传递*******/
    public void Initiatize(Animator animator, Rigidbody2D my_Body2D, PlayerInput playerInput,
    PlayerControl playerControl, PlayerGroundDetection playerGroundDetection, PlayerBasicData playerBasicData,
    PlayerAttack playerAttack, PlayerSkill playerSkill, PlayerInformationProcessing playerInformationProcessing,
    PlayerAudioManager playerAudioManager,
    PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.my_Body2D = my_Body2D;
        this.playerInput = playerInput;
        this.playerControl = playerControl;
        this.playerGroundDetection = playerGroundDetection;
        this.playerBasicData = playerBasicData;
        this.playerAttack = playerAttack;
        this.playerSkill = playerSkill;
        this.playerInformationProcessing = playerInformationProcessing;
        this.playerAudioManager = playerAudioManager;
        this.stateMachine = stateMachine;
    }
    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }
    public virtual void Enter()
    {
        animator.CrossFade(stateHash,transitionDuration);
        stateStartTime = Time.time;
    }

    public virtual void Exit(){}

    public virtual void LogicUpdate(){}

    public virtual void PhysicalUpdate(){}
}
