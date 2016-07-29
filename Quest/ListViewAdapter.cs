
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
	public class ListViewAdapter : BaseAdapter<QuestModel>
	{
		private List<QuestModel> mItems;
		private Context mContext;

		public ListViewAdapter(Context context, List<QuestModel> items)
		{
			mItems = items;
			mContext = context;
		}
		public override int Count
		{
			get
			{
				return mItems.Count;
			}
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override QuestModel this[int position]
		{
			get
			{
				return mItems[position];
			}
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = convertView;

			if (row == null)
			{
				row = LayoutInflater.From(mContext).Inflate(Resource.Layout.ListViewRow, null, false);
			}

			TextView questName = row.FindViewById<TextView>(Resource.Id.questName);
			questName.Text = mItems[position].questName;

			TextView questReward = row.FindViewById<TextView>(Resource.Id.questReward);
			questReward.Text = mItems[position].questReward;

			return row;
		}
	}
}

