using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox;

namespace Storm;

public partial class BaseInventory : BaseNetworkable
{
	/// <summary>
	///     The type of the inventory in question, such as player, container, et cetera.
	/// </summary>
	[Net]
	public string Type { get; set; }

	/// <summary>
	///     The unique identifier of the inventory in the database.
	/// </summary>
	[Net]
	public long UniqueId { get; set; }

	/// <summary>
	///     The items contained by this inventory.
	/// </summary>
	[Net]
	public IList<ItemInstance> Items { get; set; }

	/// <summary>
	///     Returns the list of items contained within this inventory of the given type.
	/// </summary>
	/// <param name="type">The type of the item.</param>
	/// <returns>The items contained in the inventory with of given type.</returns>
	public IEnumerable<ItemInstance> GetItemsOfType( string type )
	{
		return Items.Where( item => item.Type == type );
	}

	/// <summary>
	///     Returns the list of items contained within this inventory which pass the given filter.
	/// </summary>
	/// <param name="filter">The filter that defines which items will be returned.</param>
	/// <returns>The items contained in the inventory which pass the given filter.</returns>
	public IEnumerable<ItemInstance> FilterItems( Func<ItemInstance, bool> filter )
	{
		return Items.Where( filter );
	}

	/// <summary>
	///     Checks whether or not the inventory contains an item of the given type.
	/// </summary>
	/// <param name="type">The type to look for.</param>
	/// <returns>The item if found, otherwise null.</returns>
	public ItemInstance HasItem( string type )
	{
		return GetItemsOfType( type ).FirstOrDefault();
	}

	/// <summary>
	///     Checks whether or not the inventory contains an item.
	/// </summary>
	/// <param name="item">The item to look for.</param>
	/// <returns>The item if found, otherwise null</returns>
	public ItemInstance HasItem( ItemInstance item )
	{
		return FilterItems( inventoryItem => inventoryItem.UniqueId == item.UniqueId ).FirstOrDefault();
	}

	/// <summary>
	///     Adds an item of the given type to the inventory.
	/// </summary>
	/// <param name="type">The item type to add to the inventory.</param>
	/// <returns>The created instance.</returns>
	public async Task<ItemInstance> AddItem( string type )
	{
		return await ItemManager.Instance.CreateItem( type );
	}

	/// <summary>
	///     Adds an item to the inventory.
	/// </summary>
	/// <param name="item">The item to add.</param>
	/// <returns>The created instance.</returns>
	public bool AddItem( ItemInstance item )
	{
		if ( item.InventoryId != ItemManager.WorldInventoryId )
		{
			// todo: take the inventory from the ItemManager
			var inventory = ItemManager.Instance.Inventories[item.InventoryId];
			if ( !inventory.RemoveItem( item ) )
			{
				ItemManager.Log.Warning(
					$"Failed to add item {item.UniqueId} into inventory {inventory.UniqueId} because it could not be removed from inventory {UniqueId}" );
				return false;
			}
		}

		Items.Add( item );
		item.InventoryId = UniqueId;
		return true;
	}

	/// <summary>
	///     Removes an item from the inventory.
	/// </summary>
	/// <param name="type">The type of the item to remove</param>
	/// <param name="item">The removed item instance.</param>
	/// <returns>True if the item was successfully removed, false otherwise.</returns>
	public bool RemoveItem( string type, out ItemInstance item )
	{
		var itemInstance = HasItem( type );
		if ( !RemoveItem( itemInstance ) )
		{
			item = null;
			return false;
		}

		item = itemInstance;
		return true;
	}

	/// <summary>
	///     Removes an item from the inventory.
	/// </summary>
	/// <param name="item">The item to remove.</param>
	/// <returns>True if the item was successfully removed, false otherwise.</returns>
	public bool RemoveItem( ItemInstance item )
	{
		throw new NotImplementedException();
	}

	/// <summary>
	///     Deletes an item from the inventory.
	/// </summary>
	/// <param name="type">The type of the item to delete.</param>
	/// <returns>True if the item was successfully deleted, false otherwise.</returns>
	public bool DeleteItem( string type )
	{
		return RemoveItem( type, out var item ) && DeleteItem( item );
	}

	/// <summary>
	///     Deletes an item from the inventory.
	/// </summary>
	/// <param name="item">The item to delete.</param>
	/// <returns>True if the item was successfully deleted, false otherwise.</returns>
	public bool DeleteItem( ItemInstance item )
	{
		throw new NotImplementedException();
	}
}
