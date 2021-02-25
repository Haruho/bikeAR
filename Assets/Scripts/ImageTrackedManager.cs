using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackedManager : MonoBehaviour
{
    public static ImageTrackedManager instance;
    ARTrackedImageManager m_trackedManager;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_trackedManager = GetComponent<ARTrackedImageManager>();
    }
    /// <summary>
    /// 注册监听函数
    /// </summary>
    private void OnEnable()
    {
        m_trackedManager.trackedImagesChanged += OnImageChanged;
    }
    private void OnDisable()
    {
        m_trackedManager.trackedImagesChanged -= OnImageChanged;
    }
    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImg in args.added)
        {
            UpdateImg(trackedImg);
        }
        foreach (var trackedImg in args.updated)
        {
            UpdateImg(trackedImg);
        }
        foreach (var trackedImg in args.removed)
        {
            UpdateImg(trackedImg);
        }
    }

    private void UpdateImg(ARTrackedImage trackedImg)
    {
        Debug.Log("UpdateIng");
    }
}
