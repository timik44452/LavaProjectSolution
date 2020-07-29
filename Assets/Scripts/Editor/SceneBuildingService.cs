using UnityEditor;
using UnityEngine;

public static class SceneBuildingService
{
    [MenuItem("Tools/Scene service/CreateManager")]
    public static void CreateManagerGameObject()
    {
        GameObject managerGameObject = new GameObject("Managers");

        managerGameObject.AddComponent<AimSystem>();
    }
}
