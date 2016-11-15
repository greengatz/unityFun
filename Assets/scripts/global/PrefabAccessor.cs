using UnityEngine;
using System.Collections.Generic;

public static class PrefabDict {

    private static Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();

    public static void set(string key, GameObject prefab)
    {
        dict.Add(key, prefab);
    }

	public static GameObject get(string key)
    {
        return dict[key];
    }
}
