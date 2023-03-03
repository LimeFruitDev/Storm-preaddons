using System.ComponentModel;
using Sandbox;

namespace Storm;

public partial class Player
{
	[Net, Predicted] public PawnController Controller { get; set; }

	[ClientInput] public Vector3 InputDirection { get; protected set; }
	[ClientInput] public Angles ViewAngles { get; set; }
	public Angles OriginalViewAngles { get; set; }

	[Net, Predicted, Browsable( false )] public Vector3 EyeLocalPosition { get; set; }
	[Net, Predicted, Browsable( false )] public Rotation EyeLocalRotation { get; set; }

	public Vector3 EyePosition
	{
		get => Transform.PointToWorld( EyeLocalPosition );
		set => EyeLocalPosition = Transform.PointToLocal( value );
	}

	public Rotation EyeRotation
	{
		get => Transform.RotationToWorld( EyeLocalRotation );
		set => EyeLocalRotation = Transform.RotationToLocal( value );
	}

	private TimeSince _timeSinceLastFootstep = 0;
}
