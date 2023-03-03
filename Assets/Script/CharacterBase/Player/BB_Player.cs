using System;
using UnityEngine;

namespace NPC_Player
{
    [Serializable]
    public class BB_Player
    {
        public PlayerInputSystem input;
        public CharacterController playerController;
        public PlayerAnimController animController;
        public PlayerAttackManager attackManager;
        public Transform transform;

        public BB_Player(PlayerInputSystem input, CharacterController playerController, PlayerAnimController animController, PlayerAttackManager attackManager, Transform transform)
        {
            this.input = input;
            this.playerController = playerController;
            this.animController = animController;
            this.attackManager = attackManager;
            this.transform = transform;
        }
    }
}
