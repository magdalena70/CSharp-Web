using SimpleHttpServer;
using System.Collections.Generic;
using SharpStore.Models;
using SharpStore.Data;
using System.Data.Entity.Migrations;

namespace RunServer
{
    class Program
    {
        static void Main()
        {
            //create database SharpStoreDB and seed data
            SharpStoreContext context = Data.Context;
            context.Database.Initialize(true);
            SeedUsers(context);
            SeedKnifes(context);

            //config and run server
            var routes = RoutesConfig.UseRoutes();
            HttpServer httpServer = new HttpServer(8081, routes);
            httpServer.Listen();
        }

        private static void SeedKnifes(SharpStoreContext context)
        {
            IList<Knife> knives = new List<Knife>();

            knives.Add(new Knife() { Name = "Knive Sharp One", Price = 267.55m, ImageURL = "images/sharp3.png" });
            knives.Add(new Knife() { Name = "Knive Sharp Second", Price = 467.99m, ImageURL = "images/sharp4.jpg" });
            knives.Add(new Knife() { Name = "Other Sharp", Price = 99m, ImageURL = "images/sharp5.jpg" });
            knives.Add(new Knife() { Name = "Some Knive", Price = 111.87m, ImageURL = "images/knife-sharp1.jpg" });
            knives.Add(new Knife() { Name = "Any Knive", Price = 900.99m, ImageURL = "images/knife-sharp2.jpg" });

            foreach (Knife knive in knives)
            {
                context.Knives.AddOrUpdate(k => k.Name, knive);
            }

            context.SaveChanges();
            System.Console.WriteLine("Knives was added successfuly!");
        }

        private static void SeedUsers(SharpStoreContext context)
        {
            IList<User> users = new List<User>();

            users.Add(new User() { Username = "UserOne", Email = "userOne@UserOne.bg" });
            users.Add(new User() { Username = "UserSecond", Email = "second@abv.bg" });
            users.Add(new User() { Username = "OtherUser", Email = "other_user@aaa.gmail" });
            users.Add(new User() { Username = "SomeUser", Email = "some@aaa.gmail" });
            users.Add(new User() { Username = "AnyUser", Email = "any_user@any.bg" });

            foreach (User user in users)
            {
                context.Users.AddOrUpdate(u => u.Username, user);
            }

            context.SaveChanges();
            System.Console.WriteLine("Users was added successfuly!");
        }
    }
}
