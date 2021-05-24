using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class sequelmovieContext : DbContext
    {
        public sequelmovieContext()
        {
        }

        public sequelmovieContext(DbContextOptions<sequelmovieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artiste> Artistes { get; set; }
        public virtual DbSet<ArtisteBand> ArtisteBands { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<MovieStudio> MovieStudios { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Poster> Posters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongArtiste> SongArtistes { get; set; }
        public virtual DbSet<SongBand> SongBands { get; set; }
        public virtual DbSet<Soundtrack> Soundtracks { get; set; }
        public virtual DbSet<SoundtrackSong> SoundtrackSongs { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<Trailer> Trailers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseMySQL(configuration.GetConnectionString("sequelmovie"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiste>(entity =>
            {
                entity.ToTable("artiste");

                entity.Property(e => e.ArtisteId)
                    .HasColumnType("int(5)")
                    .HasColumnName("artisteID");

                entity.Property(e => e.ArtisteName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("artisteName");

                entity.Property(e => e.ArtisteNationality)
                    .HasMaxLength(50)
                    .HasColumnName("artisteNationality")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<ArtisteBand>(entity =>
            {
                entity.ToTable("artiste_band");

                entity.HasIndex(e => e.AArtisteId, "artiste_band_fk_artiste");

                entity.HasIndex(e => e.BBandId, "artiste_band_fk_band");

                entity.Property(e => e.ArtisteBandId)
                    .HasColumnType("int(5)")
                    .HasColumnName("artiste_bandID");

                entity.Property(e => e.AArtisteId)
                    .HasColumnType("int(5)")
                    .HasColumnName("a_artisteID");

                entity.Property(e => e.BBandId)
                    .HasColumnType("int(5)")
                    .HasColumnName("b_bandID");

                entity.Property(e => e.BandRole)
                    .HasMaxLength(50)
                    .HasColumnName("bandRole")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.AArtiste)
                    .WithMany(p => p.ArtisteBands)
                    .HasForeignKey(d => d.AArtisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artiste_band_fk_artiste");

                entity.HasOne(d => d.BBand)
                    .WithMany(p => p.ArtisteBands)
                    .HasForeignKey(d => d.BBandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artiste_band_fk_band");
            });

            modelBuilder.Entity<Band>(entity =>
            {
                entity.ToTable("band");

                entity.Property(e => e.BandId)
                    .HasColumnType("int(5)")
                    .HasColumnName("bandID");

                entity.Property(e => e.BandName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("bandName");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId)
                    .HasColumnType("int(5)")
                    .HasColumnName("genreID");

                entity.Property(e => e.GenreDesc)
                    .HasMaxLength(200)
                    .HasColumnName("genreDesc")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.GenreType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("genreType");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.MovieId)
                    .HasColumnType("int(5)")
                    .HasColumnName("movieID");

                entity.Property(e => e.MovieCertificate)
                    .HasMaxLength(4)
                    .HasColumnName("movieCertificate")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MovieDesc)
                    .HasMaxLength(150)
                    .HasColumnName("movieDesc")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MovieRating)
                    .HasColumnType("int(1)")
                    .HasColumnName("movieRating")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MovieReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("movieReleaseDate")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MovieRuntime)
                    .HasColumnType("int(3)")
                    .HasColumnName("movieRuntime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MovieTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("movieTitle");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.ToTable("movie_genre");

                entity.HasIndex(e => e.GGenreId, "movie_genre_fk_genre");

                entity.HasIndex(e => e.MMovieId, "movie_genre_fk_movie");

                entity.Property(e => e.MovieGenreId)
                    .HasColumnType("int(5)")
                    .HasColumnName("movie_genreID");

                entity.Property(e => e.GGenreId)
                    .HasColumnType("int(5)")
                    .HasColumnName("g_genreID");

                entity.Property(e => e.MMovieId)
                    .HasColumnType("int(5)")
                    .HasColumnName("m_movieID");

                entity.HasOne(d => d.GGenre)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(d => d.GGenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movie_genre_fk_genre");

                entity.HasOne(d => d.MMovie)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(d => d.MMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movie_genre_fk_movie");
            });

            modelBuilder.Entity<MovieStudio>(entity =>
            {
                entity.ToTable("movie_studio");

                entity.HasIndex(e => e.MMovieId, "movie_studio_fk_movie");

                entity.HasIndex(e => e.SStudioId, "movie_studio_fk_studio");

                entity.Property(e => e.MovieStudioId)
                    .HasColumnType("int(5)")
                    .HasColumnName("movie_studioID");

                entity.Property(e => e.MMovieId)
                    .HasColumnType("int(5)")
                    .HasColumnName("m_movieID");

                entity.Property(e => e.SStudioId)
                    .HasColumnType("int(5)")
                    .HasColumnName("s_studioID");

                entity.HasOne(d => d.MMovie)
                    .WithMany(p => p.MovieStudios)
                    .HasForeignKey(d => d.MMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movie_studio_fk_movie");

                entity.HasOne(d => d.SStudio)
                    .WithMany(p => p.MovieStudios)
                    .HasForeignKey(d => d.SStudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movie_studio_fk_studio");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.PersonId)
                    .HasColumnType("int(5)")
                    .HasColumnName("personID");

                entity.Property(e => e.PersonFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("personFirstName");

                entity.Property(e => e.PersonLastName)
                    .HasMaxLength(50)
                    .HasColumnName("personLastName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PersonNationality)
                    .HasMaxLength(50)
                    .HasColumnName("personNationality")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PersonPicture)
                    .HasMaxLength(150)
                    .HasColumnName("personPicture")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Poster>(entity =>
            {
                entity.ToTable("poster");

                entity.HasIndex(e => e.PMovieId, "poster_fk_movie");

                entity.Property(e => e.PosterId)
                    .HasColumnType("int(5)")
                    .HasColumnName("posterID");

                entity.Property(e => e.PMovieId)
                    .HasColumnType("int(5)")
                    .HasColumnName("p_movieID");

                entity.Property(e => e.PosterLink)
                    .HasMaxLength(200)
                    .HasColumnName("posterLink")
                    .HasDefaultValueSql("'''http://www.uidownload.com/files/478/82/442/error-404-page-not-found-icon.jpg'''");

                entity.HasOne(d => d.PMovie)
                    .WithMany(p => p.Posters)
                    .HasForeignKey(d => d.PMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("poster_fk_movie");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.MMovieId, "role_fk_movie");

                entity.HasIndex(e => e.PPersonId, "role_fk_person");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(5)")
                    .HasColumnName("roleID");

                entity.Property(e => e.MMovieId)
                    .HasColumnType("int(5)")
                    .HasColumnName("m_movieID");

                entity.Property(e => e.PPersonId)
                    .HasColumnType("int(5)")
                    .HasColumnName("p_personID");

                entity.Property(e => e.RoleDesc)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("roleDesc");

                entity.HasOne(d => d.MMovie)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.MMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_fk_movie");

                entity.HasOne(d => d.PPerson)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.PPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_fk_person");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("song");

                entity.Property(e => e.SongId)
                    .HasColumnType("int(5)")
                    .HasColumnName("songID");

                entity.Property(e => e.SongLength)
                    .HasColumnType("int(3)")
                    .HasColumnName("songLength")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("songName");

                entity.Property(e => e.SongUrl)
                    .HasMaxLength(150)
                    .HasColumnName("songURL")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<SongArtiste>(entity =>
            {
                entity.ToTable("song_artiste");

                entity.HasIndex(e => e.AArtisteId, "song_artiste_fk_artiste");

                entity.HasIndex(e => e.SSongId, "song_artiste_fk_song");

                entity.Property(e => e.SongArtisteId)
                    .HasColumnType("int(5)")
                    .HasColumnName("song_artisteID");

                entity.Property(e => e.AArtisteId)
                    .HasColumnType("int(5)")
                    .HasColumnName("a_artisteID");

                entity.Property(e => e.SSongId)
                    .HasColumnType("int(5)")
                    .HasColumnName("s_songID");

                entity.HasOne(d => d.AArtiste)
                    .WithMany(p => p.SongArtistes)
                    .HasForeignKey(d => d.AArtisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("song_artiste_fk_artiste");

                entity.HasOne(d => d.SSong)
                    .WithMany(p => p.SongArtistes)
                    .HasForeignKey(d => d.SSongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("song_artiste_fk_song");
            });

            modelBuilder.Entity<SongBand>(entity =>
            {
                entity.ToTable("song_band");

                entity.HasIndex(e => e.BBandId, "song_band_fk_band");

                entity.HasIndex(e => e.SongSongId, "song_band_fk_song");

                entity.Property(e => e.SongBandId)
                    .HasColumnType("int(5)")
                    .HasColumnName("song_bandID");

                entity.Property(e => e.BBandId)
                    .HasColumnType("int(5)")
                    .HasColumnName("b_bandID");

                entity.Property(e => e.SongSongId)
                    .HasColumnType("int(5)")
                    .HasColumnName("song_songID");

                entity.HasOne(d => d.BBand)
                    .WithMany(p => p.SongBands)
                    .HasForeignKey(d => d.BBandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("song_band_fk_band");

                entity.HasOne(d => d.SongSong)
                    .WithMany(p => p.SongBands)
                    .HasForeignKey(d => d.SongSongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("song_band_fk_song");
            });

            modelBuilder.Entity<Soundtrack>(entity =>
            {
                entity.ToTable("soundtrack");

                entity.HasIndex(e => e.MMovieId, "soundtrack_fk_movie");

                entity.Property(e => e.SoundtrackId)
                    .HasColumnType("int(5)")
                    .HasColumnName("soundtrackID");

                entity.Property(e => e.MMovieId)
                    .HasColumnType("int(5)")
                    .HasColumnName("m_movieID");

                entity.Property(e => e.SoundtrackName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("soundtrackName");

                entity.Property(e => e.SoundtrackSize)
                    .HasColumnType("int(2)")
                    .HasColumnName("soundtrackSize")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.MMovie)
                    .WithMany(p => p.Soundtracks)
                    .HasForeignKey(d => d.MMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("soundtrack_fk_movie");
            });

            modelBuilder.Entity<SoundtrackSong>(entity =>
            {
                entity.ToTable("soundtrack_song");

                entity.HasIndex(e => e.SongSongId, "soundtrack_song_fk_song");

                entity.HasIndex(e => e.SoundtrackSoundtrackId, "soundtrack_song_fk_soundtrack");

                entity.Property(e => e.SoundtrackSongId)
                    .HasColumnType("int(5)")
                    .HasColumnName("soundtrack_songID");

                entity.Property(e => e.SongSongId)
                    .HasColumnType("int(5)")
                    .HasColumnName("song_songID");

                entity.Property(e => e.SoundtrackSoundtrackId)
                    .HasColumnType("int(5)")
                    .HasColumnName("soundtrack_soundtrackID");

                entity.HasOne(d => d.SongSong)
                    .WithMany(p => p.SoundtrackSongs)
                    .HasForeignKey(d => d.SongSongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("soundtrack_song_fk_song");

                entity.HasOne(d => d.SoundtrackSoundtrack)
                    .WithMany(p => p.SoundtrackSongs)
                    .HasForeignKey(d => d.SoundtrackSoundtrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("soundtrack_song_fk_soundtrack");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.ToTable("studio");

                entity.Property(e => e.StudioId)
                    .HasColumnType("int(5)")
                    .HasColumnName("studioID");

                entity.Property(e => e.StudioAddress)
                    .HasMaxLength(200)
                    .HasColumnName("studioAddress")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StudioName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("studioName");
            });

            modelBuilder.Entity<Trailer>(entity =>
            {
                entity.ToTable("trailer");

                entity.HasIndex(e => e.TMovieId, "trailer_fk_movie");

                entity.Property(e => e.TrailerId)
                    .HasColumnType("int(5)")
                    .HasColumnName("trailerID");

                entity.Property(e => e.TMovieId)
                    .HasColumnType("int(5)")
                    .HasColumnName("t_movieID");

                entity.Property(e => e.TrailerLength)
                    .HasColumnType("int(2)")
                    .HasColumnName("trailerLength")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TrailerUrl)
                    .HasMaxLength(150)
                    .HasColumnName("trailerURL")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.TMovie)
                    .WithMany(p => p.Trailers)
                    .HasForeignKey(d => d.TMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trailer_fk_movie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
