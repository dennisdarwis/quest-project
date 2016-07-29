using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Quest
{
	[Activity(Label = "CreateQuest")]
	public class CreateQuest : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.CreateQuestActivity);


			// Create your application here
		}
	}
}

