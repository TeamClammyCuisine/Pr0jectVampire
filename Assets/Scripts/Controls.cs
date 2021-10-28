using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Controls
{
    public static KeyCode UpKeyCode { get;  set; } 
    public static KeyCode DownKeyCode { get;  set; }
    public static KeyCode LeftKeyCode { get;  set; }
    public static KeyCode RightKeyCode { get;  set; } 
    public static KeyCode JumpKeyCode { get;  set; } 
    public static KeyCode Attack1KeyCode { get;  set; }

	public static void UpdateControl(KeyEnum key, KeyCode code)
	{
		switch(key){
			case KeyEnum.Up:
				UpKeyCode = code;
				break;
			case KeyEnum.Down:
				DownKeyCode = code;
				break;
			case KeyEnum.Left:
				LeftKeyCode = code;
				break;
			case KeyEnum.Right:
				RightKeyCode = code;
				break;
			case KeyEnum.Jump:
				JumpKeyCode = code;
				break;
			case KeyEnum.Attact1:
				Attack1KeyCode = code;
				break;
		}
	}
}
