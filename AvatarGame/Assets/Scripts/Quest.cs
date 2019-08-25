using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace eTypes
{
	public class Quest
	{
		public string name;
		public string description;
		public bool complete;
		public INV_Clothing reward;

		public int requirement;

		public Quest(string n, string d, INV_Clothing r, int req)
		{
			complete = false;
			name = n;
			description = d;
			reward = r;
			requirement = req;
		}
	}
}
