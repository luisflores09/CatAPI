using System;

namespace CatAPI.Models;

public class Cat
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Breed { get; set; }
    public int Age { get; set; }
}
