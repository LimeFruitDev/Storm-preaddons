using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.Diagnostics;

namespace Storm;

public partial class ItemManager : Entity
{
	public const long WorldInventoryId = -1;

	public static ItemManager Instance { get; private set; }
	public static Logger Log { get; } = new("ItemManager");

	[Net] public IDictionary<long, BaseInventory> Inventories { get; set; }
	[Net] public IDictionary<string, ItemData> ItemDatabase { get; set; }
	[Net] public IDictionary<long, ItemInstance> ItemInstances { get; set; }

	// NOTE: This is actually auto-called on the server but manually called on the client!
	[Event.Initialize.Server]
	public static void Initialize()
	{
		if ( Instance?.IsValid() ?? false )
		{
			return;
		}

		Instance = Sandbox.Game.IsServer ? new ItemManager() : All.OfType<ItemManager>().First();
		if ( !Instance.IsValid() )
		{
			Log.Error( "Initialization failed!" );
		}
	}

	public ItemManager()
	{
		Transmit = TransmitType.Always;
		Tags.Add( "system" );
	}

	public override void Spawn()
	{
		Log.Info( "ItemManager is spawning in this instance!" );
		base.Spawn();

		if ( !Sandbox.Game.IsServer )
		{
			Instance ??= this;
			return;
		}

		Inventories = new Dictionary<long, BaseInventory>();
		ItemDatabase = new Dictionary<string, ItemData>();
		ItemInstances = new Dictionary<long, ItemInstance>();
	}

	public override void ClientSpawn()
	{
		Initialize();
		base.ClientSpawn();
	}

	public async Task<long> CreateInventory( string type )
	{
		throw new NotImplementedException();
	}

	public async Task<ItemInstance> CreateItem( string type )
	{
		throw new NotImplementedException();
	}
}
