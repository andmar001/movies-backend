namespace PeliculasAPI.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 10;
        private readonly int cantidadMaximaRecordsPorPagina = 50;
        public int RecordsPorPagina
        {
            get
            {
                return recordsPorPagina;
            }
            set 
            {
                //validacion para que no supere 50 registros por página
                recordsPorPagina = (value > cantidadMaximaRecordsPorPagina) ? cantidadMaximaRecordsPorPagina : value ; 
            }
        }
    }
}
