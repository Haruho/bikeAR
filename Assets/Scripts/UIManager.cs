using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject infoPage;
    public Sprite[] infoSprites;

    public bool isAdjustMode;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isAdjustMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Ìæ»»ÏêÇéÒ³ÄÚÈÝ
    /// </summary>
    /// <param name="hotpointMark"></param>
    public void ChangeInfoPage(string hotpointMark)
    {
        for (int i =0;i<infoSprites.Length;i++)
        {
            if (infoSprites[i].name == hotpointMark)
            {
                infoPage.transform.GetChild(0).GetComponent<Image>().sprite = infoSprites[i];
            }
        }
        infoPage.SetActive(true);
    }
    public void SetAdjustMode()
    {
        isAdjustMode = true;
    }
}
