using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitFunction : MonoBehaviour
{
    // HOW TO USE
    // 1. set script in hierachy (for example in an manager object). Make sure that it stays persistent.
    // 2. call "ExitFunction.ExitExperience();" at the place you want to quit the application.
    //   (i.e. by pressing a specific button or through the menu)


    private static ExitFunction _instance;
    public static ExitFunction Instance { get => _instance; }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string className, string windowTitle);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int SetForegroundWindow(IntPtr hwnd);


    private enum ShowWindowEnum
    {
        Hide = 0,
        ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
        Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
        Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
        Restore = 9, ShowDefault = 10, ForceMinimized = 11
    };

    private void Awake()
    {
        _instance = this;
    }

    public void ExitExperience()
    {
        IntPtr wdwIntPtr = (IntPtr)(-1);
        wdwIntPtr = FindWindow(null, "INVR_Platform"); // this needs to be the name of the INVR Platform software

        if (wdwIntPtr == (IntPtr)0)
        {
            Debug.LogWarning("Couldn't find window.");
        }
        else
        {
            ShowWindow(wdwIntPtr, ShowWindowEnum.Show);  // Make the window visible if it was hidden
            ShowWindow(wdwIntPtr, ShowWindowEnum.Restore);  // Next, restore it if it was minimized
            SetForegroundWindow(wdwIntPtr);  // activate the window 
        }
        _instance.StartCoroutine(nameof(CO_QuitApplication));
    }

    private IEnumerator CO_QuitApplication()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}
