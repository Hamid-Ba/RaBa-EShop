namespace Framework.Presentation.Api.JwtTools
{
    public class JwtDto
	{
        public long Id { get; set; }
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }

		public JwtDto(long id, string fullName, string phoneNumber)
		{
			Id = id;
			FullName = fullName;
			PhoneNumber = phoneNumber;
		}
	}
}