
using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace DeathItemDrops
{
    public class DeathItemDrops : RocketPlugin<DeathItemDropsConfiguration>
    {
        public static DeathItemDrops Instance;
        private List<CSteamID> unturnedPlayers;
        
        protected override void Load()
        {
            Instance = this;
            unturnedPlayers = new List<CSteamID>();
            Logger.Log("Plugin By EnvyHosting");
            UnturnedPlayerEvents.OnPlayerDead += UnturnedPlayerEvents_OnPlayerDead;
        }

        private void UnturnedPlayerEvents_OnPlayerDead(UnturnedPlayer player, Vector3 position)
        {
            if (!unturnedPlayers.Contains(player.CSteamID)){
                unturnedPlayers.Add(player.CSteamID);
                foreach (var item in Configuration.Instance.Items)
                {
                    if(item.Permission == null || item.Permission == " " || item.Permission == "")
                    {
                        
                        player.GiveItem(item.Id, item.Amount); player.Player.equipment.dequip();
                    }
                    else
                    {
                        if (player.HasPermission(item.Permission)) { player.GiveItem(item.Id, item.Amount); player.Player.equipment.dequip(); }
                    }
                }

                StartCoroutine(Remover(player.CSteamID)); 

            }
        }

        private IEnumerator<WaitForSeconds> Remover(CSteamID playerId)
        {
            yield return new WaitForSeconds(Configuration.Instance.Interval);
            unturnedPlayers.Remove(playerId);
        }

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDead -= UnturnedPlayerEvents_OnPlayerDead;
        }
    }
}
