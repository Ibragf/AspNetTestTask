using AspNetTestTask.Models;

namespace AspNetTestTask.Db
{
    public class AppDb
    {
        public AppDb() { }

        public Dictionary<string, Product> Products { get; private set; } = new()
        {
            { "asdasdasdasdas", 
                new Product {
                    Id = "asdasdasdasdas",
                    Name = "first",
                    Description= "first descr",
                    Category = "first category",
                    Price = 100,
                    Quantity = 10
                } 
            },

            { "23l4m23kk2l3mn", 
                new Product {
                    Id = "23l4m23kk2l3mn",
                    Name = "second",
                    Description= "second descr",
                    Category = "second category",
                    Price = 50,
                    Quantity = 25
                }
            },

            {"asdas3k423l4k32k", 
                new Product {
                    Id = "asdas3k423l4k32k",
                    Name = "third",
                    Description= "third descr",
                    Category = "third category",
                    Price = 2344,
                    Quantity = 654
                } 
            }
        };

        public Dictionary<string, Order> Orders { get; private set; } = new Dictionary<string, Order>()
        {
            {"afcewrt3c3rfc",
                new Order
                {
                    Id = "afcewrt3c3rfc",
                    Amount = 123321,
                    ProductsId = new() { "asdas3k423l4k32k", "asdas3k423l4k32k" },
                    UserId = Guid.NewGuid().ToString(),
                }
            },
            {"asd3224n23lkelknd2",
                new Order
                {
                    Id = "asd3224n23lkelknd2",
                    Amount = 32423,
                    ProductsId = new() { "23l4m23kk2l3mn", "asdasdasdasdas" },
                    UserId = Guid.NewGuid().ToString(),
                }
            },
            {"lkfsdk2l3k423ln",
                new Order
                {
                    Id = "lkfsdk2l3k423ln",
                    Amount = 65426,
                    ProductsId = new() { "asdas3k423l4k32k" },
                    UserId = Guid.NewGuid().ToString(),
                } 
            }
        };
    }
}
