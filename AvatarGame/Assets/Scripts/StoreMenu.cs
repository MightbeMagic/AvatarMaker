using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoreMenu : MonoBehaviour
{
	[SerializeField] public RawImage m_previewSprite;
	[SerializeField] public TextMeshProUGUI m_previewName;

	[SerializeField] public TextMeshProUGUI m_previewHeart;
	[SerializeField] public TextMeshProUGUI m_previewStar;
	[SerializeField] public TextMeshProUGUI m_previewLike;
	[SerializeField] public TextMeshProUGUI m_previewGem;
	[SerializeField] public TextMeshProUGUI m_attribute;

	[SerializeField] public INV_Clothing m_selected;
	[SerializeField] public Button m_buy;

	[SerializeField] public GameObject m_LowCurrency;
	public void PreviewClick(INV_Clothing newSelection)
	{
		m_selected = newSelection;

		m_previewGem.SetText(m_selected.Gems_Cost.ToString());
		m_previewStar.SetText(m_selected.Stars_Cost.ToString());
		m_previewHeart.SetText(m_selected.Hearts_Cost.ToString());
		m_previewLike.SetText(m_selected.Likes_Cost.ToString());

		m_previewName.SetText(m_selected.name);
		m_attribute.SetText(m_selected.m_mainAttribute.ToString());
		m_previewSprite.texture = m_selected.m_sprite.texture;
		m_buy.interactable = true;
	}

	public void Buy()
	{
		if (m_selected)
		{
			if (m_selected.Hearts_Cost <= Player.m_instance.hearts_currency &&
				m_selected.Stars_Cost <= Player.m_instance.stars_currency &&
				m_selected.Gems_Cost <= Player.m_instance.gems_currency &&
				m_selected.Likes_Cost <= Player.m_instance.likes_currency)
			{
				m_selected.m_counterpart.gameObject.SetActive(true);
				m_selected.m_counterpart.m_obtained = true;
				Player.m_instance.hearts_currency -= m_selected.Hearts_Cost;
				Player.m_instance.likes_currency -= m_selected.Likes_Cost;
				Player.m_instance.stars_currency -= m_selected.Stars_Cost;
				Player.m_instance.gems_currency -= m_selected.Gems_Cost;
				m_selected.gameObject.SetActive(false);
				m_selected.m_obtained = false;
				Player.m_instance.UpdateCurrency();
			}
			else
			{
				m_LowCurrency.SetActive(true);
			}
		}
	}
}
