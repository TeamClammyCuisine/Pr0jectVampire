using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardKey
{
    private readonly Array _keyCodes = Enum.GetValues(typeof(KeyCode));
    
    public IEnumerator Pressed(Text buttonPressed, KeyEnum keyToUpdate)
    {
  

        while (!Input.anyKeyDown)
        {
            Debug.Log("waiting for key press");
            yield return null;
        }


        foreach (KeyCode keycode in _keyCodes)
        {
            if (Input.GetKeyDown(keycode))
            {
                buttonPressed.text = keycode.ToString();
                Controls.UpdateControl(keyToUpdate, keycode);
            }
        }
        
        Debug.Log($"controls  {Controls.UpKeyCode}");
        yield return null;
    }
    
    public IEnumerator Pressed(Text buttonPressed, KeyCode keyToUpdate)
    {
  

        while (!Input.anyKeyDown)
        {
            Debug.Log("waiting for key press");
            yield return null;
        }


        foreach (KeyCode keycode in _keyCodes)
        {
            if (Input.GetKeyDown(keycode))
            {
                buttonPressed.text = keycode.ToString();
                keyToUpdate = keycode;
            }
        }
        
        Debug.Log($"controls  {Controls.UpKeyCode}");
        yield return null;
    }
}
