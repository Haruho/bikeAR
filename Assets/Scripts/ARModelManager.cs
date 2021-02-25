using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARModelManager : MonoBehaviour
{
    public static ARModelManager instance;
    GameObject activeModel;
    GameObject transparentModel;
    GameObject adjustBtn;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        Debug.Log("Prefab Create");
    }
    // Start is called before the first frame update
    void Start()
    {
        adjustBtn = GameObject.Find("Canvas").transform.Find("AdjustBtn").gameObject;
        adjustBtn.SetActive(true);
        activeModel = this.gameObject;
        transparentModel = transform.GetChild(1).gameObject;
        if (PlayerPrefs.GetString("savemark") == "true")
        {
            transform.GetChild(0).transform.localPosition = new Vector3(PlayerPrefs.GetFloat("posx"), PlayerPrefs.GetFloat("posy"), PlayerPrefs.GetFloat("posz"));
            transform.GetChild(0).transform.localEulerAngles = new Vector3(PlayerPrefs.GetFloat("rotx"), PlayerPrefs.GetFloat("roty"), PlayerPrefs.GetFloat("rotz"));
            transform.GetChild(0).transform.localScale = new Vector3(PlayerPrefs.GetFloat("scl"), PlayerPrefs.GetFloat("scl"), PlayerPrefs.GetFloat("scl"));

            transform.GetChild(1).transform.localPosition = new Vector3(PlayerPrefs.GetFloat("posx"), PlayerPrefs.GetFloat("posy"), PlayerPrefs.GetFloat("posz"));
            transform.GetChild(1).transform.localEulerAngles = new Vector3(PlayerPrefs.GetFloat("rotx"), PlayerPrefs.GetFloat("roty"), PlayerPrefs.GetFloat("rotz"));
            transform.GetChild(1).transform.localScale = new Vector3(PlayerPrefs.GetFloat("scl"), PlayerPrefs.GetFloat("scl"), PlayerPrefs.GetFloat("scl"));
        }
        else
        {
            Debug.Log("No Save Data");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetActivePrefab()
    {
        if (activeModel != null)
        {
            return activeModel;
        }
        else
        {
            return null;
        }
    }
    public void AcceptValue(Vector3 pos,Vector3 rot,Vector3 scale)
    {
        transform.GetChild(0).localPosition = pos;
        transform.GetChild(0).localEulerAngles = rot;
        transform.GetChild(0).localScale = scale;

        transform.GetChild(1).localPosition = pos;
        transform.GetChild(1).localEulerAngles = rot;
        transform.GetChild(1).localScale = scale;
    }
    public void HideAdjustPanle()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        adjustBtn.SetActive(true);
        Adjust.instance.adjustPanle.SetActive(false);
    }
}
