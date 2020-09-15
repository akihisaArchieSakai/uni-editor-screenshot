using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace archieSakai.UniEditorScreenshot
{
    public class UniEditorScreenshot : EditorWindow
    {
        [UnityEditor.MenuItem("Screenshot/Capture Game Screen")]
        static public void OpenWindow()
        {
            GetWindow<UniEditorScreenshot>(true, "captutre game screen");
        }

        string path = "~/";
        string filename = "captutre";
        bool includeDateTime = true;

        void OnGUI()
        {
            GUILayout.Label("save path:");
            path = GUILayout.TextField(path);

            GUILayout.Label("file name:");
            filename = GUILayout.TextField(filename);

            includeDateTime = GUILayout.Toggle(includeDateTime, "Include date and time in the file name");

            if (GUILayout.Button("Save ScreenShot"))
            {
                Capture();
            }
        }

        void Capture()
        {
            var filePath = includeDateTime
                ? string.Format(Path.Combine(path, "{0}_{1}.png"), filename, DateTime.Now.ToString("yyyyMMddHHmmss"))
                : string.Format(Path.Combine(path, "{0}.png"), filename);

            Debug.Log(string.Format("Save a screenshot at {0}", filePath));
            ScreenCapture.CaptureScreenshot(string.Format(filePath));
        }
    }

}
