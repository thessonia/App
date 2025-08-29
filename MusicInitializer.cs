using hm.Data;
using hm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace hm.Data
{
    public class MusicInitializer : DropCreateDatabaseAlways<MusicContext>
    {
        protected override void Seed(MusicContext context)
        {
            var artist1 = new Artist { FirstName = "Freddie", LastName = "Mercury", Country = "UK" };
            var artist2 = new Artist { FirstName = "Kurt", LastName = "Cobain", Country = "USA" };

            var album1 = new Album { Name = "A Night at the Opera", Year = 1975, Genre = "Rock", Artist = artist1 };
            var album2 = new Album { Name = "Nevermind", Year = 1991, Genre = "Grunge", Artist = artist2 };

            var track1 = new Track { Name = "Bohemian Rhapsody", Duration = TimeSpan.FromMinutes(6), Album = album1 };
            var track2 = new Track { Name = "Love of My Life", Duration = TimeSpan.FromMinutes(4), Album = album1 };
            var track3 = new Track { Name = "Smells Like Teen Spirit", Duration = TimeSpan.FromMinutes(5), Album = album2 };

            var playlist1 = new Playlist { Name = "Rock Classics", Category = "Rock", Tracks = new List<Track> { track1, track3 } };

            context.Artists.AddRange(new[] { artist1, artist2 });
            context.Albums.AddRange(new[] { album1, album2 });
            context.Tracks.AddRange(new[] { track1, track2, track3 });
            context.Playlists.Add(playlist1);

            context.SaveChanges();
        }
    }
}
