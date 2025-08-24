using ProySpaHelena.Models;
namespace ProyClienteSpaHelena.Services
{
    public interface EspecialidadService
    {
        Task<List<VariantesServicio>> GetAllEspecialidadesAsync();
        Task<VariantesServicio> GetEspecialidadesByIdAsync(int id);
        Task<VariantesServicio> CreateEspecialidadesAsync(VariantesServicio variantesServicio);
        Task<string> UpdateEspecialidadesAsync( VariantesServicio variantesServicio);
        Task<string> DeleteEspecialidadesAsync(int id);
    }
}
