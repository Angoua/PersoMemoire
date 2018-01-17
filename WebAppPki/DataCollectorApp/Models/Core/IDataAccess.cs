using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KpiApp.Models
{
    public interface IDataAccess
    {
       
        void ajouterParametreEntree(string nomPara, int taille, System.Data.SqlDbType dbType, object valeur);
        void ajouterParametreEntreeSortie(string nomPara, int taille, System.Data.SqlDbType dbType, object valeur);
        void ajouterParametreRetour(string nomPara, int taille, System.Data.SqlDbType dbType);
        void ajouterParametreSortie(string nomPara, int taille, System.Data.SqlDbType dbType, object valeur);
        object obtenirParametre(string nomPara);

        void Close();
        void commandeType(System.Data.CommandType type);
        void definirProcedureStockee(string procStock);
        int executeNonQuery();
        System.Data.SqlClient.SqlDataReader executeReader();
        void OuvrirConnexion();
        
    }
}
