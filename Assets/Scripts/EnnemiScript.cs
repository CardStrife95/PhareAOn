﻿using UnityEngine;
using System.Collections;

public class EnnemiScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        string name = col.gameObject.tag;
        if (name == "Character")
        {
            Destroy(gameObject);
        }
    }
}
