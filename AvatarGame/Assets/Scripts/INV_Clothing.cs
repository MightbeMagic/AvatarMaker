using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eTypes;

public class INV_Clothing : MonoBehaviour
{

	[SerializeField] public eScore m_heart;
	[SerializeField] public eScore m_gem;
	[SerializeField] public eScore m_star;
	[SerializeField] public eScore m_like;

	[SerializeField] int m_heartCost;
	[SerializeField] int m_gemCost;
	[SerializeField] int m_starCost;
	[SerializeField] int m_likeCost;

	[SerializeField] public INV_Clothing m_counterpart;

	public int Hearts_Cost { get { return m_heartCost; } set { } }
	public int Gems_Cost { get { return m_gemCost; } set { } }
	public int Stars_Cost { get { return m_starCost; } set { } }
	public int Likes_Cost { get { return m_likeCost; } set { } }

	[SerializeField] public eAttribute m_mainAttribute;
	[SerializeField] public ePartType m_type;
	[SerializeField] public string name;
	[SerializeField] public Sprite m_sprite;
	[SerializeField] public Sprite m_additionalSprite;
	[SerializeField] public bool m_obtained;

	Vector3 m_jumpPosition;
	Vector3 m_restingPosition;

	Vector3 m_start;
	Vector3 m_end;
	float m_timer = 1;
	float m_time = 1;


	private Button m_button;

	private void Start()
	{
		m_button = GetComponent<Button>();
		if (!m_obtained) this.gameObject.SetActive(false);

		m_restingPosition = gameObject.GetComponent<RectTransform>().localPosition;
		m_jumpPosition = m_restingPosition;
		m_jumpPosition = gameObject.GetComponent<RectTransform>().localPosition + Vector3.up * 25;
		m_start = m_restingPosition;
		m_end = m_restingPosition;
	}

	private void Update()
	{
		m_timer += (Time.deltaTime);
		float t = m_timer / m_time;
		t = Mathf.Clamp01(t);
		t = Interpolation.ElasticOut(t);
		gameObject.GetComponent<RectTransform>().localPosition = Vector3.LerpUnclamped(m_start, m_end, t);
	}

	public void PreviewHover()
	{
		WardrobeMenu.m_instance.m_previewGem.SetText(this.m_gem.ToString());
		WardrobeMenu.m_instance.m_previewStar.SetText(this.m_star.ToString());
		WardrobeMenu.m_instance.m_previewHeart.SetText(this.m_heart.ToString());
		WardrobeMenu.m_instance.m_previewLike.SetText(this.m_like.ToString());

		WardrobeMenu.m_instance.m_previewName.SetText(this.name);
		WardrobeMenu.m_instance.m_attribute.SetText(this.m_mainAttribute.ToString());
		WardrobeMenu.m_instance.m_previewSprite.texture = this.m_sprite.texture;
	}

	public void PreviewEnter()
	{
			m_timer = 0;
			m_start = m_restingPosition;
			m_end = m_jumpPosition;
		
	}

	public void PreviewExit()
	{
			m_end = m_restingPosition;
			m_start = m_jumpPosition;
			m_timer = 0;
		
	}

	public void SetCurrentPart()
	{
		Player player = Player.m_instance;
		INV_Clothing current = player.m_equipped.ContainsKey(m_type) ? player.m_equipped[m_type] : null;
		if (current != this)
		{
			if (!player.m_equipped.ContainsKey(m_type))
				player.m_equipped.Add(m_type, null);
			player.m_equipped[m_type] = this;
		}
		else
		{
			player.m_equipped[m_type] = null;
		}

		player.m_wardrobe.UpdateItems();
		player.UpdateAttributes();
	}

}
