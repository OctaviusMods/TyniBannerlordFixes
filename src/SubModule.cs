﻿using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;

namespace ExperiencePerkFix
{
	public class SubModule : MBSubModuleBase
	{
		protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
		{
			base.OnGameStart(game, gameStarterObject);
			AddBehaviours(gameStarterObject as CampaignGameStarter);
		}

		private void AddBehaviours(CampaignGameStarter gameStarterObject)
		{
			if (gameStarterObject != null)
			{
				gameStarterObject.AddBehavior(new MobilePartyDailyTickBehaviour());
				gameStarterObject.AddBehavior(new TownDailyTickBehaviour());
			}
		}

	}
}