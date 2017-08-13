﻿using UnityEngine;

/// <summary>
/// Responsible for make the arrow points toward the Question object direction.
/// </summary>
/// Attached to the CanvasArrow object.
public class Arrow : MonoBehaviour {

    [SerializeField] private GameObject ArrowPrefab;
    
    private GameObject mRef;
	private Vector3 mDirection;
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Question")
            ArrowPrefab.SetActive(false);
    }

    void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Question")
			ArrowPrefab.SetActive (true);
    }
    
    void Update() {

        mRef = GameObject.FindGameObjectWithTag("Question");

        if (Quiz.m_FlagArrow) {
            ArrowPrefab.SetActive(true);
            Quiz.m_FlagArrow = false;
        }

        if (mRef != null) {
            mDirection = mRef.transform.position;
            mDirection.y = 0;
        }

        //arrow always looks forward so it will show correctly to viewer, and world-up changes the rotation
        transform.LookAt(transform.position + transform.forward, mDirection - transform.position);
    }
}