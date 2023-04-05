using Sandbox;
using Sandbox.Diagnostics;

namespace Storm;

public partial class Game : GameManager
{
	public static Logger Log = new("Storm");
	public static Game Instance => (Game)Current;

	public Game()
	{
		// NOTE: This needs to run before Initialize so that the schema can get the event
		SchemaLoader.LoadSchema();

		Sandbox.Event.Run( "Storm.Initialize" );
		Sandbox.Event.Run( Sandbox.Game.IsServer ? "Storm.Initialize.Server" : "Storm.Initialize.Client" );
	}

	public override void Shutdown()
	{
		Sandbox.Event.Run( "Storm.Shutdown" );
		Sandbox.Event.Run( Sandbox.Game.IsServer ? "Storm.Shutdown.Server" : "Storm.Shutdown.Client" );

		base.Shutdown();
	}

	public override void PostLevelLoaded()
	{
		Sandbox.Event.Run( "Storm.PostLevelLoaded" );

		base.PostLevelLoaded();
	}

	public override void RenderHud()
	{
		Sandbox.Event.Run( "Storm.RenderHud" );

		base.RenderHud();
	}

	public override void ClientJoined( IClient client )
	{
		Sandbox.Event.Run( "Storm.ClientJoined", client );

		base.ClientJoined( client );
	}

	public override void ClientDisconnect( IClient client, NetworkDisconnectionReason reason )
	{
		Sandbox.Event.Run( "Storm.ClientDisconnect", client, reason );

		if ( reason != NetworkDisconnectionReason.DISCONNECT_BY_USER )
		{
			var reasonId = ((int)reason).ToString( "X8" );
			Log.Warning(
				$"Client {client.Name}(${client.SteamId}) was disconnected with reason: {reason.GetName()} (0x{reasonId})." );
		}

		base.ClientDisconnect( client, reason );
	}
}
