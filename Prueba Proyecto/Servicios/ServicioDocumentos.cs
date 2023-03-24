using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Proyecto.Servicios
{
    internal class ServicioDocumentos
    {
        private AzureServicio azure = new AzureServicio();
        public string SubirImagen(string ruta)
        {
            string rutaUrl = azure.SubirFoto(ruta);
            // Verifica si la imagen existe en la ruta especificada
            if (File.Exists(ruta))
            {
                // Muestra un MessageBox para confirmar si se desea borrar el archivo original
                DialogResult result = MessageBox.Show("¿Desea eliminar el archivo original?", "Eliminar archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Si se confirma, ejecuta el método BorrarArchivoOriginal para eliminar el archivo original
                    BorrarArchivoOriginal(ruta);
                }
            }
            return rutaUrl;
        }

        public void BorrarArchivoOriginal(string ruta)
        {
            File.Delete(ruta); // Elimina la imagen utilizando el método Delete de la clase File
        }
    }
}
