namespace RestaurantAPI.Entities
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Chicken wings",
                            Price = 17.99M
                        },
                        new Dish
                        {
                            Name = "Chicken legs",
                            Price = 14.99M
                        }
                    },
                    Address = new Address
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant
                {
                    Name = "McDonald's",
                    Category = "Fast Food",
                    Description = "McDonald's Corporation is an American fast food company, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States.",
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Hamburger",
                            Price = 7.99M
                        },
                        new Dish
                        {
                            Name = "Cheeseburger",
                            Price = 8.99M
                        }
                    },
                    Address = new Address
                    {
                        City = "Kraków",
                        Street = "Plac Wszystkich Świętych 2",
                        PostalCode = "31-004"
                    }
                },
                new Restaurant
                {
                    Name = "Pizza Hut",
                    Category = "Fast Food",
                    Description = "Pizza Hut is an American restaurant chain and international franchise which was founded in 1958 in Wichita, Kansas by Dan and Frank Carney.",
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Margherita",
                            Price = 19.99M
                        },
                        new Dish
                        {
                            Name = "Hawaiian",
                            Price = 21.99M
                        }
                    },
                    Address = new Address
                    {
                        City = "Kraków",
                        Street = "Rynek Główny 12",
                        PostalCode = "30-001"
                    }
                }
            };
            return restaurants;
        }
    }
}

