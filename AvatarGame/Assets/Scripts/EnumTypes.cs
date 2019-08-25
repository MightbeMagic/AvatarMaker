using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eTypes
{
	public enum eScore
	{
		F = -1,
		D = 0,
		C = 1,
		B = 2,
		A = 3,
		S = 4,
		SS = 5,
	}
	public enum eAttribute
	{
		HEART,
		STAR,
		LIKE,
		GEM,
		DISLIKE,
	}

	public enum eTrend
	{
		CUTE,
		ELEGANT,
		ACTIVE,
		NATURAL, 
		ROCK,
		FORMAL,
		ROMANTIC,
		FRILLY,
		ANGELIC,
		WEDDING,
		STARRY,
		SOFT
	}

	public enum ePartType
	{
		HAIR,
		FACE,
		TOPS,
		LEGS,
		FEET,
		MISC
	}

}
