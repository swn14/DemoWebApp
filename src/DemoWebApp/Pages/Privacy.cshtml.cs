using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NATS.Client;

namespace DemoWebApp.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private readonly IConnection _natsConnection;

    public PrivacyModel(ILogger<PrivacyModel> logger, IConnection natsConnection)
    {
        _logger = logger;
        _natsConnection = natsConnection;
    }

    public void OnGet()
    {
        _natsConnection.Publish("blah", new object().ToByteArray());
    }
}

