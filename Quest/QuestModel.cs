
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Quest
{
	public class QuestModel
	{
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("questName")]
		public string questName { get; set; }

		[JsonProperty("questReward")]
		public string questReward { get; set; }

		[JsonProperty("questDescription")]
		public string questDescription { get; set; }

		[JsonProperty("questContact")]
		public string questContact { get; set; }
	}
}

