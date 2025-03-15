using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class URLOpener : MonoBehaviour
{
    // iOS用のネイティブプラグインの関数をインポート
    #if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern bool _OpenURL(string url);
    #endif

    public void OpenURL(string url)
    {
        #if UNITY_IOS && !UNITY_EDITOR
            // iOSデバイス上での実行の場合はネイティブコードを使用
            bool success = _OpenURL(url);
            Debug.Log("Opening URL with native code: " + success);
        #else
            // その他のプラットフォーム（エディタ含む）では標準メソッドを使用
            Application.OpenURL(url);
            Debug.Log("Opening URL with Application.OpenURL");
        #endif
    }

    // ボタンからこのメソッドを呼び出す
    public void OnButtonClick()
    {
        string url = "https://www.matsulab.org/#/products/hinannjyoq/privacypolicy";
        OpenURL(url);
    }
}