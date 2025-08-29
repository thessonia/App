
using hm.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace hm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MusicInitializer());

            using (var db = new MusicContext())
            {
                Console.WriteLine("=== Усі плейлисти ===");
                foreach (var playlist in db.Playlists.Include("Tracks"))
                {
                    Console.WriteLine($"Playlist: {playlist.Name} ({playlist.Category})");
                    foreach (var track in playlist.Tracks)
                    {
                        Console.WriteLine($"   - {track.Name} ({track.Duration})");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
