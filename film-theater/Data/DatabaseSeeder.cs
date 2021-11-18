using film_theater.Auth.Model;
using film_theater.Data.Dtos.Auth;
using film_theater.Data.Entities;
using film_theater.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace film_theater.Data
{
    public class DatabaseSeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITheatersRepository _theatersRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly ISessionsRepository _sessionsRepository;

        public DatabaseSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            ITheatersRepository theatersRepository,
            IRoomsRepository roomsRepository,
            ISessionsRepository sessionsRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _theatersRepository = theatersRepository;
            _roomsRepository = roomsRepository;
            _sessionsRepository = sessionsRepository;
        }

        public async Task SeedAsync()
        {
            foreach (var role in UserRoles.All)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if(!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Admin
            var newAdminUser = new User()
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };

            var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if(existingAdminUser == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "VerySafePassword1!");
                if(createAdminUserResult.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdminUser, UserRoles.All);
                }
            }

            // mod1
            var newModerator1User = new User()
            {
                UserName = "moderator1",
                Email = "moderator1@moderator1.com"
            };

            var existingModerator1User = await _userManager.FindByNameAsync(newModerator1User.UserName);
            if (existingModerator1User == null)
            {
                var createModerator1UserResult = await _userManager.CreateAsync(newModerator1User, "VerySafePassword1!");
                if (createModerator1UserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newModerator1User, UserRoles.Moderator);
                }
            }
            // mod2
            var newModerator2User = new User()
            {
                UserName = "moderator2",
                Email = "moderator2@moderator2.com"
            };

            var existingModerator2User = await _userManager.FindByNameAsync(newModerator2User.UserName);
            if (existingModerator2User == null)
            {
                var createModerator2UserResult = await _userManager.CreateAsync(newModerator2User, "VerySafePassword1!");
                if (createModerator2UserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newModerator2User, UserRoles.Moderator);
                }
            }

            //// Theaters
            //var newTheater1 = new Theater()
            //{
            //    Name = "Wowzers",
            //    Location = "Vilnius",
            //    UserId = await _userManager.GetUserIdAsync(newModerator2User)
            //};

            //var newTheater2 = new Theater()
            //{
            //    Name = "Poggers",
            //    Location = "Vilnius",
            //    UserId = await _userManager.GetUserIdAsync(newModerator2User)
            //};

            //var existingTheaters = await _theatersRepository.GetAll();
            //if (!existingTheaters.Any())
            //{
            //    await _theatersRepository.Post(newTheater1);
            //    await _theatersRepository.Post(newTheater2);
            //}

            //// Rooms
            //var newRoom1 = new Room()
            //{
            //    Name = "Room 1",
            //    Capacity = 50,
            //    RoomType = "Luxury",
            //    TheaterId = 1,
            //    UserId = await _userManager.GetUserIdAsync(newModerator1User)
            //};

            //var newRoom2 = new Room()
            //{
            //    Name = "Room 2",
            //    Capacity = 100,
            //    RoomType = "Basic",
            //    TheaterId = 1,
            //    UserId = await _userManager.GetUserIdAsync(newModerator1User)
            //};

            //var existingRooms1 = await _roomsRepository.GetAll(1);
            //if (!existingRooms1.Any())
            //{
            //    await _roomsRepository.Post(newRoom1);
            //    await _roomsRepository.Post(newRoom2);
            //}

            //var newRoom3 = new Room()
            //{
            //    Name = "Room 1",
            //    Capacity = 80,
            //    RoomType = "Luxury",
            //    TheaterId = 2,
            //    UserId = await _userManager.GetUserIdAsync(newModerator2User)
            //};

            //var newRoom4 = new Room()
            //{
            //    Name = "Room 2",
            //    Capacity = 90,
            //    RoomType = "Luxury",
            //    TheaterId = 2,
            //    UserId = await _userManager.GetUserIdAsync(newModerator2User)
            //};

            //var existingRooms2 = await _roomsRepository.GetAll(2);
            //if (!existingRooms2.Any())
            //{
            //    await _roomsRepository.Post(newRoom3);
            //    await _roomsRepository.Post(newRoom4);
            //}

            //// Sessions
            //var newSession1 = new Session()
            //{
            //    FilmName = "Amogus",
            //    StartTime = DateTime.Parse("2021-12-17T17:00:00.000Z"),
            //    EndTime = DateTime.Parse("2021-12-17T19:00:00.000Z"),
            //    RoomId = 1,
            //    UserId = await _userManager.GetUserIdAsync(newModerator1User)
            //};

            //var newSession2 = new Session()
            //{
            //    FilmName = "Sadge",
            //    StartTime = DateTime.Parse("2021-12-17T17:00:00.000Z"),
            //    EndTime = DateTime.Parse("2021-12-17T19:00:00.000Z"),
            //    RoomId = 1,
            //    UserId = await _userManager.GetUserIdAsync(newModerator1User)
            //};

            //var newSession3 = new Session()
            //{
            //    FilmName = "The Asylum Incident",
            //    StartTime = DateTime.Parse("2021-12-17T17:00:00.000Z"),
            //    EndTime = DateTime.Parse("2021-12-17T19:00:00.000Z"),
            //    RoomId = 2,
            //    UserId = await _userManager.GetUserIdAsync(newModerator1User)
            //};

            //var newSession4 = new Session()
            //{
            //    FilmName = "Blade Runner 2047",
            //    StartTime = DateTime.Parse("2021-12-17T17:00:00.000Z"),
            //    EndTime = DateTime.Parse("2021-12-17T19:00:00.000Z"),
            //    RoomId = 2,
            //    UserId = await _userManager.GetUserIdAsync(newModerator1User)
            //};

            //var newSession5 = new Session()
            //{
            //    FilmName = "Three Bajs",
            //    StartTime = DateTime.Parse("2021-12-17T17:00:00.000Z"),
            //    EndTime = DateTime.Parse("2021-12-17T19:00:00.000Z"),
            //    RoomId = 3,
            //    UserId = await _userManager.GetUserIdAsync(newModerator2User)
            //};

            //var newSession6 = new Session()
            //{
            //    FilmName = "Dune",
            //    StartTime = DateTime.Parse("2021-12-17T17:00:00.000Z"),
            //    EndTime = DateTime.Parse("2021-12-17T19:00:00.000Z"),
            //    RoomId = 3,
            //    UserId = await _userManager.GetUserIdAsync(newModerator2User)
            //};

            //var newSession7 = new Session()
            //{
            //    FilmName = "Lost",
            //    StartTime = DateTime.Parse("2021-12-17T17:00:00.000Z"),
            //    EndTime = DateTime.Parse("2021-12-17T19:00:00.000Z"),
            //    RoomId = 4,
            //    UserId = await _userManager.GetUserIdAsync(newModerator2User)
            //};

            //var newSession8 = new Session()
            //{
            //    FilmName = "Pepejas",
            //    StartTime = DateTime.Parse("2021-12-17T17:00:00.000Z"),
            //    EndTime = DateTime.Parse("2021-12-17T19:00:00.000Z"),
            //    RoomId = 4,
            //    UserId = await _userManager.GetUserIdAsync(newModerator2User)
            //};

            //var existingSessions1 = await _sessionsRepository.GetAll(1);
            //if (!existingSessions1.Any())
            //{
            //    await _sessionsRepository.Post(newSession1);
            //    await _sessionsRepository.Post(newSession2);
            //}

            //var existingSessions2 = await _sessionsRepository.GetAll(2);
            //if (!existingSessions2.Any())
            //{
            //    await _sessionsRepository.Post(newSession3);
            //    await _sessionsRepository.Post(newSession4);
            //}

            //var existingSessions3 = await _sessionsRepository.GetAll(3);
            //if (!existingSessions3.Any())
            //{
            //    await _sessionsRepository.Post(newSession5);
            //    await _sessionsRepository.Post(newSession6);
            //}

            //var existingSessions4 = await _sessionsRepository.GetAll(4);
            //if (!existingSessions4.Any())
            //{
            //    await _sessionsRepository.Post(newSession7);
            //    await _sessionsRepository.Post(newSession8);
            //}

        }
    }
}
