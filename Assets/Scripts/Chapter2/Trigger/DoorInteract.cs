﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : InteractObject
{
    protected override void DoThis()
    {
        UIManager.Instance.Panel_Enable(Chapter2Manager.Instance.PasswordPanel);
    }
}
