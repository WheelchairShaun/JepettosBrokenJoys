using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using JepettosBrokenJoys.Overlay;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Core = Hearthstone_Deck_Tracker.API.Core;

namespace JepettosBrokenJoys
{
	internal class BrokenJoys : IDisposable
	{
		private const string JEPETTO = "Joymancer Jepetto";
		private CopiedMinionsView _minionsView = null;
		private ObservableCollection<Card> _minions = null;

		public BrokenJoys()
		{
			_minions = new ObservableCollection<Card>();
			_minionsView = new CopiedMinionsView();
			_minionsView.Hide();
		}

		internal void OnGameStart()
		{
			var activeDeck = DeckList.Instance.ActiveDeck.Cards;

			if (activeDeck.Any(c => c.Name == JEPETTO))
			{
				_minionsView?.SetPosition();
				_minionsView.Update(_minions);

				Core.OverlayCanvas.Children.Add(_minionsView);
			}
		}

		internal void OnGameEnd()
		{
			Core.OverlayCanvas?.Children.Remove(_minionsView);
		}

		internal void OnPlayerPlay(Card card)
		{
			if (card.Type == "Minion" && (card.Health == 1 || card.Attack == 1))
			{
				_minions.Add(card);
			}
		}

		internal void OnPlayerHandMouseOver(Card card)
		{
			if (card?.Name == JEPETTO)
			{
				_minionsView?.Show();
			}
		}

		public void Dispose()
		{
			_minionsView = null;
		}

		internal void OnMouseOverOff()
		{
			if (_minionsView.IsVisible)
			{
				_minionsView.Hide();
			}
		}
	}
}
