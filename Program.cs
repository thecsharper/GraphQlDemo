// https://chillicream.com/docs/hotchocolate/v13/get-started-with-graphql-in-net-core

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();
//app.UsePathBase("/graphql"); // does not work
app.UseRouting();
app.Run();

public class Book
{
    public string? Title { get; set; }

    public Author? Author { get; set; }
}

public class Author
{
    public string? Name { get; set; }
}

public class Query
{
    public Book GetBook() =>
        new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet"
            }
        };
}