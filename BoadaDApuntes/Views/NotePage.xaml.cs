namespace BoadaDApuntes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            if (string.IsNullOrWhiteSpace(TextEditor.Text))
            {
                await DisplayAlert("Aviso", "No puedes guardar una nota vacía", "OK");
                return;
            }

            File.WriteAllText(note.Filename, TextEditor.Text);
            await DisplayAlert("Éxito", "Nota guardada correctamente", "OK");
        }

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            bool answer = await DisplayAlert("Confirmar", "¿Estás segura de que quieres eliminar esta nota?", "Sí", "No");

            if (answer && File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
                await DisplayAlert("Eliminado", "Nota eliminada correctamente", "OK");
            }
        }

        await Shell.Current.GoToAsync("..");
    }

    public string ItemId
    {
        set { LoadNote(value); }
    }

    private void LoadNote(string fileName)
    {
        Models.Note noteModel = new Models.Note
        {
            Filename = fileName
        };

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}