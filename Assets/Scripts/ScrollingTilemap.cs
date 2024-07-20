using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTilemap : MonoBehaviour
{
    public float scrollSpeed;

    void Update()
    {
        float moveAmount = scrollSpeed * Time.deltaTime;

        foreach (Transform child in transform)
        {
            child.Translate(Vector2.right * moveAmount);
        }
    }
}