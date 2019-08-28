using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

	[SerializeField] TextMeshProUGUI CURR_Likes;
	[SerializeField] TextMeshProUGUI CURR_Hearts;
	[SerializeField] TextMeshProUGUI CURR_Gems;
	[SerializeField] TextMeshProUGUI CURR_Stars;

	[SerializeField] TextMeshProUGUI m_likesStash;
	[SerializeField] TextMeshProUGUI m_starsStash;
	[SerializeField] TextMeshProUGUI m_heartsStash;
	[SerializeField] TextMeshProUGUI m_gemsStash;

	[SerializeField] int likesScore = 0;
	[SerializeField] int heartsScore = 0;
	[SerializeField] int gemsScore = 0;
	[SerializeField] int starsScore = 0;

	[SerializeField] public int likes_currency = 0;
	[SerializeField] public int hearts_currency = 0;
	[SerializeField] public int gems_currency = 0;
	[SerializeField] public int stars_currency = 0;

	public int LikesScore { get { return likesScore; } set { } }
	public int HeartsScore { get { return heartsScore; } set { } }
	public int GemsScore { get { return gemsScore; } set { } }
	public int StarsScore { get { return starsScore; } set { } }

	[SerializeField] int m_ranking = 1000;

	public int Ranking { get { return m_ranking; }
		set
		{
			m_ranking = Mathf.Max(value, 1);
			INV_Ranking.text = m_ranking.ToString();
		}
	}
	public Dictionary<eTypes.ePartType, INV_Clothing> m_equipped = new Dictionary<eTypes.ePartType, INV_Clothing>();

	[SerializeField] public SYS_Wardrobe m_wardrobe;

	[SerializeField] public TextMeshProUGUI INV_Ranking;
	public static Player m_instance;

	private void Start()
	{
		m_instance = this;

		m_wardrobe = GetComponent<SYS_Wardrobe>();
		UpdateCurrency();
		UpdateAttributes();
	}

	public void UpdateCurrency()
	{
		m_likesStash.text = likes_currency.ToString();
		m_starsStash.text = stars_currency.ToString();
		m_gemsStash.text = gems_currency.ToString();
		m_heartsStash.text = hearts_currency.ToString();
	}
	public void UpdateAttributes()
	{
		ClearAttributes();
		
		foreach(var item in m_equipped.Values)
		{
			UpdateAttribute(item);
		}

		UpdateAttributeText(CURR_Likes, likesScore);
		UpdateAttributeText(CURR_Hearts, heartsScore);
		UpdateAttributeText(CURR_Stars, starsScore);
		UpdateAttributeText(CURR_Gems, gemsScore);
	}
	private void UpdateAttributeText(TextMeshProUGUI text, int value)
	{
		if (value > 15) text.SetText("SS");
		else if (value > 12) text.SetText("S");
		else if (value > 9) text.SetText("A");
		else if (value > 6) text.SetText("B");
		else if (value > 3) text.SetText("C");
		else if (value > 0) text.SetText("D");
		else text.SetText("F");
	}
	private void ClearAttributes()
	{
		likesScore = 0;
		starsScore = 0;
		gemsScore = 0;
		heartsScore = 0;
	}
	private void UpdateAttribute(INV_Clothing item)
	{
		if (item != null)
		{
			likesScore += (int)item.m_like;
			starsScore += (int)item.m_star;
			gemsScore += (int)item.m_gem;
			heartsScore += (int)item.m_heart;
		}
	}
}
