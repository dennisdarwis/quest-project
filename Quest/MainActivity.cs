using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Quest
{
	[Activity(Label = "Quest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

			// Create Quest Button
			Button buttonCreateQuest = FindViewById<Button>(Resource.Id.buttonCreateQuest);

			//buttonCreateQuest.Click += delegate { Toast.MakeText(this, "Create Quest", ToastLength.Short).Show();};
			buttonCreateQuest.Click += delegate
			{
				var intent = new Intent(this, typeof(CreateQuestActivity));
				StartActivity(intent);};

			// Find Quest Button
			Button buttonFindQuest = FindViewById<Button>(Resource.Id.buttonFindQuest);

			buttonFindQuest.Click += delegate {
				var intent = new Intent(this, typeof(FindQuestActivity));
				StartActivity(intent);
			};
		}
	}
}


