using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// AR模式下对虚拟物体的位置进行统一的调整
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class ARManualAdjust : MonoBehaviour
{
    public string _name;
    //UI界面
    GameObject UIPanle;
    //输入框
    InputField xpos,ypos,zpos;
    InputField xrot,yrot,zrot;
    InputField scl;
    //confirm会调用save 并且关闭UI面板   apply会将设置好的值更新不存储
    Button confirm, apply;

    bool isCurrentSelect;
    // Start is called before the first frame update
    void Start()
    {
        UIPanle = GameObject.Find("Canvas").transform.Find("AdjustPanle").gameObject;
        if (_name == null)
        {
            _name = transform.name;
        }
        else
        {
            return;
        }
        xpos = UIPanle.transform.Find("xpos").GetComponent<InputField>();
        ypos = UIPanle.transform.Find("ypos").GetComponent<InputField>();
        zpos = UIPanle.transform.Find("zpos").GetComponent<InputField>();

        xrot = UIPanle.transform.Find("xrot").GetComponent<InputField>();
        yrot = UIPanle.transform.Find("yrot").GetComponent<InputField>();
        zrot = UIPanle.transform.Find("zrot").GetComponent<InputField>();

        scl = UIPanle.transform.Find("scl").GetComponent<InputField>();
        //按钮添加方法
        confirm.onClick.AddListener(ConfirmButtonClick);
        apply.onClick.AddListener(ApplyButtonClick);
        Debug.Log(UIPanle.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        //将当前点击的物体transform信息赋值给UI
        xpos.text = transform.localPosition.x.ToString();
        ypos.text = transform.localPosition.y.ToString();
        zpos.text = transform.localPosition.z.ToString();

        xrot.text = transform.localEulerAngles.x.ToString();
        yrot.text = transform.localEulerAngles.y.ToString();
        zrot.text = transform.localEulerAngles.z.ToString();

        scl.text = transform.localScale.x.ToString();

    }
    public void ConfirmButtonClick()
    {
        //调用存储函数
        SaveData(_name,transform.localPosition,transform.localEulerAngles,transform.localScale.x);
        UIPanle.SetActive(false);
    }
    public void ApplyButtonClick()
    {
        //pos
        transform.localPosition = new Vector3(float.Parse(xpos.text), float.Parse(ypos.text), float.Parse(zpos.text));
        //rot
        transform.localEulerAngles = new Vector3(float.Parse(xrot.text), float.Parse(yrot.text), float.Parse(zrot.text));
        //scl
        transform.localScale = new Vector3(float.Parse(scl.text), float.Parse(scl.text), float.Parse(scl.text));
    }

    private bool SaveData(string objName,Vector3 modifyPos, Vector3 modifyRot, float scl)
    {
        try{
            //pos
            PlayerPrefs.SetFloat(objName + "_xpos", modifyPos.x);
            PlayerPrefs.SetFloat(objName + "_ypos", modifyPos.y);
            PlayerPrefs.SetFloat(objName + "_zpos", modifyPos.z);
            //rot
            PlayerPrefs.SetFloat(objName + "_xrot", modifyRot.x);
            PlayerPrefs.SetFloat(objName + "_yrot", modifyRot.y);
            PlayerPrefs.SetFloat(objName + "_zrot", modifyRot.z);
            //scale
            PlayerPrefs.SetFloat(objName + "_scl", scl);
        }
        catch(Exception e)
        {
            Debug.Log("Save Fail :" + e.Message);
            return false;
        }
        return true;
    }
}
