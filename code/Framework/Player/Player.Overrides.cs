using Sandbox;

namespace Storm;

public partial class Player
{
	public override void Spawn()
	{
		EnableLagCompensation = true;
		Tags.Add( "player" );

		base.Spawn();
	}

	public override void OnKilled()
	{
		// TODO: Override that method on Game class
		GameManager.Current.OnKilled( this );
	}

	public override void Simulate( IClient client )
	{
		if ( !IsAlive )
			return;

		Controller?.Simulate( client, this );
	}

	public override void FrameSimulate( IClient client )
	{
		Camera.Rotation = ViewAngles.ToRotation();
		Camera.Position = EyePosition;
		Camera.FieldOfView = Screen.CreateVerticalFieldOfView( Sandbox.Game.Preferences.FieldOfView );
		Camera.FirstPersonViewer = this;
	}

	public override void BuildInput()
	{
		OriginalViewAngles = ViewAngles;
		InputDirection = Input.AnalogMove;

		if ( Input.StopProcessing )
			return;

		var look = Input.AnalogLook;
		if ( ViewAngles.pitch is > 90f or < -90f )
			look = look.WithYaw( look.yaw * -1f );

		var viewAngles = ViewAngles;
		viewAngles += look;
		viewAngles.pitch = viewAngles.pitch.Clamp( -89f, 89f );
		ViewAngles = viewAngles.Normal;

		Controller?.BuildInput();
	}

	public override void TakeDamage( DamageInfo damageInfo )
	{
		if ( LifeState == LifeState.Dead )
			return;

		base.TakeDamage( damageInfo );
		this.ProceduralHitReaction( damageInfo );
	}

	public override void OnAnimEventFootstep( Vector3 position, int foot, float volume )
	{
		if ( !IsAlive || !Sandbox.Game.IsClient || _timeSinceLastFootstep < 0.2f)
			return;

		volume *= Velocity.WithZ( 0 ).Length.LerpInverse( 0f, 200f ) * 0.2f;
		_timeSinceLastFootstep = 0;

		var trace = Trace.Ray( position, position + Vector3.Down * 20 )
			.Radius( 1 )
			.Ignore( this )
			.Run();

		if ( !trace.Hit )
			return;

		trace.Surface.DoFootstep( this, trace, foot, volume );
	}
}
