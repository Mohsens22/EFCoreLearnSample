// See https://aka.ms/new-console-template for more information
using DutiesApp.Data;
using DutiesApp.Model;

Console.WriteLine(@"Enter Option
1- Show all tasks
2- Insert a task
3- Update a task
4- Delete a task
5- Search a task");

var option = int.Parse(Console.ReadLine());

string result = "";

switch (option)
{

    case 1:
        result = ShowAllTasks();
        break;
    case 2:
        result = InsertNewDuty();
        break;
    case 3:
        result = UpdateDuty();
        break;
    case 4:
        result = DeleteDuty();
        break;
    case 5:
        result = Search();
        break;
    default:
        result ="Not a valid option";
        break;
}

string Search()
{
    Console.WriteLine("Enter title search term");
    var term = Console.ReadLine();

    using (var context = new Context())
    {
        var result = context.Duties.Where(x=> x.Title == term || x.Info==term);
        return string.Join(Environment.NewLine, result.Select(x=>x.ToString()));
    }
}

string DeleteDuty()
{
    Console.WriteLine("Enter duty ID to delete");
    var id = int.Parse(Console.ReadLine());

    using (var context = new Context())
    {
        var duty = context.Duties.Find(id);

        context.Duties.Remove(duty);
        context.SaveChanges();
    }
    return "Deleted";
}

Console.WriteLine(result);

string UpdateDuty()
{
    Console.WriteLine("Enter duty ID to update");
    var id = int.Parse(Console.ReadLine());
    using (var context = new Context())
    {
        var old = context.Duties.Find(id);
        Console.WriteLine(old.ToString());
        Console.WriteLine("Enter new title (leave blank if unchanged)");
        var newTitle = Console.ReadLine();
        Console.WriteLine("Enter new Info (leave blank if unchanged)");
        var newInfo = Console.ReadLine();

        if (newTitle != "")
        {
            old.Title = newTitle;
        }
        if (newInfo != "")
        {
            old.Info = newInfo;
        }

        context.Update(old);
        context.SaveChanges();
    }
    return "Updated";
}



string InsertNewDuty()
{
    Console.WriteLine("Enter title");
    var title = Console.ReadLine();

    Console.WriteLine("Enter Info");
    var info = Console.ReadLine();

    var duty = new Duty
    {
        Title = title,
        Info = info
    };

    using (var context = new Context())
    {
        context.Duties.Add(duty);
        context.SaveChanges();
    }

    return "Inserted";
}



string ShowAllTasks()
{
    using (var context = new Context())
    {
        var all = context.Duties.ToList();

        return string.Join(Environment.NewLine, all.Select(x=>x.ToString()));
    }
}


