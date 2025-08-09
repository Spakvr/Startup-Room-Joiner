using System;
using BepInEx;
using GorillaNetworking;
using StartupRoomJoiner.CustomCode;
using static StartupRoomJoiner.CustomCode.Configmanager;
using UnityEngine;
using Utilla;

namespace StartupRoomJoiner
{

    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
	{
		string codetoJoin = Configmanager.codetoJoin.Value;

        void Start()
		{
            Configmanager.CreateConfig();
            

            Utilla.Events.GameInitialized += OnGameInitialized;
		}


		void OnGameInitialized(object sender, EventArgs e)
		{
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(codetoJoin.ToUpper(), JoinType.Solo);
        }
	}
}
