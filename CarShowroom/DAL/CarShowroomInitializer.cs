using System;
using System.Collections.Generic;
using CarShowroom.Models;

namespace CarShowroom.DAL
{
	public class CarShowroomInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CarShowroomContext>
	{
		protected override void Seed(CarShowroomContext context)
		{
			var clients = new List<Client>
			{
				new Client
				{
					FirstName = "Alexander",
					LastName = "Carson",
					Pesel = "12233455666",
					City = "Chicago",
					Street = "Long",
					StreetNumber = 3
				},
				new Client
				{
					FirstName = "John",
					LastName = "Kowalski",
					Pesel = "87213452266",
					City = "Houston",
					Street = "Montgomery",
					StreetNumber = 4
				},
				new Client
				{
					FirstName = "Luis",
					LastName = "Thompson",
					Pesel = "77733755116",
					City = "Dallas",
					Street = "Oak",
					StreetNumber = 70
				},
				new Client
				{
					FirstName = "Henry",
					LastName = "Lopez",
					Pesel = "65413415261",
					City = "Denver",
					Street = "Pine",
					StreetNumber = 11
				}
			};

			clients.ForEach(s => context.Clients.Add(s));
			context.SaveChanges();

			var positions = new List<Position>
			{
				new Position
				{
					Title = "Dealer",
					Salary = 2500,
					IsFullTime = true,
					IsContract = false
				},
				new Position
				{
					Title = "Accountant",
					Salary = 3500,
					IsFullTime = true,
					IsContract = true
				},
				new Position
				{
					Title = "Manager",
					Salary = 8000,
					IsFullTime = true,
					IsContract = false
				},
				new Position
				{
					Title = "Intern",
					Salary = 1200,
					IsFullTime = false,
					IsContract = false
				}
			};

			positions.ForEach(s => context.Positions.Add(s));
			context.SaveChanges();

			var workers = new List<Worker>
			{
				new Worker
				{
					FirstName = "Tom",
					LastName = "Jackson",
					Pesel = "67231155411",
					City = "Phoenix",
					Street = "Cedar",
					StreetNumber = 1,
					PositionId = 1
				},
				new Worker
				{
					FirstName = "Mateusz",
					LastName = "Sosnowski",
					Pesel = "55513455565",
					City = "Chicago",
					Street = "Long",
					StreetNumber = 7,
					PositionId = 2
				},
				new Worker
				{
					FirstName = "Luke",
					LastName = "Garcia",
					Pesel = "32131755221",
					City = "Dallas",
					Street = "Oak",
					StreetNumber = 12,
					PositionId = 3
				}
			};

			workers.ForEach(s => context.Workers.Add(s));
			context.SaveChanges();

			var cars = new List<Car>
			{
				new Car
				{
					Brand = "Audi",
					Model = "A7",
					Price = 650000,
					IsNew = true
				},
				new Car
				{
					Brand = "VW",
					Model = "Golf",
					Price = 90000,
					IsNew = true
				},
				new Car
				{
					Brand = "VW",
					Model = "Passat",
					Price = 146000,
					IsNew = true
				},
				new Car
				{
					Brand = "Audi",
					Model = "A3",
					Price = 125000,
					IsNew = true
				}
			};

			cars.ForEach(s => context.Cars.Add(s));
			context.SaveChanges();

			var purchases = new List<Purchase>
			{
				new Purchase
				{
					ClientId = 1,
					WorkerId = 1,
					CarId = 1,
					TransactionDate = DateTime.Parse("2010-09-01")
				},
				new Purchase
				{
					ClientId = 2,
					WorkerId = 1,
					CarId = 2,
					TransactionDate = DateTime.Parse("2011-11-09")
				},
				new Purchase
				{
					ClientId = 3,
					WorkerId = 1,
					CarId = 3,
					TransactionDate = DateTime.Parse("2012-01-02")
				}
			};

			purchases.ForEach(s => context.Purchases.Add(s));
			context.SaveChanges();


		}
	}
}