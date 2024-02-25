using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null; // 키 입력 발생 시, 실행되는 코드	

    public void OnUpdate()
    {
        if (Input.anyKey == false)  // 키 입력 미발생 , Action 실행하지 않음	
            return;
        if (KeyAction != null)  // 키 입력이 발생했고 KeyAction이 정의되어있을 시, Action 실행
            KeyAction.Invoke();
    }
}
