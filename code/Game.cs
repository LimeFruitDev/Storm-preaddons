namespace Sandbox;

public partial class StormGame : GameManager
{
	public static StormGame Instance => (StormGame)Current;

	public StormGame()
	{
		Event.Run( StormEvent.Initialize );
	}

	public override void Shutdown()
	{
		Event.Run( StormEvent.Shutdown );

		base.Shutdown();
	}

	public override void PostLevelLoaded()
	{
		Event.Run( StormEvent.PostLevelLoaded );

		base.PostLevelLoaded();
	}

	public override void RenderHud()
	{
		Event.Run( StormEvent.RenderHud );

		base.RenderHud();
	}

	public override void ClientJoined( IClient client )
	{
		Event.Run( StormEvent.ClientJoined, client );

		base.ClientJoined( client );
	}

	public override void ClientDisconnect( IClient client, NetworkDisconnectionReason reason )
	{
		Event.Run( StormEvent.ClientDisconnect, client, reason );

		base.ClientDisconnect( client, reason );
	}
}
