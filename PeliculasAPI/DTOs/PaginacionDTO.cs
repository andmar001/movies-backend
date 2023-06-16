namespace PeliculasAPI.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPAgina = 10;
        private readonly int cantidadMaximaPorPagina = 50;
        public int RecordsPorPagina
        {
            get
            {
                return recordsPorPAgina;
            }
            set 
            {
                //validacion para que no supere 50 registros por página
                recordsPorPAgina = (value > cantidadMaximaPorPagina) ? cantidadMaximaPorPagina:value ; 
            }
        }
    }
}
