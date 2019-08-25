using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using eTypes;

public class Progression : MonoBehaviour
{
	[SerializeField] TMP_Dropdown m_questDropdown;
	[SerializeField] INV_Clothing[] questRewards;

	[SerializeField] TextMeshProUGUI m_namePreview;
	[SerializeField] TextMeshProUGUI m_descriptionPreview;

	[SerializeField] public RawImage m_previewSprite;
	[SerializeField] public TextMeshProUGUI m_itemNamePreview;

	[SerializeField] public TextMeshProUGUI m_previewHeart;
	[SerializeField] public TextMeshProUGUI m_previewStar;
	[SerializeField] public TextMeshProUGUI m_previewLike;
	[SerializeField] public TextMeshProUGUI m_previewGem;
	[SerializeField] public TextMeshProUGUI m_attribute;
	[SerializeField] GameObject m_reward;

	[SerializeField] TextMeshProUGUI m_rewardName;
	[SerializeField] TextMeshProUGUI m_rewardDescription;
	[SerializeField] Image m_rewardImage;
	Quest currentQuest;
	List<Quest> completedQuests;
	public static Progression m_instance;

	private List<Quest> m_quests = new List<Quest>();
	// Use this for initialization
	void Start()
	{
		m_instance = this;
	}

	public void Init()
	{
		completedQuests = new List<Quest>();
		completedQuests = new List<Quest>();
		m_quests.Add(new Quest("Rank up once", "Reach rank 990", questRewards[0], 10));
		m_quests.Add(new Quest("Getting Somewhere", "Reach rank 750", questRewards[1], 250));
		m_quests.Add(new Quest("On My Way to the Top", "Reach rank 500", questRewards[2], 500));
		m_quests.Add(new Quest("Master of Fashion", "Reach rank 300", questRewards[3], 700));
		m_quests.Add(new Quest("Top of the Food Chain", "Reach rank 50", questRewards[4], 950));
		m_quests.Add(new Quest("One of a Kind", "Reach rank 1", questRewards[5], 999));

		List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
		options.Add(new TMP_Dropdown.OptionData(""));

		foreach (var item in m_quests)
		{
			options.Add(new TMP_Dropdown.OptionData(item.name));
		}

		m_questDropdown.AddOptions(options);
	}

	public void PreviewQuest()
	{
		currentQuest = m_quests.Find(x => x.name == m_questDropdown.options[m_questDropdown.value].text);
		if (currentQuest != null)
		{
			m_namePreview.text = currentQuest.name;
			m_descriptionPreview.text = currentQuest.description;

			m_previewSprite.texture = currentQuest.reward.m_sprite.texture;
			m_itemNamePreview.text = currentQuest.reward.name;
			m_previewHeart.text = currentQuest.reward.m_heart.ToString();
			m_previewStar.text = currentQuest.reward.m_star.ToString();
			m_previewGem.text = currentQuest.reward.m_gem.ToString();
			m_previewLike.text = currentQuest.reward.m_like.ToString();
			m_attribute.text = currentQuest.reward.m_mainAttribute.ToString();
		}
	}

	public void CheckForReward()
	{
		foreach (var item in m_quests)
		{
			if (Player.m_instance.Ranking <= 1000 - item.requirement && !item.complete)
			{
				completedQuests.Add(item);
			}
		}
		FillRewardOverlay();
	}

	public void FillRewardOverlay()
	{
		Debug.Log("Checked: " + completedQuests.Count);
		if (completedQuests.Count > 0)
		{
			m_reward.SetActive(true);

			m_rewardDescription.text = completedQuests[0].description;
			m_rewardName.text = completedQuests[0].name;
			m_rewardImage.sprite = completedQuests[0].reward.m_sprite;

			completedQuests[0].complete = true;
			completedQuests[0].reward.gameObject.SetActive(true);
			completedQuests[0].reward.m_obtained = true;

			completedQuests.Remove(completedQuests[0]);
		}
		else
		{
			m_reward.SetActive(false);
		}
		Debug.Log("Checked Again: " + completedQuests.Count);

	}
}
