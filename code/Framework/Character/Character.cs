using System.Collections.Generic;
using Sandbox;

namespace Storm;

public partial class Character : EntityComponent
{
	[Net] public long UniqueId { get; set; }
	[Net] public Player Player { get; set; }
	[Net] public new string Name { get; set; }
	[Net] public string Model { get; set; }
	[Net] public string Faction { get; set; }
	[Net] public IDictionary<string, object> Data { get; set; }

	public void SetData( string key, object value )
	{
		Sandbox.Game.AssertServer();
		Data[key] = value;
	}

	public object GetData( string key, object @default )
	{
		return Data.ContainsKey( key ) ? Data[key] : @default;
	}

	public T GetData<T>( string key, T @default )
	{
		return Data.ContainsKey( key ) ? (T)Data[key] : @default;
	}
}
