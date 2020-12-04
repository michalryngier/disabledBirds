using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SSscript : MonoBehaviour
{
	public float order;
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			order += Input.GetAxis("Mouse X") / 5;
		}
		else
		{
			float change = order - Mathf.RoundToInt(order);
			if (change > 0)
			{
                if (change > 0.05f)
                {
					order -= 0.05f;
                }
                else
                {
					order = Mathf.RoundToInt(order);
				}
			}
			else if (change < 0)
			{
				if (change < 0.05f)
				{
					order += 0.05f;
				}
				else
				{
					order = Mathf.RoundToInt(order);
				}
			}
		}

		transform.position = Vector3.up * 100
		                     + Vector3.left * 85
		                     + Vector3.right * 400 * order / Mathf.Sqrt(Mathf.Abs(order) + 1)
		                     + Vector3.forward * 10f * (Mathf.Abs(order) + 1);
		transform.localScale = new Vector3(1f / (Mathf.Abs(order) + 1), 1f / (Mathf.Abs(order) + 1), 1) * 7.5f;
	}
	void Start()
	{
	}

}
