using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eTypes;
using UnityEngine;

namespace eTypes
{
	public class Trend
	{
		string m_description;
		eTrend m_name;
		eAttribute m_mainAttribute;
		eAttribute m_secondaryAttribute;
		public string Description { get { return m_description; } set { } }
		public eTrend Name { get { return m_name; } set { } }
		public eAttribute MainAttribute { get { return m_mainAttribute; } set { } }
		public eAttribute SecondaryAttribute { get { return m_secondaryAttribute; } set { } }

		public Sprite TX_attribute;
		public Sprite TX_set;


		public Trend(eTrend name, eAttribute mainAttribute, eAttribute secondaryAttribute, string description)
		{
			m_name = name;
			m_mainAttribute = mainAttribute;
			m_secondaryAttribute = secondaryAttribute;
			m_description = "OMG! so much " + mainAttribute + "!!!1!";
		}

		public Trend(eTrend name, eAttribute mainAttribute, eAttribute secondaryAttribute, Sprite set, Sprite icon)
		{
			m_name = name;
			m_mainAttribute = mainAttribute;
			m_secondaryAttribute = secondaryAttribute;
			m_description = "OMG! so much " + name.ToString() + " potential!!!1!";
			TX_set = set;
			TX_attribute = icon;
		}

		public int ReturnScore(int heart, int gem, int like, int star)
		{
			//float score = (heart * 0.5f) + (gem * 0.5f) + (like * 0.5f) + (star * 0.5f);
			float H = heart * 0.5f;
			float G = gem * 0.5f;
			float L = like * 0.5f;
			float S = star * 0.5f;
			switch (m_mainAttribute)
			{
				case eAttribute.HEART:
					H += heart * 2;
					if (heart <= 0) H -= 5;
					break;
				case eAttribute.STAR:
					S += star * 2;
					if (star <= 0) S -= 5;
					break;
				case eAttribute.LIKE:
					L += like * 2;
					if (like <= 0) L -= 5;
					break;
				case eAttribute.GEM:
					G += gem * 2;
					if (gem <= 0) G -= 5;
					break;
			}

			switch (m_secondaryAttribute)
			{
				case eAttribute.HEART:
					H += heart * 1;
					if (heart <= 0) H -= 2;
					break;
				case eAttribute.STAR:
					S += star * 1;
					if (star <= 0) S -= 2;
					break;
				case eAttribute.LIKE:
					L += like * 1;
					if (like <= 0) L -= 2;
					break;
				case eAttribute.GEM:
					G += gem * 1;
					if (gem <= 0) G -= 2;
					break;
			}
			Game.m_instance.m_player.hearts_currency += (int)H < 0 ? 0 : (int)H;
			Game.m_instance.m_player.stars_currency += (int)S < 0 ? 0 : (int)S;
			Game.m_instance.m_player.gems_currency += (int)G < 0 ? 0 : (int)G;
			Game.m_instance.m_player.likes_currency += (int)L < 0 ? 0 : (int)L;
			Player.m_instance.UpdateCurrency();

			return (int)(H + S + L + G);
		}

		public static List<Trend> GenerateTrends()
		{
			List<Trend> result = new List<Trend>();

			result.Add(new Trend(eTrend.ACTIVE, eAttribute.LIKE, eAttribute.HEART, Game.m_instance.m_sets[0], Game.m_instance.attributeSymbols[1]));
			result.Add(new Trend(eTrend.ROCK, eAttribute.LIKE, eAttribute.STAR, Game.m_instance.m_sets[1], Game.m_instance.attributeSymbols[3]));
			result.Add(new Trend(eTrend.FORMAL, eAttribute.LIKE, eAttribute.GEM, Game.m_instance.m_sets[2], Game.m_instance.attributeSymbols[2]));

			result.Add(new Trend(eTrend.CUTE, eAttribute.HEART, eAttribute.LIKE, Game.m_instance.m_sets[3], Game.m_instance.attributeSymbols[0]));
			result.Add(new Trend(eTrend.ROMANTIC, eAttribute.HEART, eAttribute.STAR, Game.m_instance.m_sets[4], Game.m_instance.attributeSymbols[3]));
			result.Add(new Trend(eTrend.FRILLY, eAttribute.HEART, eAttribute.GEM, Game.m_instance.m_sets[5], Game.m_instance.attributeSymbols[2]));

			result.Add(new Trend(eTrend.ANGELIC, eAttribute.GEM, eAttribute.STAR, Game.m_instance.m_sets[6], Game.m_instance.attributeSymbols[3]));
			result.Add(new Trend(eTrend.ELEGANT, eAttribute.GEM, eAttribute.LIKE, Game.m_instance.m_sets[7], Game.m_instance.attributeSymbols[0]));
			result.Add(new Trend(eTrend.WEDDING, eAttribute.GEM, eAttribute.HEART, Game.m_instance.m_sets[8], Game.m_instance.attributeSymbols[1]));

			result.Add(new Trend(eTrend.STARRY, eAttribute.STAR, eAttribute.GEM, Game.m_instance.m_sets[9], Game.m_instance.attributeSymbols[2]));
			result.Add(new Trend(eTrend.NATURAL, eAttribute.STAR, eAttribute.LIKE, Game.m_instance.m_sets[10], Game.m_instance.attributeSymbols[0]));
			result.Add(new Trend(eTrend.SOFT, eAttribute.STAR, eAttribute.HEART, Game.m_instance.m_sets[11], Game.m_instance.attributeSymbols[1]));

			return result;
		}
	}
}
