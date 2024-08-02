
namespace Sandbox
{
	public class PlayerState : Component
	{
		[HostSync] public Pawn Pawn { get; set; }

		protected override void OnUpdate()
		{
			base.OnUpdate();

			Log.Info( "PlayerState OnUpdate" );
			Log.Info( Network.OwnerConnection.DisplayName + " and his Pawn " + Pawn );
		}
	}
}
