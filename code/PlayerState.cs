
namespace Sandbox
{
	public class PlayerState : Component
	{
		[HostSync] public Pawn Pawn { get; set; }

		public TimeUntil TimeUntilUpdate { get; set; } = 1f;
		public TimeUntil TimeUntilRefresh { get; set; } = 10f;

		protected override void OnUpdate()
		{
			base.OnUpdate();

			if (!TimeUntilUpdate ) { return; }
			TimeUntilUpdate = 1f;

			Log.Info( "PlayerState OnUpdate" );
			Log.Info( Network.OwnerConnection.DisplayName + " and his Pawn " + Pawn );

			if (!TimeUntilRefresh  ) { return; }
			TimeUntilRefresh = 10f;

			Log.Info( "PlayerState GonnaRefresh" );

			Network.Refresh();
		}
	}
}
