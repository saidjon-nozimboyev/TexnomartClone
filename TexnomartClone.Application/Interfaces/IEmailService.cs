namespace TexnomartClone.Application.Interfaces;

public interface IEmailService
{
    Task SendMessageToEmailAsync(string to, string title, string body);
}
