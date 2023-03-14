using FinitStateMachine;
using System;
using UnityEngine;

namespace NPC_Player
{
    [Serializable]
    public class BB_Player:BlackBoard
    {
        public Transform transform;
        public PlayerInputSystem input;
        public CharacterController playerController;
        public PlayerAnimController animController;
        public PlayerAttackManager attackManager;
        public float moveSpeed;
        public int comboIndex;

        //public BB_Player(Transform transform,PlayerInputSystem input, CharacterController playerController, PlayerAnimController animController, PlayerAttackManager attackManager, float moveSpeed)
        //{
        //    this.transform = transform;
        //    this.input = input;
        //    this.playerController = playerController;
        //    this.animController = animController;
        //    this.attackManager = attackManager;
        //    this.moveSpeed = moveSpeed;
        //}
    }
}
