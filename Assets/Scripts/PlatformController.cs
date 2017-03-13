using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    public Collider2D scorerCollider;

    private Camera mainCam;
    private ScoreController scoreController;

    private void Awake()
    {
        mainCam = Camera.main;
        scoreController = GetComponentInChildren<ScoreController>();
    }

    private void OnEnable()
    {
        scorerCollider.enabled = true;
    }

    private void Update()
    {
        if(transform.position.y < mainCam.transform.position.y - mainCam.orthographicSize - 300)
        {
            gameObject.SetActive(false);
        }
    }
}
