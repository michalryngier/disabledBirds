using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSscript : MonoBehaviour
{
    public int order;
	public Button leftButton;
	public Button rightButton;


	void Update()
	{
	}
	void Start()
	{
		//Button btn = leftButton.GetComponent<Button>();
		leftButton.onClick.AddListener(TaskOnClickLeft);
		rightButton.onClick.AddListener(TaskOnClickRight);
	}

	void TaskOnClickLeft()
	{
		order--;
        transform.localPosition = Vector3.right * 80 * order / Mathf.Sqrt(Mathf.Abs(order) + 1) + Vector3.back * (Mathf.Abs(order) + 1);
		transform.localScale = new Vector3(1f / (Mathf.Abs(order) + 1), 1f / (Mathf.Abs(order) + 1), 1);
	}
	void TaskOnClickRight()
	{
		order++;
		transform.localPosition = Vector3.right * 80 * order / Mathf.Sqrt(Mathf.Abs(order) + 1) + Vector3.back *( Mathf.Abs(order) + 1);
		transform.localScale = new Vector3(1f / (Mathf.Abs(order) + 1), 1f / (Mathf.Abs(order) + 1), 1);
	}
}
