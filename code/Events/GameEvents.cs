namespace Sandbox;

public static partial class StormEvent
{
	public static string Initialize = "Initialize";
	public static string Shutdown = "Shutdown";
	public static string PostLevelLoaded = "PostLevelLoaded";
	public static string RenderHud = "RenderHud";
	public static string ClientJoined = "ClientJoined";
	public static string ClientDisconnect = "ClientDisconnect";

	public class InitializeAttribute : EventAttribute
	{
		public InitializeAttribute() : base( Initialize ) { }
	}

	public class ShutdownAttribute : EventAttribute
	{
		public ShutdownAttribute() : base( Shutdown ) { }
	}

	public class PostLevelLoadedAttribute : EventAttribute
	{
		public PostLevelLoadedAttribute() : base( PostLevelLoaded ) { }
	}

	public class RenderHudAttribute : EventAttribute
	{
		public RenderHudAttribute() : base( RenderHud ) { }
	}

	public class ClientJoinedAttribute : EventAttribute
	{
		public ClientJoinedAttribute() : base( ClientJoined ) { }
	}

	public class ClientDisconnectAttribute : EventAttribute
	{
		public ClientDisconnectAttribute() : base( ClientDisconnect ) { }
	}
}
