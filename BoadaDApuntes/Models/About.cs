namespace BoadaDApuntes.Models;

internal class About
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string MoreInfoUrl => "https://aka.ms/maui";
    public string Message => "Esta app está escrita en XAML y C# con .NET MAUI por Dana Boada.";
    public string Name => "Dana Boada";
    public string Description => "Estudiante de Ingeniería de Software";
    public string Hobbies => "Mis hobbies incluyen tocar el violín, el piano y escuchar música";
}