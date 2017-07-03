using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


public class ReDrawWindow : MonoBehaviour
{
    [DllImport("RedrawTitlebar", EntryPoint = "RedrawTitlebar", CallingConvention = CallingConvention.Cdecl)]
    private static extern void RedrawTitlebar(IntPtr _hWnd, IntPtr _hInst);

    // Use this for initialization
    void Start()
    {
        //#if UNITY_STANDALONE_WIN && !UNITY_EDITOR && !UNITY_EDITOR_WIN
//        RedrawTitlebar(Common.GetProcessWnd(), Common.GetProcessInstance());
//        RedrawTitlebar(GetWindowHandle(), GetWindowThreadProcessId());
//#endif
    }


//    [System.Runtime.InteropServices.DllImport("user32.dll")]
//    private static extern System.IntPtr GetActiveWindow();
//
//    public static System.IntPtr GetWindowHandle()
//    {
//        return GetActiveWindow();
//    }
//
//
//    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//    private static extern System.IntPtr GetWindowThreadProcessId(HandleRef handle, out int processId);
//
//    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
//
//    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//    private static extern bool EnumWindows(EnumWindowsProc callback, IntPtr extraData);
}
