using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lab5.Database;
using Lab5.Models;
using Lab5.Repository;

namespace Lab5.Repository;

public class MyRepository:IMyRepository
{
    private readonly MyContext _context;
    
    public MyRepository(MyContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }
    public void SaveToDb(ObservableCollection<MusicTrack> tracks)
    {
        _context.Tracks?.RemoveRange(_context.Tracks);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Tracks?.AddRange(tracks);
        _context.SaveChanges();
    }

    public List<MusicTrack> LoadFromDb()
    {
        return _context.Tracks!.ToList();
    }
}