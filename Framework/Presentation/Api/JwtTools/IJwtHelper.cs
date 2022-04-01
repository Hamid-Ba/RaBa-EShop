namespace Framework.Presentation.Api.JwtTools
{
    public interface IJwtHelper
	{
		string SignIn(JwtDto dto);
	}
}