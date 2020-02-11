using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public Sprite playerSprite;

    public int playerHighestScore;
    public int playerKillNum;
}
