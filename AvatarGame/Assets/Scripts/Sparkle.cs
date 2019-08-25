using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkle : MonoBehaviour
{
	ParticleSystem m_this;
	// Use this for initialization
	void Start()
	{
		m_this = GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update()
	{
		//while(!m_this.isPlaying)transform.position = Camera.main.ViewportToWorldPoint(Input.mousePosition);
		if (Input.GetMouseButtonDown(0)) OnClick();
	}

	public void OnClick()
	{
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(transform.position.x, transform.position.y, -10);
		m_this.Play();
	}
}
