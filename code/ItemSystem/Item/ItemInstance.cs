using Sandbox;

namespace Storm;

public partial class ItemInstance : BaseNetworkable
{
	[Net] public long UniqueId { get; set; }
	[Net] public ItemData Data { get; set; }
	[Net] public long InventoryId { get; set; }
	[Net] public ItemEntity Entity {get; set;}

	public string Type => Data.UniqueId;
	public string Name => Data.Name;
	public string Description => Data.Description;
	public string WorldModel => Data.WorldModel;
	public int Weight => Data.Weight;
}
