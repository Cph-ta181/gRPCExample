// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using gRPCServer;

string name = Console.ReadLine();
var input = new HelloRequest { Name = name };

var channel = GrpcChannel.ForAddress("https://localhost:7071");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(input);

Console.WriteLine(reply.Message);


Console.WriteLine("----Customers----\nType what ID you would like to look up:");
string idInput = Console.ReadLine();
var input2 = new CustomerLookupModel { UserId = Int32.Parse(idInput) };
var client2 = new Customer.CustomerClient(channel);
var reply2 = await client2.GetCustomerInfoAsync(input2);
Console.WriteLine(reply2);

Console.ReadLine();