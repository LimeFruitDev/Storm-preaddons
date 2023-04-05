using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Sandbox;

namespace Storm;

public partial class ItemData : BaseNetworkable, ICloneable
{
	[Net, JsonPropertyName( "uniqueId" )] public string UniqueId { get; set; }
	[Net, JsonPropertyName( "name" )] public string Name { get; set; }

	[Net, JsonPropertyName( "description" )]
	public string Description { get; set; }

	[Net, JsonPropertyName( "worldModel" )]
	public string WorldModel { get; set; }

	[Net, JsonPropertyName( "weight" )] public int Weight { get; set; }
	[Net, JsonPropertyName( "width" )] public int Width { get; set; }
	[Net, JsonPropertyName( "height" )] public int Height { get; set; }

	[Net, JsonPropertyName( "properties" )]
	public IDictionary<string, object> Properties { get; set; }

	[Net, JsonIgnore] public ItemInstance Instance { get; set; } = null;

	public object Clone()
	{
		ItemData itemData = new()
		{
			UniqueId = UniqueId,
			Name = Name,
			Description = Description,
			WorldModel = WorldModel,
			Weight = Weight,
			Width = Width,
			Height = Height
		};

		foreach ( var (key, value) in Properties )
		{
			itemData.Properties.Add( key, value );
		}

		return itemData;
	}

	public ItemData()
	{
		Name = "[Unknown]";
		Description = "[This item has not loaded correctly]";
		WorldModel = "models/error.vmdl";
		Weight = 1;
		Width = 1;
		Height = 1;
		Properties = new Dictionary<string, object>();
	}

	public void SetProperty( string key, object value )
	{
		Sandbox.Game.AssertServer();
		Properties[key] = value;
	}

	public object GetProperty( string key, object @default )
	{
		return Properties.ContainsKey( key ) ? Properties[key] : @default;
	}

	public T GetProperty<T>( string key, T @default )
	{
		return Properties.ContainsKey( key ) ? (T)Properties[key] : @default;
	}
}
