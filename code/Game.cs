using Sandbox;
using Sandbox.Diagnostics;

namespace Storm;

public partial class Game : GameManager
{
	public static Logger Log = new("Storm");
	public static Game Instance => (Game)Current;

	public Game()
	{
		Sandbox.Event.Run( Event.Initialize );
	}

	public override void Shutdown()
	{
		Sandbox.Event.Run( Event.Shutdown );

		base.Shutdown();
	}

	public override void PostLevelLoaded()
	{
		Sandbox.Event.Run( Event.PostLevelLoaded );

		base.PostLevelLoaded();
	}

	public override void RenderHud()
	{
		Sandbox.Event.Run( Event.RenderHud );

		base.RenderHud();
	}

	public override void ClientJoined( IClient client )
	{
		Sandbox.Event.Run( Event.ClientJoined, client );

		base.ClientJoined( client );
	}

	public override void ClientDisconnect( IClient client, NetworkDisconnectionReason reason )
	{
		Sandbox.Event.Run( Event.ClientDisconnect, client, reason );

		if ( reason != NetworkDisconnectionReason.DISCONNECT_BY_USER )
		{
			var reasonId = ((int)reason).ToString( "X8" );
			Log.Warning(
				$"Client {client.Name}(${client.SteamId}) was disconnected with reason: {reason.GetName()} (0x{reasonId})." );
		}

		base.ClientDisconnect( client, reason );
	}
}
