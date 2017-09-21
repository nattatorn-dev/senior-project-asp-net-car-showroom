namespace CarShowroom.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using CarShowroom.Models;
	using System.Collections.Generic;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<CarShowroom.DAL.CarShowroomContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarShowroom.DAL.CarShowroomContext context)
        {
			//  This method will be called after migrating to the latest version.

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

			clients.ForEach(s => context.Clients.AddOrUpdate(p => p.LastName, s));
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

			positions.ForEach(s => context.Positions.AddOrUpdate(p => p.Title, s));
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
					PositionId = positions.Single(c => c.Title == "Dealer").PositionId
				},
				new Worker
				{
					FirstName = "Mateusz",
					LastName = "Sosnowski",
					Pesel = "55513455565",
					City = "Chicago",
					Street = "Long",
					StreetNumber = 7,
					PositionId = positions.Single(c => c.Title == "Manager").PositionId
				},
				new Worker
				{
					FirstName = "Luke",
					LastName = "Garcia",
					Pesel = "32131755221",
					City = "Dallas",
					Street = "Oak",
					StreetNumber = 12,
					PositionId = positions.Single(c => c.Title == "Accountant").PositionId
				},
				new Worker
				{
					FirstName = "George",
					LastName = "Hammers",
					Pesel = "44221122335",
					City = "Phoenix",
					Street = "Narrow",
					StreetNumber = 141,
					PositionId = positions.Single(c => c.Title == "Intern").PositionId
				}
			};

			foreach (Worker w in workers)
			{
				var workersInDataBase = context.Workers.Where(
					s =>
					s.Position.PositionId == w.PositionId).SingleOrDefault();
				if (workersInDataBase == null)
				{
					context.Workers.Add(w);
				}
			}

			workers.ForEach(s => context.Workers.AddOrUpdate(p => p.LastName, s));
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
				},
				new Car
				{
					Brand = "Audi",
					Model = "A8",
					Price = 940000,
					IsNew = true
				},
				new Car
				{
					Brand = "Audi",
					Model = "Q3",
					Price = 270000,
					IsNew = true
				}
			};

			cars.ForEach(s => context.Cars.AddOrUpdate(p => p.Model, s));
			context.SaveChanges();

			var purchases = new List<Purchase>
			{
				new Purchase
				{
					ClientId = clients.Single(c => c.LastName == "Carson").ClientId,
					WorkerId = workers.Single(c => c.LastName == "Jackson").WorkerId,
					CarId = cars.Single(c => c.Model == "A7").CarId,
					TransactionDate = DateTime.Parse("2016-09-01")
				},
				new Purchase
				{
					ClientId = clients.Single(c => c.LastName == "Kowalski").ClientId,
					WorkerId = workers.Single(c => c.LastName == "Jackson").WorkerId,
					CarId = cars.Single(c => c.Model == "Golf").CarId,
					TransactionDate = DateTime.Parse("2016-09-01")
				},
				new Purchase
				{
					ClientId = clients.Single(c => c.LastName == "Thompson").ClientId,
					WorkerId = workers.Single(c => c.LastName == "Jackson").WorkerId,
					CarId = cars.Single(c => c.Model == "Passat").CarId,
					TransactionDate = DateTime.Parse("2016-01-02")
				},
				new Purchase
				{
					ClientId = clients.Single(c => c.LastName == "Lopez").ClientId,
					WorkerId = workers.Single(c => c.LastName == "Jackson").WorkerId,
					CarId = cars.Single(c => c.Model == "A3").CarId,
					TransactionDate = DateTime.Parse("2016-03-07")
				}
			};

			foreach(Purchase p in purchases)
			{
				var purchaseInDataBase = context.Purchases.Where(
					s =>
					s.Client.ClientId == p.ClientId &&
					s.Worker.WorkerId == p.WorkerId &&
					s.Car.CarId == p.CarId).SingleOrDefault();
				if(purchaseInDataBase == null)
				{
					context.Purchases.Add(p);
				}
			}
			context.SaveChanges();
		}
    }
}
