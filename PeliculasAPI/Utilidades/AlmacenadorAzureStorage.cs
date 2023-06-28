using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace PeliculasAPI.Utilidades
{
    public class AlmacenadorAzureStorage : IAlmacenadorArchivos
    {
        private string connectionString;
        public AlmacenadorAzureStorage(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage");
        }
        public async Task<string> GuardarArchivo(string contenedor, IFormFile archivo)
        {
            var cliente = new BlobContainerClient(connectionString, contenedor);
            await cliente.CreateIfNotExistsAsync(); // Crea el contenedor si no existe
            cliente.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob); // Permite que los archivos sean publicos

            var extension = Path.GetExtension(archivo.FileName);
            var archivoNombre = $"{System.Guid.NewGuid()}{extension}"; // Genera un nombre unico para el archivo
            var blob = cliente.GetBlobClient(archivoNombre);
            await blob.UploadAsync(archivo.OpenReadStream());
            return blob.Uri.ToString();
        }

        public async Task BorrarArchivo(string ruta, string contenedor)
        {
            if (string.IsNullOrEmpty(ruta))
            {
                return;
            }
            var cliente = new BlobContainerClient(connectionString, contenedor);
            await cliente.CreateIfNotExistsAsync(); // Crea el contenedor si no existe
            var archivoNombre = Path.GetFileName(ruta); // Obtiene el nombre del archivo
            var blob = cliente.GetBlobClient(archivoNombre); // Obtiene el archivo
            await blob.DeleteIfExistsAsync(); // Borra el archivo
        }

        public async Task<string> EditarArchivo(string contenedor, IFormFile archivo, string ruta)
        {
            await BorrarArchivo(ruta, contenedor);
            return await GuardarArchivo(contenedor, archivo);
        }
    }
}
