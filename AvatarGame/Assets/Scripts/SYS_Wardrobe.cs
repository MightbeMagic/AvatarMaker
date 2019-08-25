using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SYS_Wardrobe : MonoBehaviour
{

	[SerializeField] int m_currentItemCount = 0;
	[SerializeField] int m_totalItemCount;
	[SerializeField] Sprite m_blank;
	[SerializeField] Sprite m_defaultHair;
	[SerializeField] Sprite m_defaultFace;
	[SerializeField] Sprite m_defaultTops;
	[SerializeField] Sprite m_defaultLegs;

	public List<INV_Clothing> m_wardrobe;

	//[SerializeField] RawImage m_hairBack;
	[SerializeField] RawImage m_base;
	[SerializeField] RawImage m_face;
	[SerializeField] RawImage m_hair;
	[SerializeField] RawImage m_tops;
	[SerializeField] RawImage m_legs;
	[SerializeField] RawImage m_feet;
	[SerializeField] RawImage m_misc;


	private void Start()
	{
		m_wardrobe = new List<INV_Clothing>();
		
		//m_hairBack.texture = m_blank.texture;
		m_face.texture = m_defaultFace.texture;
		m_hair.texture = m_defaultHair.texture;
		m_tops.texture = m_defaultTops.texture;
		m_legs.texture = m_defaultLegs.texture;
		m_feet.texture = m_blank.texture;
		m_misc.texture = m_blank.texture;
	}


	public void UpdateItems()
	{
		m_face.texture = Player.m_instance.m_faceEquipted == null ? m_defaultFace.texture : Player.m_instance.m_faceEquipted.m_sprite.texture;
		m_hair.texture = Player.m_instance.m_hairEquipted == null ? m_defaultHair.texture : Player.m_instance.m_hairEquipted.m_sprite.texture;
		m_tops.texture = Player.m_instance.m_topsEquipted == null ? m_defaultTops.texture : Player.m_instance.m_topsEquipted.m_sprite.texture;
		m_legs.texture = Player.m_instance.m_legsEquipted == null ? m_defaultLegs.texture : Player.m_instance.m_legsEquipted.m_sprite.texture;
		m_feet.texture = Player.m_instance.m_feetEquipted == null ? m_blank.texture : Player.m_instance.m_feetEquipted.m_sprite.texture;
		m_misc.texture = Player.m_instance.m_miscEquipted == null ? m_blank.texture : Player.m_instance.m_miscEquipted.m_sprite.texture;
	}

	public void ObtainItem(INV_Clothing item)
	{
		if (m_wardrobe.Exists(x => x.Equals(item))) return;

		m_wardrobe.Add(item);
		item.m_obtained = true;
		item.gameObject.SetActive(true);
	}
}
