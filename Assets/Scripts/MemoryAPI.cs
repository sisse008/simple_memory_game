using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MemoryAPI 
{
    private const string INT_KEY = "int";
    private const string STRING_KEY = "string";
    private const string BOOL_KEY = "bool";
    private const string FLOAT_KEY = "float";
    public static int GetInt(string keyCode)
    {
        return PlayerPrefs.GetInt(INT_KEY+ keyCode, -1);
    }
    public static void SetInt(int i, string keyCode)
    {
        string key = INT_KEY + keyCode;
        PlayerPrefs.SetInt(key , i);
        Debug.Log("saved: " + i.ToString() + "for key: " + key);
    }

    public static string GetString(string keyCode)
    {
        return PlayerPrefs.GetString(STRING_KEY+ keyCode, "None");
    }
    public static void SetString(string s, string keyCode)
    {
        string key = STRING_KEY + keyCode;
        PlayerPrefs.SetString(key, s);
        Debug.Log("saved: " + s + "for key: " + key);
    }

    public static bool GetBool(string keyCode)
    {
        int bool_i = PlayerPrefs.GetInt(BOOL_KEY+ keyCode, 0);
        if(bool_i == 0) return false;
        return true;
    }
    public static void SetBool(bool b, string keyCode)
    {
        string key = BOOL_KEY + keyCode;
        PlayerPrefs.SetInt(key, b? 1:0);
        Debug.Log("saved: " + b.ToString() + "for key: " + key);
    }

    public static float GetFloat(string keyCode)
    { 
        return PlayerPrefs.GetFloat(FLOAT_KEY+ keyCode);
    }

    public static void SetFloat(float f, string keyCode)
    {
        string key = FLOAT_KEY + keyCode;
        PlayerPrefs.SetFloat(key, f);
        Debug.Log("saved: " + f.ToString() + "for key: " + key);
    }
}
