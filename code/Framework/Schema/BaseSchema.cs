using System;
using Sandbox;
using Sandbox.Diagnostics;

namespace Storm;

public partial class BaseSchema : Entity
{
	public static BaseSchema Instance { get; protected set; }
	public static Logger Log { get; } = new("Schema");
	[Net] public SchemaDetails Details { get; set; }

	public BaseSchema()
	{
		Transmit = TransmitType.Always;
		Instance = this;

		LoadDetails();
	}

	public virtual void Initialize() { }
	public virtual void InitializeServer() { }
	public virtual void InitializeClient() { }
	public virtual void Shutdown() { }
	public virtual void ShutdownServer() { }
	public virtual void ShutdownClient() { }

	private void LoadDetails()
	{
		if ( Details != null )
		{
			Log.Warning(
				"BaseSchema.LoadDetails called when details field is already populated, reloading from disk!" );
		}

		try
		{
			Details = FileSystem.Data.ReadJson<SchemaDetails>( "schema.json" );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Failed to load schema details from disk!" );
		}
	}
}
