using Sandbox;

namespace Storm;

public partial class StormGame : GameManager
{
	public static StormGame Instance => (StormGame)Current;

	public StormGame()
	{
	}

	public override void ClientJoined( IClient client )
	{
		base.ClientJoined( client );
	}
}
