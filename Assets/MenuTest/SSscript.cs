using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSscript : MonoBehaviour
{
	public float order;
	void Update()
	{
		if (Input.GetMouseButton(0))
		{

			order += Input.GetAxis("Mouse X") / 20;
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
		transform.position = Vector3.right * 40 * order / Mathf.Sqrt(Mathf.Abs(order) + 1) + Vector3.forward * (Mathf.Abs(order) + 1);
		transform.localScale = new Vector3(1f / (Mathf.Abs(order) + 1), 1f / (Mathf.Abs(order) + 1), 1) * 20;
	}
	void Start()
	{
	}

}
