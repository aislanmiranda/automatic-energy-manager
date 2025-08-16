namespace Application.DTOs;

public class FreezerOnOffRequest
{
    public OnOffData? Message { get; set; }
    public string Queue { get; set; } = string.Empty;
}

public class OnOffData
{
    public string Action { get; set; } = string.Empty;
    public int Port { get; set; }
}