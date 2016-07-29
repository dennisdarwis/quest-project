
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
	[Activity(Label = "FindQuestActivity")]
	public class FindQuestActivity : Activity
	{
		private List<QuestModel> mItems;
		private ListView mListView;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.FindQuest);
			mListView = FindViewById<ListView>(Resource.Id.questList);

			// Create your application here
			mItems = new List<QuestModel>();
			mItems.Add(new QuestModel() { questName = "Lawn Mowing", questReward = "30AUD", id = 0});
			mItems.Add(new QuestModel() { questName = "Find Mewtwo", questReward = "Thank you letter", id = 1});
			ListViewAdapter adapter = new ListViewAdapter(this, mItems);
			mListView.Adapter = adapter;
			mListView.ItemClick += mListView_itemClick;
		}

		void mListView_itemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Toast.MakeText(this, mItems[e.Position].questName + " " + mItems[e.Position], ToastLength.Short).Show();
			Console.WriteLine(mItems[e.Position].questName+" "+mItems[e.Position].id);
		}
}
}

