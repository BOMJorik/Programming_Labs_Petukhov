using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lab5.Models;

namespace Lab5.Repository;

public interface IMyRepository
{
    void SaveToDb(ObservableCollection<MusicTrack> tracks);
    List<MusicTrack> LoadFromDb();
}