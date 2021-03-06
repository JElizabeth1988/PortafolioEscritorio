using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


//Código de Clase en enlace shorturl.at/tLOU4
//Esta clase transforma y serializa los objetos en la gráfica en un objeto de memoria caché
namespace Vista
{

    public sealed class ObjectBinder : System.Runtime.Serialization.SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;
            String currentAssembly = Assembly.GetExecutingAssembly().FullName;

            // In this case we are always using the current assembly
            assemblyName = currentAssembly;

            // Get the type using the typeName and assemblyName
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
            typeName, assemblyName));

            return typeToDeserialize;
        }
    }

}