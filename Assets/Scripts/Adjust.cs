using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adjust : MonoBehaviour
{
    //public Transform temp;
    public GameObject adjustPanle;
    public Text trackedName;
    public InputField posx, posy, posz;
    public InputField rotx, roty, rotz;
    //public InputField sclx, scly, sclz;
    public InputField sclx;
    public Button fresh;

    public Material transparentMate;

    Transform tracked;
    public static Adjust instance;
    private void Awake()
    {
        instance = this;
        //PlayerPrefs.DeleteAll();
    }
    public void InitAdjustPanle()
    {
        adjustPanle.SetActive(true);
        fresh.gameObject.SetActive(true);
    }
    public void PanleText()
    {
        Transform trackedObj = ARModelManager.instance.GetActivePrefab().transform.GetChild(0);
        tracked = trackedObj;
        posx.text = trackedObj.localPosition.x.ToString();
        posy.text = trackedObj.localPosition.y.ToString();
        posz.text = trackedObj.localPosition.z.ToString();

        rotx.text = trackedObj.localEulerAngles.x.ToString();
        roty.text = trackedObj.localEulerAngles.y.ToString();
        rotz.text = trackedObj.localEulerAngles.z.ToString();

        sclx.text = trackedObj.localScale.x.ToString();
    }
    public void SetPanleTextNumber(Transform obj)
    {
        posx.text = obj.localPosition.x.ToString();
        posy.text = obj.localPosition.y.ToString();
        posz.text = obj.localPosition.z.ToString();

        rotx.text = obj.localEulerAngles.x.ToString();
        roty.text = obj.localEulerAngles.y.ToString();
        rotz.text = obj.localEulerAngles.z.ToString();

        sclx.text = obj.localScale.x.ToString();

    }
    public void SetTransparent()
    {
        tracked.gameObject.SetActive(false);
        tracked.parent.GetChild(1).gameObject.SetActive(true);
    }
    public void SetInfo()
    {
        //set
        tracked.parent.GetChild(1).localPosition = new Vector3(float.Parse(posx.text), float.Parse(posy.text), float.Parse(posz.text));
        tracked.parent.GetChild(1).localEulerAngles = new Vector3(float.Parse(rotx.text), float.Parse(roty.text), float.Parse(rotz.text));
        tracked.parent.GetChild(1).parent.localScale = new Vector3(float.Parse(sclx.text), float.Parse(sclx.text), float.Parse(sclx.text));
        tracked.localPosition = tracked.parent.GetChild(1).localPosition;
        tracked.localEulerAngles = tracked.parent.GetChild(1).localEulerAngles;
        tracked.localScale = tracked.parent.GetChild(1).localScale;

        Debug.Log("pos:"+ float.Parse(posx.text) + " " +float.Parse(posy.text)+ " " +float.Parse(posz.text));
        Debug.Log("rot:" + float.Parse(rotx.text) + " " + float.Parse(roty.text) + " " + float.Parse(rotz.text));
        Debug.Log("scale:" + float.Parse(sclx.text));

        //应用调整好的数值
        Vector3 pos = new Vector3(float.Parse(posx.text), float.Parse(posy.text), float.Parse(posz.text));
        Vector3 rot = new Vector3(float.Parse(rotx.text), float.Parse(roty.text), float.Parse(rotz.text));
        Vector3 scale = new Vector3(float.Parse(sclx.text), float.Parse(sclx.text), float.Parse(sclx.text));
        ARModelManager.instance.AcceptValue(pos, rot, scale);
    }
    public void SaveDataInfo()
    {

        //存储调整好的数值
        PlayerPrefs.SetString("savemark", "true");

        PlayerPrefs.SetFloat("posx", float.Parse(posx.text));
        PlayerPrefs.SetFloat("posy", float.Parse(posy.text));
        PlayerPrefs.SetFloat("posz", float.Parse(posz.text));

        PlayerPrefs.SetFloat("rotx", float.Parse(rotx.text));
        PlayerPrefs.SetFloat("roty", float.Parse(roty.text));
        PlayerPrefs.SetFloat("rotz", float.Parse(rotz.text));

        PlayerPrefs.SetFloat("scl", float.Parse(sclx.text));

        ARModelManager.instance.HideAdjustPanle();
    }
    public void DeletData()
    {
        PlayerPrefs.DeleteAll();
    }
}
