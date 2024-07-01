using System;
namespace Project.API.Dtos
{
	public class UserResDto
	{
        public string Id { get; set; }
        public string FullName { get; set; }
		public string EmailId { get; set; }
		public bool SubscriptionStatus { get; set; }
		public bool isAdmin { get; set; }


	}
}

