// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ingrese la contraseña a encriptar:");
var key = Console.ReadLine();
Console.WriteLine(BCrypt.Net.BCrypt.HashPassword(key));