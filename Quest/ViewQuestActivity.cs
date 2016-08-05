
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
	[Activity(Label = "ViewQuestActivity")]
	public class ViewQuestActivity : Activity
	{
		private List<QuestModel> mItems;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.ViewQuest);

			int id = Intent.GetIntExtra("id", 6);

			string url = "http://104.199.155.15/api/v2/db/_table/quest/"+id.ToString();
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.Headers.Add("X-DreamFactory-Api-Key", "be8387a7b036ea65deb04d1a20d85e619b7e1634aa55b1cf6cc3988f130a2e81");
			request.Headers.Add("X-DreamFactory-Session-Token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjIsInVzZXJfaWQiOjIsImVtYWlsIjoicHVibGljQHB1YmxpYy5jb20iLCJmb3JldmVyIjp0cnVlLCJpc3MiOiJodHRwOlwvXC8xMDQuMTk5LjE1NS4xNVwvYXBpXC92MlwvdXNlclwvc2Vzc2lvbiIsImlhdCI6MTQ3MDM4MzczMCwiZXhwIjoxNTAxOTE5NzMwLCJuYmYiOjE0NzAzODM3MzAsImp0aSI6ImFlZWQ3YWRhYmI4N2I0ODBhNmIyYWRlYWM0YzQzZTU0In0.J35hKt384v25G3ylb547w0OAlJ4yYGWRxhknwm5sYhg");
			request.ContentType = "application/json";
			//HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
			string JSONString;
			using (var response = request.GetResponse())
			{
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					JSONString = "["+reader.ReadToEnd()+"]";
					Console.WriteLine("response: "+JSONString);
				}
			}
			mItems = JsonConvert.DeserializeObject<List<QuestModel>>(JSONString);

			TextView questName = (TextView)FindViewById<TextView>(Resource.Id.questName);
			questName.Text = mItems[0].questName;

			TextView questReward = (TextView)FindViewById<TextView>(Resource.Id.questReward);
			questReward.Text = mItems[0].questReward;

			TextView questDescription = (TextView)FindViewById<TextView>(Resource.Id.questDescription);
			questDescription.Text = mItems[0].questDescription;

			TextView questContact= (TextView)FindViewById<TextView>(Resource.Id.questContact);
			questContact.Text = mItems[0].questContact;
		}
	}
}

