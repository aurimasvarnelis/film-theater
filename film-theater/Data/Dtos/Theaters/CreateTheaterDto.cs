using System.ComponentModel.DataAnnotations;

namespace film_theater.Data.Dtos.Theaters
{
    public record CreateTheaterDto([Required] string Name, [Required] string Location);
}
