using Sandbox.Network;

namespace Sandbox
{
	public class NetworkedLobby : Component, Component.INetworkListener
	{

		protected override void OnAwake()
		{
			base.OnAwake();

			if ( !GameNetworkSystem.IsActive )
			{
				GameNetworkSystem.CreateLobby();
			}

		}

		public void OnActive( Connection channel )
		{
			Log.Info( $"Player '{channel.DisplayName}' is becoming active (" + channel.Id + ")" );

			var goPlayer = new GameObject();
			goPlayer.Name = "Player";
			goPlayer.Parent = Game.ActiveScene;

			var playerState = goPlayer.Components.Create<PlayerState>();

			goPlayer.NetworkSpawn( channel );


			RefreshPawn();

		}

		public void RefreshPawn()
		{
			Log.Info( "RefreshPawn" );
			foreach ( var playerState in Game.ActiveScene.GetAllComponents<PlayerState>() )
			{
				if ( playerState.Pawn != null ) { continue; }

				var go = new GameObject();
				var pawn = go.Components.Create<Pawn>();

				playerState.Pawn = pawn;

				go.NetworkSpawn( playerState.Network.OwnerConnection );
			}
		}
	}
}
