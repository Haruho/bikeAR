using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 热点点击的功能
/// </summary>
public class HotPointClick : MonoBehaviour
{
    public string mark;
    private void OnMouseDown()
    {
        if (UIManager.instance.isAdjustMode)
        {
            print("调整模式");
        }
        else
        {
            UIManager.instance.ChangeInfoPage(mark);
        }
    }
}
