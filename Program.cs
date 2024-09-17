using System.Text.Json;
using ClassTablaFAT; 

static void create_file_json(string titulo, string datos){
    string[] palabras = datos.Split(' ');
    int tamanio = palabras.Length;

    int docs = tamanio / 20;
    int residuo = tamanio % 20;
    int no_doc = 1;

    string folderPath = $@"C:\Users\artha\Desktop\Cuarto Semestre\Manejo e implementacion\ProyectoFAT\{titulo}";

    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
    }
    else
    {
        Console.WriteLine("La carpeta ya existe.");
    }

    for (int j = 0; j < (docs + 1); j++) {
        if (no_doc == 4 && residuo != 0) {
            string texto = "";
            for (int k = ((j + 1) * 20); k < (((j + 1) * 20) + residuo); k++) {
                if (k == ((j + 1) * 20)) {
                    texto += palabras[k];
                }
                else {
                    texto += " " + palabras[k];
                }
            }
            string actual_directory = Directory.GetCurrentDirectory();
            string filePath = $"{actual_directory}/{titulo}/{titulo}{j + 2}.json";
            try{
                string jsonFromFile = File.ReadAllText(filePath);
                string deserializedText = JsonSerializer.Deserialize<string>(jsonFromFile)!;
                deserializedText += texto; 
                string jsonString = JsonSerializer.Serialize(deserializedText);
                File.WriteAllText(filePath, jsonString);
            }
            catch{
                string jsonString2 = JsonSerializer.Serialize(texto);
                File.WriteAllText(filePath, jsonString2);
            }
        }
        
        if (j == docs) {
            string texto = "";
            for (int k = (j * 20); k < ((j * 20) + 20) && k < palabras.Length; k++) {
                if (k == (j * 20)) {
                    texto += palabras[k];
                }
                else {
                    texto += " " + palabras[k];
                }
            }
            string actual_directory = Directory.GetCurrentDirectory();
            string filePath = $"{actual_directory}/{titulo}/{titulo}{j + 1}.json";
            try{
                string jsonFromFile = File.ReadAllText(filePath);
                string deserializedText = JsonSerializer.Deserialize<string>(jsonFromFile)!;
                deserializedText += texto; 
                string jsonString = JsonSerializer.Serialize(deserializedText);
                File.WriteAllText(filePath, jsonString);
            }
            catch{
                string jsonString2 = JsonSerializer.Serialize(texto);
                File.WriteAllText(filePath, jsonString2);
            }      
        }
        else {
            string texto = "";
            for (int k = (j * 20); k < ((j * 20) + 20); k++) {
                if (k == (j * 20)) {
                    texto += palabras[k];
                }
                else {
                    texto += " " + palabras[k];
                }
            }
            string actual_directory = Directory.GetCurrentDirectory();
            string filePath = $"{actual_directory}/{titulo}/{titulo}{j + 1}.json";
            try{
                string jsonFromFile = File.ReadAllText(filePath);
                string deserializedText = JsonSerializer.Deserialize<string>(jsonFromFile)!;
                deserializedText += texto; 
                string jsonString = JsonSerializer.Serialize(deserializedText);
                File.WriteAllText(filePath, jsonString);
            }
            catch{
                string jsonString2 = JsonSerializer.Serialize(texto);
                File.WriteAllText(filePath, jsonString2);
            }      
        }
    }
}


static void createTabla(string titulo, string datos){
    string[] palabras = datos.Split(' ');

    string nombreArchivo = $"{titulo}";
    string rutaDatosInicial = $"C:/Users/artha/Desktop/Cuarto Semestre/Manejo e implementacion/ProyectoFAT/{titulo}/{titulo}1";
    bool papelera = false;
    int cantidadDatos = palabras.Length;
    string fechaCreacion = DateTime.Now.ToString();
    string fechaModificacion = "";
    string fechaEliminacion = "";

    string actual_directory = Directory.GetCurrentDirectory();
    string filePath = $"{actual_directory}/{titulo}/tablaFAT.json";
    
    TablaFAT tablaFAT= new TablaFAT(nombreArchivo, rutaDatosInicial, papelera, cantidadDatos, fechaCreacion, fechaModificacion, fechaEliminacion);
    try{
        string jsonFromFile = File.ReadAllText(filePath);
        List<TablaFAT> deserializedText = JsonSerializer.Deserialize<List<TablaFAT>>(jsonFromFile)!;
        deserializedText.Add(tablaFAT); 
        string jsonString = JsonSerializer.Serialize(deserializedText);
        File.WriteAllText(filePath, jsonString);
    }
    catch{
        List<TablaFAT> info = [tablaFAT];
        string jsonString2 = JsonSerializer.Serialize(info);
        File.WriteAllText(filePath, jsonString2);
    }
}


static void listar(){

    // Directorio principal donde quieres buscar
    string rootDirectory = @"C:\Users\artha\Desktop\Cuarto Semestre\Manejo e implementacion\ProyectoFAT";

    // Nombre del archivo que estás buscando
    string fileNameToFind = "tablaFAT.json";

    // Verifica si el directorio existe
    if (Directory.Exists(rootDirectory))
    {
        int i = 1;
        // Recorre todas las subcarpetas del directorio principal
        foreach (string subdirectory in Directory.GetDirectories(rootDirectory, "*", SearchOption.AllDirectories))
        {
            // Ruta completa del archivo que estamos buscando
            string filePath = Path.Combine(subdirectory, fileNameToFind);

            // Verifica si el archivo existe en la subcarpeta actual
            if (File.Exists(filePath))
            {
                string actual_directory = Directory.GetCurrentDirectory();
                string jsonFromFile = File.ReadAllText(filePath);
                List<TablaFAT> deserializedFAT = JsonSerializer.Deserialize<List<TablaFAT>>(jsonFromFile)!;

                foreach(TablaFAT tablaFAT in deserializedFAT){
                    if (tablaFAT.papelera is false){
                        if (tablaFAT.fechaModificacion == ""){
                            Console.WriteLine($"{i}) Nombre del archivo: {tablaFAT.nombreArchivo}\n   Tamaño de caracteres: {tablaFAT.cantidadDatos}\n   Fecha de creación: {tablaFAT.fechaCreacion}");
                        } else {
                            Console.WriteLine($"{i}) Nombre del archivo: {tablaFAT.nombreArchivo}\n   Tamaño de caracteres: {tablaFAT.cantidadDatos}\n   Fecha de creación: {tablaFAT.fechaCreacion}\n   Fecha de modificación: {tablaFAT.fechaModificacion}");
                        }
                        i ++;
                    }
                }
            }
        }
    }
    else
    {
        Console.WriteLine("El directorio especificado no existe.");
    }
}


static void abrir(){
    
    listar();

    // Directorio principal donde quieres buscar
    string rootDirectory = @"C:\Users\artha\Desktop\Cuarto Semestre\Manejo e implementacion\ProyectoFAT";

    // Nombre del archivo que estás buscando
    string fileNameToFind = "tablaFAT.json";

    Console.WriteLine("Que opcion deseas realizar");
    string op = Console.ReadLine()!;
    int opcionSolicitada = int.Parse(op);
    int k = 1;
    if (Directory.Exists(rootDirectory))
    {
        foreach (string subdirectory in Directory.GetDirectories(rootDirectory, "*", SearchOption.AllDirectories))
        {
            string filePath = Path.Combine(subdirectory, fileNameToFind);

            // Verifica si el archivo existe en la subcarpeta actual
            if (File.Exists(filePath))
            {
                string actual_directory = Directory.GetCurrentDirectory();
                string jsonFromFile = File.ReadAllText(filePath);
                List<TablaFAT> deserializedFAT = JsonSerializer.Deserialize<List<TablaFAT>>(jsonFromFile)!;

                foreach(TablaFAT tablaFAT in deserializedFAT){
                    if (tablaFAT.papelera is false){
                        if (tablaFAT.fechaModificacion == ""){
                            if (opcionSolicitada == k){
                                Console.WriteLine($"{k}) Nombre del archivo: {tablaFAT.nombreArchivo}\n   Tamaño de caracteres: {tablaFAT.cantidadDatos}\n   Fecha de creación: {tablaFAT.fechaCreacion}");
                                
                                string actual_directory_new = Directory.GetCurrentDirectory();
                                string filePath_new = $"{actual_directory}/{tablaFAT.nombreArchivo}";
                                int numeroDeDocumentos = Directory.GetFiles(filePath_new).Length;
                                string deserializedFAT_new = "";
                                for (int l = 1; l < numeroDeDocumentos; l++){
                                    string filePath_new_write = $"{actual_directory}/{tablaFAT.nombreArchivo}/{tablaFAT.nombreArchivo}{l}.json";
                                    string jsonFromFile_new = File.ReadAllText(filePath_new_write);
                                    if (l == 1){
                                        deserializedFAT_new += JsonSerializer.Deserialize<string>(jsonFromFile_new)!;
                                    }
                                    else{
                                        deserializedFAT_new += " ";
                                        deserializedFAT_new += JsonSerializer.Deserialize<string>(jsonFromFile_new)!;
                                    }
                                }
                                Console.WriteLine(deserializedFAT_new);
                            }
                        } else {
                            if (opcionSolicitada == k){
                                Console.WriteLine($"{k}) Nombre del archivo: {tablaFAT.nombreArchivo}\n   Tamaño de caracteres: {tablaFAT.cantidadDatos}\n   Fecha de creación: {tablaFAT.fechaCreacion}\n   Fecha de modificación: {tablaFAT.fechaModificacion}");

                                string actual_directory_new = Directory.GetCurrentDirectory();
                                string filePath_new = $"{actual_directory}/{tablaFAT.nombreArchivo}";
                                int numeroDeDocumentos = Directory.GetFiles(filePath_new).Length;
                                string deserializedFAT_new = "";
                                for (int l = 1; l < numeroDeDocumentos; l++){
                                    string filePath_new_write = $"{actual_directory}/{tablaFAT.nombreArchivo}/{tablaFAT.nombreArchivo}{l}.json";
                                    string jsonFromFile_new = File.ReadAllText(filePath_new_write);
                                    if (l == 1){
                                        deserializedFAT_new += JsonSerializer.Deserialize<string>(jsonFromFile_new)!;
                                    }
                                    else{
                                        deserializedFAT_new += " ";
                                        deserializedFAT_new += JsonSerializer.Deserialize<string>(jsonFromFile_new)!;
                                    }
                                }
                                Console.WriteLine(deserializedFAT_new);
                            }
                        }
                        k ++;
                    }
                }
            }
        }
    }
    else{
        Console.WriteLine("El directorio especificado no existe.");
    }
}


static void recuperar(){

    // Directorio principal donde quieres buscar
    string rootDirectory = @"C:\Users\artha\Desktop\Cuarto Semestre\Manejo e implementacion\ProyectoFAT";

    // Nombre del archivo que estás buscando
    string fileNameToFind = "tablaFAT.json";

    // Verifica si el directorio existe
    if (Directory.Exists(rootDirectory))
    {
        int i = 1;
        // Recorre todas las subcarpetas del directorio principal
        foreach (string subdirectory in Directory.GetDirectories(rootDirectory, "*", SearchOption.AllDirectories))
        {
            // Ruta completa del archivo que estamos buscando
            string filePath = Path.Combine(subdirectory, fileNameToFind);

            // Verifica si el archivo existe en la subcarpeta actual
            if (File.Exists(filePath))
            {
                string actual_directory = Directory.GetCurrentDirectory();
                string jsonFromFile = File.ReadAllText(filePath);
                List<TablaFAT> deserializedFAT = JsonSerializer.Deserialize<List<TablaFAT>>(jsonFromFile)!;

                foreach(TablaFAT tablaFAT in deserializedFAT){
                    if (tablaFAT.papelera is true){
                        if (tablaFAT.fechaModificacion == ""){
                            Console.WriteLine($"{i}) Nombre del archivo: {tablaFAT.nombreArchivo}\n   Tamaño de caracteres: {tablaFAT.cantidadDatos}\n   Fecha de creación: {tablaFAT.fechaCreacion}");
                        } else {
                            Console.WriteLine($"{i}) Nombre del archivo: {tablaFAT.nombreArchivo}\n   Tamaño de caracteres: {tablaFAT.cantidadDatos}\n   Fecha de creación: {tablaFAT.fechaCreacion}\n   Fecha de modificación: {tablaFAT.fechaModificacion}");
                        }
                        i ++;
                    }
                }
            }
        }
    }
    else
    {
        Console.WriteLine("El directorio especificado no existe.");
    }
}



static void main() {
    while (true) {
        Console.WriteLine("¿Qué deseas realizar?\n1) Crear archivo.\n2) Listar archivos.\n3) Abrir archivo.\n4) Modificar un archivo");
        Console.WriteLine("5) Eliminar un archivo.\n6) Recuperar un archivo.\n7) Salir.");

        string op = Console.ReadLine()!;

        if (op == "1") {
            
            Console.WriteLine("CREAR ARCHIVO");
            Console.WriteLine("Ingrese el titulo del archivo: ");
            string titulo = Console.ReadLine()!;
            Console.WriteLine("Ingrese los datos del archivo: ");
            string datos = Console.ReadLine()!;

            create_file_json(titulo, datos);
            createTabla(titulo, datos);
        }

        if (op == "2") {
            Console.WriteLine("LISTAR ARCHIVOS");
            listar();
        }

        if (op == "3") {
            Console.WriteLine("ABRIR ARCHIVOS");
            abrir();

        }

        if (op == "4") {
            Console.WriteLine("MODIFICAR ARCHIVO");

        }

        if (op == "5") {
            Console.WriteLine("ELIMINAR ARCHIVO");

            Console.WriteLine("Ingresa la palabra a buscar:");
            string palabra_buscar = Console.ReadLine()!;

        }

        if (op == "6") {
            Console.WriteLine("RECUPERAR ARCHIVO");
            recuperar();
        }

        if (op == "7") {
            Console.WriteLine("Que te vaya bien, espero haber ayudao");
            break;
        } 

    }
}


main();
