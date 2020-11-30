using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SSscript : MonoBehaviour
{
	public float order;
	/* this property should be the same as level scene name */
	public string levelName;
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			order += Input.GetAxis("Mouse X") / 5;
		}
		else
		{
			// change selected level name to currently selected level
			if (Mathf.RoundToInt(order) == 0) {
				SceneHelper scene = GameObject.Find("SceneController").GetComponent<SceneHelper>();
				if (this.levelName != null || this.levelName != "") {
					scene.sceneName = this.levelName;
				}
			}
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
		transform.position = Vector3.right * 160 * order / Mathf.Sqrt(Mathf.Abs(order) + 1) + Vector3.forward * (Mathf.Abs(order) + 1);
		transform.localScale = new Vector3(1f / (Mathf.Abs(order) + 1), 1f / (Mathf.Abs(order) + 1), 1) * 7.5f;
	}
	void Start()
	{
	}

}
