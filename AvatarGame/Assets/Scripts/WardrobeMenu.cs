using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WardrobeMenu : MonoBehaviour
{

	[SerializeField] Button m_hairToggle;
	[SerializeField] Button m_faceToggle;
	[SerializeField] Button m_topsToggle;
	[SerializeField] Button m_legsToggle;
	[SerializeField] Button m_feetToggle;
	[SerializeField] Button m_miscToggle;

	[SerializeField] GameObject m_hairTab;
	[SerializeField] GameObject m_faceTab;
	[SerializeField] GameObject m_topsTab;
	[SerializeField] GameObject m_legsTab;
	[SerializeField] GameObject m_feetTab;
	[SerializeField] GameObject m_miscTab;

	[SerializeField] public RawImage m_previewSprite;
	[SerializeField] public TextMeshProUGUI m_previewName;

	[SerializeField] public TextMeshProUGUI m_previewHeart;
	[SerializeField] public TextMeshProUGUI m_previewStar;
	[SerializeField] public TextMeshProUGUI m_previewLike;
	[SerializeField] public TextMeshProUGUI m_previewGem;
	[SerializeField] public TextMeshProUGUI m_attribute;

	public static WardrobeMenu m_instance;
	// Use this for initialization
	void Start()
	{
		m_instance = this;
		SetAllButtonsInactive();
		m_hairToggle.interactable = false;
		m_hairTab.SetActive(true);
	}

	public void SetAllButtonsInactive()
	{
		m_hairToggle.interactable = true;
		m_faceToggle.interactable = true;
		m_topsToggle.interactable = true;
		m_legsToggle.interactable = true;
		m_feetToggle.interactable = true;
		m_miscToggle.interactable = true;

		m_hairTab.SetActive(false);
		m_faceTab.SetActive(false);
		m_topsTab.SetActive(false);
		m_legsTab.SetActive(false);
		m_feetTab.SetActive(false);
		m_miscTab.SetActive(false);
	}

	public void OpenHairTab()
	{
		SetAllButtonsInactive();
		m_hairToggle.interactable = false;
		m_hairTab.SetActive(true);
	}

	public void OpenFaceTab()
	{
		SetAllButtonsInactive();
		m_faceToggle.interactable = false;
		m_faceTab.SetActive(true);
	}

	public void OpenTopsTab()
	{
		SetAllButtonsInactive();
		m_topsToggle.interactable = false;
		m_topsTab.SetActive(true);
	}

	public void OpenLegsTab()
	{
		SetAllButtonsInactive();
		m_legsToggle.interactable = false;
		m_legsTab.SetActive(true);
	}

	public void OpenFeetTab()
	{
		SetAllButtonsInactive();
		m_feetToggle.interactable = false;
		m_feetTab.SetActive(true);
	}

	public void OpenMiscTab()
	{
		SetAllButtonsInactive();
		m_miscToggle.interactable = false;
		m_miscTab.SetActive(true);
	}
}
