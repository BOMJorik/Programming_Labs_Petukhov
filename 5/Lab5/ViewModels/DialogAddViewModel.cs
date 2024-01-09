using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Media;
using Lab5.Models;
using Lab5.Views;
using ReactiveUI;

namespace Lab5.ViewModels;

public sealed class DialogAddViewModel : ViewModelBase
{
    private MusicTrack _musicTrack;
    private string _title;
    private string _author;
    
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly DialogAddWindow _dialog;
    private readonly Button _button;

    public DialogAddViewModel(MainWindowViewModel mwvm, DialogAddWindow dialog)
    {
        _mainWindowViewModel = mwvm;
        _dialog = dialog;
        _button = _dialog.FindControl<Button>("OkButton");
    }
    
    public DialogAddViewModel(MainWindowViewModel mwvm, DialogAddWindow dialog, MusicTrack musicTrack)
    {
        _mainWindowViewModel = mwvm;
        _dialog = dialog;
        _musicTrack = musicTrack;
        Title = _musicTrack.Title;
        Author = _musicTrack.Author;
        _button = _dialog.FindControl<Button>("OkButton");
    }
    
    
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public string Author
    {
        get => _author;
        set => this.RaiseAndSetIfChanged(ref _author, value);
    }

    private bool IsInputWordValid()
    {
        return Author != "" && Title != "";
    }

    public async void AddTrack()
    {
        if (IsInputWordValid())
        {
            _button.Background = Brushes.Chartreuse;
            if (_musicTrack != null)
                await _mainWindowViewModel.SaveChanges(new MusicTrack{Title = Title, Author = Author});
            else
                await _mainWindowViewModel.AddTrack(new MusicTrack{Title = Title, Author = Author});
            _dialog.Close();
        }
        else
        {
            _button.Background = Brushes.Red;
        }
    }
}