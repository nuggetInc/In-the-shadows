using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnScreen : MonoBehaviour
{
	public Animator animator;

	void OnBecameVisible()
	{
		animator.enabled = true;
	}

	void OnBecameInvisible()
	{

		animator.enabled = false;
	}
}
