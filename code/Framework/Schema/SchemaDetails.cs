using Sandbox;

namespace Storm;

public partial class SchemaDetails : BaseNetworkable
{
	[Net] public string Name { get; set; }
	[Net] public string Author { get; set; }
	[Net] public string Description { get; set; }
}
