namespace Storm;

/// <summary>
/// This class calls some of the "event" methods on the Schema to make it easier.
/// </summary>
public static class SchemaEventCaller
{
	[Event.Initialize]
	public static void Initialize()
	{
		BaseSchema.Instance.Initialize();
	}

	[Event.Initialize.Server]
	public static void InitializeServer()
	{
		BaseSchema.Instance.InitializeServer();
	}

	[Event.Initialize.Client]
	public static void InitializeClient()
	{
		BaseSchema.Instance.InitializeClient();
	}

	[Event.Shutdown]
	public static void Shutdown()
	{
		BaseSchema.Instance.Shutdown();
	}

	[Event.Shutdown.Server]
	public static void ShutdownServer()
	{
		BaseSchema.Instance.ShutdownServer();
	}

	[Event.Shutdown.Client]
	public static void ShutdownClient()
	{
		BaseSchema.Instance.ShutdownClient();
	}
}
