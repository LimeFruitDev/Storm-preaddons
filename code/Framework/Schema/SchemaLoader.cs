namespace Storm;

public static class SchemaLoader
{
	public static void LoadSchema()
	{
		foreach ( var schemaType in TypeLibrary.GetTypes<BaseSchema>() )
		{
			if ( schemaType.Name == "BaseSchema" )
			{
				continue;
			}

			var baseSchema = TypeLibrary.Create<BaseSchema>( schemaType.TargetType );
			if ( baseSchema == null )
			{
				Log.Error( "Failed to instantiate schema!" );
			}
		}
	}
}
