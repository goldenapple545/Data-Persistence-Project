using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    public void StartNew()
    {
        // if (String.IsNullOrEmpty(_inputField.text.Trim()))
        // {
        //     return;
        // }
        SaveData.instance.nickName = _inputField.text.Trim();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveData.instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    
}
