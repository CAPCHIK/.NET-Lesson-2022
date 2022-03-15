using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [ViewData]
    public List<SomeData> DataList { get; set; } = new List<SomeData>();
    public void OnGet()
    {
        var names = new Bogus.DataSets.Name();
        DataList.AddRange( Enumerable
            .Repeat(0, 10)
            .Select(_ => new SomeData(Random.Shared.Next(100), names.FirstName()))
        );

    }
}
public record SomeData(int Age, string Name);
