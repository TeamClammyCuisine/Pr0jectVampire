using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChangeControls : MonoBehaviour
{
    public Text UpButtonText;
    public Text DownButtonText;
    public Text LeftButtonText;
    public Text RightButtonText;
    public Text JumpButtonText;
    public Text Attack1ButtonText;
    private const string _defaultButtonText = "Press Key";

    public void Start()
    {
        UpButtonText.text = Controls.UpKeyCode.ToString();
        DownButtonText.text = Controls.DownKeyCode.ToString();
        LeftButtonText.text = Controls.LeftKeyCode.ToString();
        RightButtonText.text = Controls.RightKeyCode.ToString();
        JumpButtonText.text = Controls.JumpKeyCode.ToString();
        Attack1ButtonText.text = Controls.Attack1KeyCode.ToString();
    }

    public void ChangeUpKey()
    {
        UpButtonText.text = _defaultButtonText;
        
        var key = new KeyBoardKey();
        StartCoroutine(key.Pressed(UpButtonText, KeyEnum.Up));
    }
    
    public void ChangeDownKey()
    {
        DownButtonText.text = _defaultButtonText;
        
        var key = new KeyBoardKey();
        StartCoroutine(key.Pressed(DownButtonText, KeyEnum.Jump));
    }
    
    public void ChangeLeftKey()
    {
        LeftButtonText.text = _defaultButtonText;
        
        var key = new KeyBoardKey();
        StartCoroutine(key.Pressed(LeftButtonText, KeyEnum.Left));
    }
    
    public void ChangeRightKey()
    {
        RightButtonText.text = _defaultButtonText;
        
        var key = new KeyBoardKey();
        StartCoroutine(key.Pressed(RightButtonText, KeyEnum.Right));
    }
    
    public void ChangeJumpKey()
    {
        JumpButtonText.text = _defaultButtonText;
        
        var key = new KeyBoardKey();
        StartCoroutine(key.Pressed(JumpButtonText,KeyEnum.Jump));
    }

    public void ChangeAttact1Key()
    {
        Attack1ButtonText.text = _defaultButtonText;
        
        var key = new KeyBoardKey();
        StartCoroutine(key.Pressed(Attack1ButtonText, KeyEnum.Attact1));
    }

}