using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ScoreController : MonoBehaviour {
    private Collider2D coll;

    private int highScore = 0;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayScene.Instance.Score();
        PlatformFactory.Instance.PutNewPlatformInPlace();
        
        coll.enabled = false;
    }
}
