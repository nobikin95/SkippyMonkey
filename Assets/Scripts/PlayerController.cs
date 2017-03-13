﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;

    public Collider2D headCollider;

    private Rigidbody2D rgBody;
    private Collider2D coll;
    private Animator anim;

    private bool GameStarted =false ;

    private void Awake()
    {
        rgBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        LeanTouch.OnFingerTap += OnFingerTap;
    }

    private void OnDestroy()
    {
        
    }
    public void Die() {
        coll.enabled = false;
        headCollider.enabled = false;
        rgBody.velocity = new Vector2(-150, rgBody.velocity.y);
        rgBody.freezeRotation = false;
        rgBody.angularVelocity = 80;
        LeanTouch.OnFingerTap -= OnFingerTap;
        PlayScene.Instance.GameOver();
    }

    private void OnFingerTap(LeanFinger finger)
    {
        GameStarted = true;
        anim.SetBool("IsGrounded", false);
        rgBody.velocity = new Vector2(rgBody.velocity.x, jumpSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("IsGrounded", true);
    }

    private void Start() {
        rgBody.velocity = new Vector2(runSpeed, 0);
    }

    private void Update()
    {
        if (coll.enabled)
        {
            if (GameStarted && rgBody.velocity.x < runSpeed / 2)
            {
                Die();
                return;
            }
            rgBody.velocity = new Vector2(runSpeed, rgBody.velocity.y);

            if (transform.position.x > 320)
            {
                transform.Translate(new Vector2(-640, 0));
            }
        }
        else {
            if ( transform.position.x < -320 ) {
                transform.Translate(new Vector2(640, 0));
            }
        }
        
    }
}
