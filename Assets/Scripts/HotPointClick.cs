using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ȵ����Ĺ���
/// </summary>
public class HotPointClick : MonoBehaviour
{
    public string mark;
    private void OnMouseDown()
    {
        if (UIManager.instance.isAdjustMode)
        {
            print("����ģʽ");
        }
        else
        {
            UIManager.instance.ChangeInfoPage(mark);
        }
    }
}
