
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

namespace Quest
{
	[Activity(Label = "CreateQuestActivity")]
	public class CreateQuestActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.CreateQuest);

			// Create your application here
			EditText questName = FindViewById<EditText>(Resource.Id.questName);
			EditText questReward = FindViewById<EditText>(Resource.Id.questReward);
			EditText questDescription = FindViewById<EditText>(Resource.Id.questDescription);
			EditText contactAndInformation = FindViewById<EditText>(Resource.Id.contactAndInformation);

			Button buttonCreateQuest = FindViewById<Button>(Resource.Id.buttonCreateQuest);
			buttonCreateQuest.Click += delegate
			{
				string result = String.Format("{0}'quest name': '{1}', 'quest reward': '{2}', 'quest description': '{3}', 'contact': '{4}' {5}",
											  "{", questName.Text, questReward.Text, questDescription.Text, contactAndInformation.Text, "}");
				result = result.Replace("'", "\"");
				Toast.MakeText(this, result, ToastLength.Short).Show();
				Console.WriteLine(result);
			};

		}
	}
}

