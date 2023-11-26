using Grpc.Core;

namespace gRPCServer.Services
{
	public class CustomersService : Customer.CustomerBase
	{
		private readonly ILogger<CustomersService> logger;

		public CustomersService(ILogger<CustomersService> logger)
		{
			this.logger = logger;
		}

		public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
		{
			CustomerModel output = new CustomerModel();
			if (request.UserId == 0)
			{
				output.FirstName = "Bob";
				output.LastName = "Bobsen";
			}
			else
			{
				output.FirstName = "Ib";
				output.LastName = "Ibsen";
			}

			return Task.FromResult(output);
		}

	}
}
