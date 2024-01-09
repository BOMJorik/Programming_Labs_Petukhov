using Microsoft.AspNetCore.Mvc;

[Route("api/music")]
[ApiController]
public class MusicCatalogController : ControllerBase
{
    private static List<MusicDto> musicList = new List<MusicDto>();

    [HttpGet]
    public IActionResult GetMusicList()
    {
        return Ok(musicList);
    }

    [HttpPost]
    public IActionResult AddMusic([FromBody] MusicDto musicDto)
    {
        musicList.Add(musicDto);
        return CreatedAtAction(nameof(GetMusicList), new { id = Guid.NewGuid() }, musicList);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMusic(int id, [FromBody] MusicDto musicDto)
    {
        var existingMusic = musicList.Find(m => m.Id == id);
        if (existingMusic == null)
        {
            return NotFound();
        }

        existingMusic.Title = musicDto.Title;
        existingMusic.Artist = musicDto.Artist;

        return Ok(existingMusic);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMusic(int id)
    {
        var existingMusic = musicList.Find(m => m.Id == id);
        if (existingMusic == null)
        {
            return NotFound();
        }

        musicList.Remove(existingMusic);
        return NoContent();
    }
}