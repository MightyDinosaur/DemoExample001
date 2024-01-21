using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    /*************************状态信息***************************/
    //PlayerState资源文件
    [SerializeField] PlayerState[] states;
    Animator animator;                            //获取动画组件
    Rigidbody2D my_Body2D;                        //获取刚体组件
    PlayerInput playerInput;
    PlayerControl playerControl;
    PlayerGroundDetection playerGroundDetection;
    [SerializeField] PlayerBasicData playerBasicData;
    PlayerAttack playerAttack;
    PlayerSkill playerSkill;
    PlayerInformationProcessing playerInformationProcessing;
    PlayerAudioManager playerAudioManager;
    void Awake()
    {
        /*************************状态信息组件***************************/
        stateTable = new Dictionary<System.Type, IState>(states.Length);            //初始化字典
        animator = GetComponent<Animator>();                                        //获取动画组件
        my_Body2D = GetComponent<Rigidbody2D>();                                    //获取刚体组件
        playerInput = GetComponent<PlayerInput>();
        playerControl = GetComponent<PlayerControl>();
        playerGroundDetection= GetComponentInChildren<PlayerGroundDetection>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
        playerSkill = GetComponentInChildren<PlayerSkill>();
        playerInformationProcessing = GetComponent<PlayerInformationProcessing>();
        playerAudioManager = GetComponent<PlayerAudioManager>();
        //迭代器循环获取状态
        foreach (PlayerState state in states)
        {
            state.Initiatize(animator, my_Body2D, playerInput, playerControl,
            playerGroundDetection, playerBasicData, playerAttack, playerSkill,
            playerInformationProcessing, playerAudioManager, this);//将动画组件，刚体组件以及PlayerStateMachine传入进去
            //状态存入字典
            stateTable.Add(state.GetType(), state);
        }
    }
    private void Start()
    {//在开始时执行Idle，进入Idle状态
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
