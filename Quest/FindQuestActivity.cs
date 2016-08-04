
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

			string url = "http://104.199.155.15/api/v2/db/_table/quest";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.Headers.Add ("X-DreamFactory-Api-Key","be8387a7b036ea65deb04d1a20d85e619b7e1634aa55b1cf6cc3988f130a2e81");
			request.Headers.Add("X-DreamFactory-Session-Token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjIsInVzZXJfaWQiOjIsImVtYWlsIjoicHVibGljQHB1YmxpYy5jb20iLCJmb3JldmVyIjpmYWxzZSwiaXNzIjoiaHR0cDpcL1wvMTA0LjE5OS4xNTUuMTVcL2FwaVwvdjJcL3VzZXJcL3Nlc3Npb24iLCJpYXQiOjE0NzAzMjA1NDAsImV4cCI6MTQ3MDMyNDE0MCwibmJmIjoxNDcwMzIwNTQwLCJqdGkiOiI3MmNiZjk0NzA0MWMwYWQyMzYyM2YzMjkzMzVmNzQ2OCJ9.KBKZ0z4NUOMrkVUNF8vE_-I2_7SrR1aGrShwSJDHXsE");
			request.ContentType = "application/json";
			HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
			string JSONString;
			using (var response = request.GetResponse())
			{
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					JSONString = reader.ReadToEnd();
				}
			}
			/*
			string JSONString = "{\n  \"resource\": [\n    {\n      \"id\": 1,\n      " +
				"\"questName\": \"Find me pizza\",\n      \"questReward\": \"20AUD+1 Slice of pizza\",\n      " +
				"\"questDescription\": \"Pizzahut pls\",\n      " +
				"\"questContact\": \"123/456 Road Rd\"\n    },\n    {\n      " +
				"\"id\": 2,\n      \"questName\": \"Eradicate spiders\",\n      " +
				"\"questReward\": \"50AUD+Lunch\",\n      " +
				"\"questDescription\": \"Lots of nopes and nopelings\",\n      " +
				"\"questContact\": \"Spidercave\"\n    }\n  ]\n}";
				*/


			//Console.WriteLine("ahsu: " + JSONString.TrimEnd('}').TrimStart('{').Substring(14));
			JSONString = JSONString.TrimEnd('}').TrimStart('{').Substring(11);
			Console.WriteLine("response: " + JSONString);
			// Create your application here
			mItems = JsonConvert.DeserializeObject<List<QuestModel>>(JSONString);
			ListViewAdapter adapter = new ListViewAdapter(this, mItems);
			mListView.Adapter = adapter;
			mListView.ItemClick += mListView_itemClick;
		}

		void mListView_itemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Toast.MakeText(this, mItems[e.Position].questName + " " + mItems[e.Position].id, ToastLength.Short).Show();
			Console.WriteLine(mItems[e.Position].questName+" "+mItems[e.Position].id);
		}
}
}

