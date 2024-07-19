using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class DropHandler
{
    static DropHandler()
    {
        DragAndDrop.AddDropHandler(OnDropHandler);
    }

    static DragAndDropVisualMode OnDropHandler(int dragId, HierarchyDropFlags dropMode, Transform parent, bool perform)
    {
        MonoScript script = GetScript();
        if (script != null)
        {
            if (perform)
            {
                GameObject go = CreateObj(script.name);
                Component c = go.AddComponent(script.GetClass());
            }
            return DragAndDropVisualMode.Copy;
        }
        return DragAndDropVisualMode.None;
    }

    static MonoScript GetScript()
    {
        foreach(Object dragged in DragAndDrop.objectReferences)
        {
            if (dragged is MonoScript ms) {
                return ms;
            }
        }
        return null;
    }

    public static GameObject CreateObj(string name)
    {
        GameObject go = new GameObject(name);
        Selection.activeObject = go;
        return go;
    }
}
