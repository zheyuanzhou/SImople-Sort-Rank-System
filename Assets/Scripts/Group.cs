using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Group : MonoBehaviour
{
    public PlayerData playerData;//Each Slot have their own player's Information stored on each PlayerData

    public Image playerImage;
    public Text playerNameText;
    public Text playerScoreText;
    public Text playerKillNumText;

    private void Start()
    {
        UpdateGroup();
    }

    //MARKER assign PlayerData property to the UI Part
    public void UpdateGroup()
    {
        playerImage.sprite = playerData.playerSprite;
        playerNameText.text = playerData.playerName;
        playerScoreText.text = playerData.playerHighestScore.ToString();
        playerKillNumText.text = playerData.playerKillNum.ToString();
    }

    //These two functions will be attached on the event Trigger Component
    public void MouseEnter()
    {
        LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setEaseShake();
    }

    public void MouseExit()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.5f);
    }

}
