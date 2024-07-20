using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance { get; private set; }

    private Dictionary<GameObject, ScrollingTilemap> scrollingTilemaps = new Dictionary<GameObject, ScrollingTilemap>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterScrollingTilemap(GameObject name, ScrollingTilemap scrollingTilemap)
    {
        if (!scrollingTilemaps.ContainsKey(name))
        {
            scrollingTilemaps.Add(name, scrollingTilemap);
        }
    }

    public void SetScrollSpeed(float newSpeed)
    {
        foreach (var tilemap in scrollingTilemaps.Values)
        {
            tilemap.scrollSpeed = newSpeed;
        }
    }
}
