/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class AdminMySQL : MonoBehaviour
{

    public string servidorBaseDatos;
    public string nombreBaseDatos;
    public string usuarioBaseDatos;
    public string contraseñaBaseDatos;

    private string datosConexion;
    private MySqlConnection conexion;

    // Start is called before the first frame update
    void Start()
    {
        datosConexion = "Server=" + servidorBaseDatos
                        + ";Database=" + nombreBaseDatos
                        + ";Uid=" + usuarioBaseDatos
                        + ";Pwd=" + contraseñaBaseDatos
                        + ";";
                        
                        
        ConectarConServidorBaseDatos();
    }

    public void ConectarConServidorBaseDatos()
    {
        conexion = new MySqlConnection(datosConexion);

        try
        {
            conexion.Open();
            Debug.Log("Conexion con BD correcta");
        }
        catch(MySqlException error)
        {
            Debug.LogError("Impsible conectar con la BD: " + error);
        }
        
    }
}
 */