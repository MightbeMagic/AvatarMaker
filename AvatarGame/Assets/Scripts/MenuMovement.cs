using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
	[SerializeField] bool first = false;
	[SerializeField] Transform m_startPosition;
	[SerializeField] Transform m_endPosition;
	[SerializeField] float m_time;
	[SerializeField] float m_timer;
	float delayTimer;
	bool transitioning;
	bool startMove = false;
	bool activeMenu;
	bool changeActiveness = false;

	Vector3 start;
	Vector3 end;

	// Use this for initialization
	void Start()
	{
		transform.position = m_startPosition.position;

		start = m_startPosition.position;
		end = m_endPosition.position;

		if (!first) gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		m_timer = m_timer + Time.deltaTime;
		delayTimer += Time.deltaTime;
		if (m_timer >= 0.5 && !startMove)
		{
			m_timer = 0;
			startMove = true;
		}
		else if (startMove)
		{
			//m_heck.Evaluate

			float t = m_timer / m_time;
			t = Mathf.Clamp01(t);
			t = Interpolation.ElasticOut(t);
			transform.position = Vector3.LerpUnclamped(m_startPosition.position, m_endPosition.position, t);
		}

		if (transitioning && delayTimer >= m_time)
		{
			Game.m_instance.gamescreen.SetActive(true);
			Game.m_instance.titlescreen.SetActive(false);
		}
		//if (changeActiveness && delayTimer >= m_time) this.gameObject.SetActive(false);
		
	}

	public void StartAnimation()
	{
		activeMenu = true;
		m_startPosition.position = start;
		m_endPosition.position = end;
		gameObject.transform.position = start;
		m_timer = 0;
	}

	public void ReverseAnimation(bool setinactive = false)
	{
		if (setinactive)
		{
			gameObject.SetActive(false);
		}
		else
		{
			m_startPosition.position = end;
			m_endPosition.position = start;
			m_timer = 0;
		}
	}

	public void StartGame()
	{
		delayTimer = 0;
		ReverseAnimation();
		transitioning = true;
	}
}
