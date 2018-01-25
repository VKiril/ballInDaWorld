#if UNITY_EDITOR 
using UnityEditor;
using UnityEngine;

public class DataContainerAsset
{
    [MenuItem("Assets/Create/Data Container")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<DataContainer>();
    }
}
#endif