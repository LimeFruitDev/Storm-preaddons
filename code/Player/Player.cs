using Sandbox;

namespace Storm;

public partial class Player : AnimatedEntity
{
	public string SteamName => Client.Name;
	public string SteamId => Client.SteamId.ToString();
	public bool IsAlive => LifeState == LifeState.Alive;
}
