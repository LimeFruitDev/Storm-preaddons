using System.Collections.Generic;
using Sandbox;

namespace Storm;

public partial class BaseFaction : BaseNetworkable
{
	[Net] public string UniqueId { get; set; }
	[Net] public string Name { get; set; }
	[Net] public string Description { get; set; }
	[Net] public bool IsWhitelisted { get; set; }
	[Net] public IList<string> Models { get; set; }
	[Net] public IList<Player> Players { get; set; }
}
