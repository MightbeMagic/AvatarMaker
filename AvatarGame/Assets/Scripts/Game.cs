using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eTypes;
using TMPro;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
	[SerializeField] Image t_TrendSet;
	[SerializeField] TextMeshProUGUI t_TrendComment1;
	[SerializeField] Image[] t_TrendComment2;

	[SerializeField] TextMeshProUGUI s_Trend;
	[SerializeField] TextMeshProUGUI s_TrendDescription;
	[SerializeField] TextMeshProUGUI s_Score;

	[SerializeField] Progression m_progression;
	[SerializeField] public List<Sprite> m_sets;
	[SerializeField] public Sprite[] attributeSymbols;

	[SerializeField] public GameObject gamescreen;
	[SerializeField] public GameObject titlescreen;
	
	[SerializeField] public MenuMovement activeMenu;

	public Player m_player;
	public Trend m_currentTrend;
	List<Trend> m_allTrends;

	static public Game m_instance;
	// Use this for initialization
	void Start()
	{
		Progression.m_instance = m_progression;
		m_progression.Init();
		m_instance = this;
		m_allTrends = Trend.GenerateTrends();
		m_player = FindObjectOfType<Player>();
		m_currentTrend = m_allTrends.Find(x => x.Name == eTrend.ACTIVE);
		t_TrendSet.sprite = m_currentTrend.TX_set;
		t_TrendComment1.text = m_currentTrend.Description;
		foreach (var item in t_TrendComment2)
		{
			item.sprite = m_currentTrend.TX_attribute;
		}
		s_Trend.text = m_currentTrend.Name.ToString();
		s_TrendDescription.text = m_currentTrend.Description;
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	void ChangeTrend()
	{
		m_currentTrend = m_allTrends[Random.Range(0, m_allTrends.Count)];
		t_TrendSet.sprite = m_currentTrend.TX_set;
		t_TrendComment1.text = m_currentTrend.Description;
		foreach (var item in t_TrendComment2)
		{
			item.sprite = m_currentTrend.TX_attribute;
		}
	}

	public void OpenMenu(MenuMovement menu)
	{
		menu.gameObject.SetActive(true);
		menu.StartAnimation();

		activeMenu = menu;
	}

	public void CloseMenu()
	{
		activeMenu.ReverseAnimation(true);
	}

	public void ShareOutfit()
	{
		int score = m_currentTrend.ReturnScore(m_player.HeartsScore, m_player.GemsScore, m_player.LikesScore, m_player.StarsScore);
		if (score > 45)
		{
			s_Score.SetText("SS" + " (" + score.ToString() + ")");
			m_player.Ranking -= 75;
		}
		else if (score > 36)
		{
			s_Score.SetText("S" + " (" + score.ToString() + ")");
			m_player.Ranking -= 45;

		}
		else if (score > 27)
		{
			s_Score.SetText("A" + " (" + score.ToString() + ")");
			m_player.Ranking -= 30;

		}
		else if (score > 18)
		{
			s_Score.SetText("B" + " (" + score.ToString() + ")");
			m_player.Ranking -= 20;

		}
		else if (score > 9)
		{
			s_Score.SetText("C" + " (" + score.ToString() + ")");
			m_player.Ranking -= 10;

		}
		else if (score > 0)
		{
			s_Score.SetText("D" + " (" + score.ToString() + ")");
			m_player.Ranking += 25;

		}
		else
		{
			s_Score.SetText("F"+ " (" + score.ToString() + ")");
			m_player.Ranking += 100;
		}
		//s_Score.text += " (" + score.ToString() + ")";
		s_Trend.text = m_currentTrend.Name.ToString();
		s_TrendDescription.text = m_currentTrend.Description;
		Progression.m_instance.CheckForReward();
		ChangeTrend();

	}
}
