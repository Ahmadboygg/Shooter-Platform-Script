using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool moveRight
    {
        get { return Input.GetKey(KeyCode.RightArrow);}
    }
    public bool moveLeft
    {
        get { return Input.GetKey(KeyCode.LeftArrow);}
    }
    public bool jump
    {
        get { return Input.GetKeyDown(KeyCode.UpArrow);}
    }
    public bool crouch
    {
        get { return Input.GetKey(KeyCode.DownArrow);}
    }
    public bool shoot
    {
        get { return Input.GetKeyDown(KeyCode.D);}
    }

    

    

    
}
