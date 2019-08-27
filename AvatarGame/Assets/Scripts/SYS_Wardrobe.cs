using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SYS_Wardrobe : MonoBehaviour
{

	[SerializeField] int m_currentItemCount = 0;
	[SerializeField] int m_totalItemCount;
	[SerializeField] private TypeSpriteDictionary m_defaultSprites;
	[SerializeField] private TypeImageDictionary m_rawImages;

	public List<INV_Clothing> m_wardrobe;

	private void Awake()
	{
		m_wardrobe = new List<INV_Clothing>();

		foreach(eTypes.ePartType type in m_defaultSprites.Keys)
		{
			m_rawImages[type].texture = m_defaultSprites[type].texture;
		}
	}


	public void UpdateItems()
	{
		foreach (eTypes.ePartType type in m_defaultSprites.Keys)
		{
			if(Player.m_instance.m_equipped.ContainsKey(type) && Player.m_instance.m_equipped[type] != null)
			{
				m_rawImages[type].texture = Player.m_instance.m_equipped[type].m_sprite.texture;
			}
			else
			{
				m_rawImages[type].texture = m_defaultSprites[type].texture;
			}
		}
	}

	public void ObtainItem(INV_Clothing item)
	{
		if (m_wardrobe.Exists(x => x.Equals(item))) return;

		m_wardrobe.Add(item);
		item.m_obtained = true;
		item.gameObject.SetActive(true);
	}
}
