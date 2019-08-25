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

	public int Ranking { get { return m_ranking; } set { m_ranking -= value; if (m_ranking <= 1) m_ranking = 1; INV_Ranking.text = m_ranking.ToString(); } }

	[SerializeField] public INV_Clothing m_hairEquipted;
	[SerializeField] public INV_Clothing m_faceEquipted;
	[SerializeField] public INV_Clothing m_topsEquipted;
	[SerializeField] public INV_Clothing m_legsEquipted;
	[SerializeField] public INV_Clothing m_feetEquipted;
	[SerializeField] public INV_Clothing m_miscEquipted;
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
		likesScore = (m_hairEquipted != null ? (int)m_hairEquipted.m_like : 0) + (m_faceEquipted != null ? (int)m_faceEquipted.m_like : 0)
					+ (m_topsEquipted != null ? (int)m_topsEquipted.m_like : 0) + (m_legsEquipted != null ? (int)m_legsEquipted.m_like : 0)
					+ (m_feetEquipted != null ? (int)m_feetEquipted.m_like : 0) + (m_miscEquipted != null ? (int)m_miscEquipted.m_like : 0);

		starsScore = (m_hairEquipted != null ? (int)m_hairEquipted.m_star : 0) + (m_faceEquipted != null ? (int)m_faceEquipted.m_star : 0)
			+ (m_topsEquipted != null ? (int)m_topsEquipted.m_star : 0) + (m_legsEquipted != null ? (int)m_legsEquipted.m_star : 0)
			+ (m_feetEquipted != null ? (int)m_feetEquipted.m_star : 0) + (m_miscEquipted != null ? (int)m_miscEquipted.m_star : 0);

		gemsScore = (m_hairEquipted != null ? (int)m_hairEquipted.m_gem : 0) + (m_faceEquipted != null ? (int)m_faceEquipted.m_gem : 0)
			+ (m_topsEquipted != null ? (int)m_topsEquipted.m_gem : 0) + (m_legsEquipted != null ? (int)m_legsEquipted.m_gem : 0)
			+ (m_feetEquipted != null ? (int)m_feetEquipted.m_gem : 0) + (m_miscEquipted != null ? (int)m_miscEquipted.m_gem : 0);

		heartsScore = (m_hairEquipted != null ? (int)m_hairEquipted.m_heart : 0) + (m_faceEquipted != null ? (int)m_faceEquipted.m_heart : 0)
			+ (m_topsEquipted != null ? (int)m_topsEquipted.m_heart : 0) + (m_legsEquipted != null ? (int)m_legsEquipted.m_heart : 0)
			+ (m_feetEquipted != null ? (int)m_feetEquipted.m_heart : 0) + (m_miscEquipted != null ? (int)m_miscEquipted.m_heart : 0);

		if (likesScore > 15) CURR_Likes.SetText("SS");
		else if (likesScore > 12) CURR_Likes.SetText("S");
		else if (likesScore > 9) CURR_Likes.SetText("A");
		else if (likesScore > 6) CURR_Likes.SetText("B");
		else if (likesScore > 3) CURR_Likes.SetText("C");
		else if (likesScore > 0) CURR_Likes.SetText("D");
		else CURR_Likes.SetText("F");

		if (heartsScore > 15) CURR_Hearts.SetText("SS");
		else if (heartsScore > 12) CURR_Hearts.SetText("S");
		else if (heartsScore > 9) CURR_Hearts.SetText("A");
		else if (heartsScore > 6) CURR_Hearts.SetText("B");
		else if (heartsScore > 3) CURR_Hearts.SetText("C");
		else if (heartsScore > 0) CURR_Hearts.SetText("D");
		else CURR_Hearts.SetText("F");

		if (starsScore > 15) CURR_Stars.SetText("SS");
		else if (starsScore > 12) CURR_Stars.SetText("S");
		else if (starsScore > 9) CURR_Stars.SetText("A");
		else if (starsScore > 6) CURR_Stars.SetText("B");
		else if (starsScore > 3) CURR_Stars.SetText("C");
		else if (starsScore > 0) CURR_Stars.SetText("D");
		else CURR_Stars.SetText("F");

		if (gemsScore > 15) CURR_Likes.SetText("SS");
		else if (gemsScore > 12) CURR_Gems.SetText("S");
		else if (gemsScore > 9) CURR_Gems.SetText("A");
		else if (gemsScore > 6) CURR_Gems.SetText("B");
		else if (gemsScore > 3) CURR_Gems.SetText("C");
		else if (gemsScore > 0) CURR_Gems.SetText("D");
		else CURR_Gems.SetText("F");
	}
}
