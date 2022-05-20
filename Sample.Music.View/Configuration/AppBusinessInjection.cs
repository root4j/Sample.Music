namespace Sample.Music.View.Configuration
{
    public static class AppBusinessInjection
    {
        public static IServiceCollection AddBusinessInjection(this IServiceCollection services)
        {
            #region Business Injection
            services.AddScoped<Model.Interfaces.IAlbumBusiness, Model.Business.AlbumBusiness>();
            services.AddScoped<Model.Interfaces.IAlbumGenreBusiness, Model.Business.AlbumGenreBusiness>();
            services.AddScoped<Model.Interfaces.IAlbumSongBusiness, Model.Business.AlbumSongBusiness>();
            services.AddScoped<Model.Interfaces.IArtistBusiness, Model.Business.ArtistBusiness>();
            services.AddScoped<Model.Interfaces.IGenreBusiness, Model.Business.GenreBusiness>();
            services.AddScoped<Model.Interfaces.ISongBusiness, Model.Business.SongBusiness>();
            #endregion

            return services;
        }
    }
}