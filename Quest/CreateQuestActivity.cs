
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

namespace Quest
{
	[Activity(Label = "CreateQuestActivity")]
	public class CreateQuestActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.CreateQuest);
			string JSONString;

			// Create your application here
			EditText questName = FindViewById<EditText>(Resource.Id.questName);
			EditText questReward = FindViewById<EditText>(Resource.Id.questReward);
			EditText questDescription = FindViewById<EditText>(Resource.Id.questDescription);
			EditText questContact = FindViewById<EditText>(Resource.Id.questContact);

			Button buttonCreateQuest = FindViewById<Button>(Resource.Id.buttonCreateQuest);
			buttonCreateQuest.Click += delegate
			{
				JSONString = "{\"resource\": [{" +
				                                  "\"questName\": \""+questName.Text+"\"," +
				                                  "\"questReward\": \""+questReward.Text+"\"," +
				                                  "\"questDescription\": \""+questDescription.Text+"\"," +
				                                  "\"questContact\": \""+questContact.Text+"\"}]}";
				string url = "http://104.199.155.15/api/v2/db/_table/quest";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Method = "POST";
				request.Headers.Add("X-DreamFactory-Api-Key", "be8387a7b036ea65deb04d1a20d85e619b7e1634aa55b1cf6cc3988f130a2e81");
				request.Headers.Add("X-DreamFactory-Session-Token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjIsInVzZXJfaWQiOjIsImVtYWlsIjoicHVibGljQHB1YmxpYy5jb20iLCJmb3JldmVyIjp0cnVlLCJpc3MiOiJodHRwOlwvXC8xMDQuMTk5LjE1NS4xNVwvYXBpXC92MlwvdXNlclwvc2Vzc2lvbiIsImlhdCI6MTQ3MDMyOTY2MCwiZXhwIjoxNDcwMzcyODYwLCJuYmYiOjE0NzAzMjk2NjAsImp0aSI6IjMzOGVlMDdjY2E4NjAyYjAzY2YzN2YyZDVkNDY1M2U1In0.AxEGI08WsP4PLNUed_EDP4J2J8Pl5U7V5-53DrxVH3g");
				request.ContentType = "application/json";
				var list = new string[] { questName.Text, questReward.Text, questDescription.Text, questContact.Text };
				if (list.Contains(""))
				{
					Toast.MakeText(this, "Please fill the empty form", ToastLength.Long).Show();
				}
				else {
					using (var streamWriter = new StreamWriter(request.GetRequestStream()))
					{
						streamWriter.Write(JSONString);
						streamWriter.Flush();
						streamWriter.Close();
					}

					var httpResponse = (HttpWebResponse)request.GetResponse();


					using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
					{
						Toast.MakeText(this, "Quest successfully created", ToastLength.Long).Show();
						OnBackPressed();
					}

				}
			};

		}
		public override void OnBackPressed()
		{
			var intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
		}
	}
}

