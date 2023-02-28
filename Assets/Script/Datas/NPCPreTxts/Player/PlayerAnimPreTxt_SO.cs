
using UnityEditor;
using UnityEngine;

namespace SO_PlayerPreTxt
{
    
    [CreateAssetMenu(fileName = "PlayerPreTxt", menuName = "Player/PlayerPreTxt", order = 1)]
    public class PlayerAnimPreTxt_SO : ScriptableObject
    {
        public string[] preTxt;
        public string attackPreAnimTxt;
        public string rollPreAnimTxt;

        public string idleTxt;
        public string moveTxt;
        public string rollTxt;
        public string attackTxt;
        public string sprintTxt;
    }
}