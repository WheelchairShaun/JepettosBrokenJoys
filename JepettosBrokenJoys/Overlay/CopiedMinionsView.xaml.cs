using Hearthstone_Deck_Tracker.Hearthstone;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace JepettosBrokenJoys.Overlay
{
	/// <summary>
	/// Interaction logic for CopiedMinionsView.xaml
	/// </summary>
	public partial class CopiedMinionsView : ItemsControl
	{
		public CopiedMinionsView()
		{
			InitializeComponent();
		}

		public void Update(ObservableCollection<Card> cards)
		{
			this.ItemsSource = cards;
		}

		public void SetPosition(double top = 25, double left = 280)
		{
			Canvas.SetTop(this, top);
			Canvas.SetLeft(this, left);
		}



		public void Hide()
		{
			this.Visibility = Visibility.Hidden;
		}

		public void Show()
		{
			this.Visibility = Visibility.Visible;
		}
	}
}
