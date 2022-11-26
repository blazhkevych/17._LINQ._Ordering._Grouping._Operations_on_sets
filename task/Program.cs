namespace task;

/// <summary>
///     Упорядочивание. Группирование. Операции над множествами.
///     1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно.
///     2) Отсортировать сотрудников по возрастам по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос
///     немедленно.
///     3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        var departments = new List<Department>
        {
            new() { Id = 1, Country = "Ukraine", City = "Odesa" },
            new() { Id = 2, Country = "Ukraine", City = "Kyiv" },
            new() { Id = 3, Country = "France", City = "Paris" },
            new() { Id = 4, Country = " Ukraine ", City = "Lviv" }
        };
        var employees = new List<Employee>
        {
            new()
            {
                Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2
            },
            new()
            {
                Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1
            },
            new()
            {
                Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3
            },
            new()
            {
                Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2
            },
            new()
            {
                Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4
            },
            new()
            {
                Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2
            },
            new()
            {
                Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4
            }
        };

        // Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно.
        var query1 = employees
            .Where(e => e.DepId != 3)
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new { e.FirstName, e.LastName });
        // Вывод в консоль.
        Console.WriteLine(
            "1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно.");
        foreach (var item in query1) Console.WriteLine(item);

        // Отсортировать сотрудников по возрастам по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно.
        var query2 = employees
            .OrderByDescending(e => e.Age)
            .Select(e => new { e.Id, e.FirstName, e.LastName, e.Age });
        // Вывод в консоль.
        Console.WriteLine(
            "2) Отсортировать сотрудников по возрастам по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно.");
        foreach (var item in query2) Console.WriteLine(item);

        // Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.
        var query3 = employees
            .GroupBy(e => e.Age)
            .Select(e => new { Age = e.Key, Count = e.Count() });
        // Вывод в консоль.
        Console.WriteLine(
            "3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.");
        foreach (var item in query3) Console.WriteLine(item);
    }
}