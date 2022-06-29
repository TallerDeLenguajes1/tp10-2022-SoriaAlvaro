using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Lista;

string url = "https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
HttpClient client = new HttpClient();
var httpResponse = await client.GetAsync(url);

    int op;
if(httpResponse.IsSuccessStatusCode){
    var content = await httpResponse.Content.ReadAsStringAsync();
    var roots = JsonSerializer.Deserialize<Root>(content);
    System.Console.WriteLine("Escriba el ID para ver una civilización.");
    foreach(var datos in roots.civilizations){
        System.Console.WriteLine("\tID {0}: {1}\n",datos.id,datos.name);
    }
    do{
        op = Convert.ToInt32(Console.ReadLine());
        if(!(op >= 0 && op < ((int)(roots.civilizations.Count)))){
            System.Console.WriteLine("Elija una opción correcta");
        }else{
            foreach(var datos in roots.civilizations){    
                if(op == datos.id){
                    System.Console.WriteLine("ID: {0}\nName: {1}\nExpansion: {2}\nArmy Type: {3}\n",datos.id,datos.name,datos.expansion,datos.army_type);
                }
            }
        }
    }while(!(op >= 0 && op < ((int)(roots.civilizations.Count))));
}