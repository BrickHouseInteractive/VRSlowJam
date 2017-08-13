﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour {

    public enum State
    {
        Attacking,
        NotAttacking
    }

	private SphereCollider collider;
    //private AnimationState animationState;

    State state;
	ApplyDamageBehavior applyDamageBehavior;

    // Use this for initialization
    void Start () {
		collider = GetComponent<SphereCollider>();
		applyDamageBehavior = GetComponent<ApplyDamageBehavior>();
		ChangeState(State.NotAttacking);
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void ChangeState(State newState)
    {
        state = newState;
        switch (state)
        {
            case State.Attacking:
                attack();
                break;
            case State.NotAttacking:
                stopAttack();
                break;
        }
    }

    public void attack()
    {
        Debug.Log("attacking");
        collider.enabled = true;
		applyDamageBehavior.enabled = true;
        return;
    }

    public void stopAttack()
    {
        Debug.Log("not attacking");
        collider.enabled = false;
		applyDamageBehavior.enabled = false;
		return;
    }
}
