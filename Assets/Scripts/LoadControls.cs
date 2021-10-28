using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadControls : MonoBehaviour
{
    void Start()
    {
        Controls.UpKeyCode = KeyCode.W;
        Controls.DownKeyCode = KeyCode.S;
        Controls.LeftKeyCode = KeyCode.A;
        Controls.RightKeyCode = KeyCode.D;
        Controls.JumpKeyCode= KeyCode.Space;
        Controls.Attack1KeyCode = KeyCode.Mouse0;
    }
}
