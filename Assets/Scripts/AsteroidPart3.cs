﻿using UnityEngine;
using System.Collections;

public class AsteroidPart3 : AbstractEnemy {

	void Start () {
		rigidbody2D.velocity = transform.localRotation * (new Vector2(-0.02f, -0.99f)) * velocityMax;
	}
}
