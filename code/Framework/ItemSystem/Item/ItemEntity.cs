using Sandbox;

namespace Storm;

public partial class ItemEntity : ModelEntity
{
	[Net] public ItemInstance ItemInstance { get; set; }

	public void LoadInstance()
	{
		SetModel( ItemInstance.Data.WorldModel );
		Velocity = 0;

		EnableAllCollisions = true;
		EnableDrawing = true;

		SetupPhysicsFromModel( PhysicsMotionType.Keyframed );
		EnableHitboxes = true;
		PhysicsEnabled = true;
		Tags.Add( "solid" );

		ResetInterpolation();
	}

	public override void TakeDamage( DamageInfo damageInfo )
	{
		// TODO: Delete the entity but also remove the instance!
		//if (Health <= 0)
		//	Delete();
	}
}
