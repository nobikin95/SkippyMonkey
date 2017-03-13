using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : MonoBehaviour {
    public static PlatformFactory Instance { get; private set; }

    public float initialPlatformY;
    public float initialPoolSize;
    public float platformYSpacing;
    public float platformXSpacing;
    public float gapSize;
    
    public GameObject platformPrefab;

    private List<GameObject> platforms = new List<GameObject>();
    private int currentPlatformIndex = 0;
    private float lastPlatformX = 0;

    private void Awake()
    {
        Instance = this;

        for(int i = 0; i < initialPoolSize; i++)
        {
            PutNewPlatformInPlace();
        }
    }

    public void PutNewPlatformInPlace() {
        GameObject platform = GetNewPlatform();
        float newX = Random.Range(lastPlatformX + platformXSpacing, lastPlatformX + 640 - gapSize);
        if (newX > 320 - gapSize/2) newX -= 640 - gapSize;
        lastPlatformX = newX;
        platform.transform.position = new Vector2(newX, initialPlatformY + currentPlatformIndex * platformYSpacing);
        platform.SetActive(true);
        currentPlatformIndex++;
    }

    private GameObject GetNewPlatform()
    {
        foreach(GameObject platform in platforms)
        {
            if (!platform.activeInHierarchy) return platform;
        }

        GameObject newPlatform = Instantiate(platformPrefab) as GameObject;
        platforms.Add(newPlatform);
        return newPlatform;
    }
}
