
namespace Storm;

public class SampleSchema : BaseSchema
{
	public override void Initialize()
	{
		Log.Info( "Hello, welcome to my schema!" );
		Log.Info( $"Schema Name: {Details.Name}" );
		Log.Info( $"Schema Author: {Details.Author}" );
		Log.Info( $"Schema Description: {Details.Description}" );
	}
}
