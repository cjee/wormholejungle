﻿using UnityEngine;
using System.Collections;

public class AsteroidPart1 : AbstractEnemy {

	void Start()
	{
		rigidbody2D.velocity = transform.localRotation * (new Vector2(-0.7f,0.7f)) * velocityMax;
	}
}
