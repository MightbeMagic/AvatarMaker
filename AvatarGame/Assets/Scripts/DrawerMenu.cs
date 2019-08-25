using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawerMenu : MonoBehaviour
{
	[SerializeField] GameObject Menu;
	[SerializeField] Transform sprite;
	[SerializeField] RectTransform wp_Open;
	[SerializeField] RectTransform wp_Closed;
	[SerializeField] float m_time;
	[SerializeField] float m_timer;

	Vector3 m_open;
	Vector3 m_closed;

	RectTransform m_start;
	RectTransform m_end;

	bool open = false;
	// Use this for initialization
	void Start()
	{
		m_open = new Vector3(-1, -1, 1);
		m_closed = new Vector3(1, 1, 1);

		m_start = wp_Closed;
		m_end = wp_Open;
	}

	private void Update()
	{
		m_timer += (Time.deltaTime);
		float t = m_timer / m_time;
		t = Mathf.Clamp01(t);
		t = Interpolation.ElasticOut(t);
		transform.position = Vector3.LerpUnclamped(m_start.position, m_end.position, t);

	}

	public void ClickArrow()
	{
		open = !open;
		m_timer = 0;
		if (open)
		{
			Menu.GetComponent<RectTransform>().position = wp_Open.position;
			sprite.localScale = m_open;
			m_start = wp_Open;
			m_end = wp_Closed;
		}
		else
		{
			Menu.GetComponent<RectTransform>().position = wp_Closed.position;
			sprite.localScale = m_closed;
			m_start = wp_Closed;
			m_end = wp_Open;
		}
	}
}
