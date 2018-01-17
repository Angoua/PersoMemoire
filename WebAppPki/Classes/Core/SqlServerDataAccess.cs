using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace KpiApp.Models
{
    public class SqlServerDataAccess : IDataAccess
    {
        SqlConnection _connnexion;
        SqlCommand _command;
        SqlDataReader _reader;
        string strConnection = "Data Source=USER\\TRAININGSQL2008;Initial Catalog=KPIDB;Integrated Security=True";


        public SqlServerDataAccess()
        {
           
        }

        private void CreerConnexion()
        {
            _connnexion = new SqlConnection();
            _connnexion.ConnectionString = strConnection;
        }

        private void CreerCommande()
        {
            OuvrirConnexion();

	    if(_command == null)
		_command = _connnexion.CreateCommand();
        }

        public void OuvrirConnexion()
        {
            if (_connnexion == null)
            {
                CreerConnexion();
                _connnexion.Open();
            }
        }

        public void definirProcedureStockee(string procStock)
        {
            
            CreerCommande();
	    commandeType(System.Data.CommandType.StoredProcedure);
            _command.CommandText = procStock;
        }

        public void commandeType(System.Data.CommandType type)
        {
            CreerCommande();
            _command.CommandType = type; 
        }

        public void ajouterParametreEntree(string nomPara , int taille ,System.Data.SqlDbType dbType , object valeur )
        {
            CreerCommande();
            SqlParameter prm = new SqlParameter();
            prm.Direction = System.Data.ParameterDirection.Input;
            prm.ParameterName = nomPara;
            prm.Size = taille;
            prm.SqlDbType = dbType;
            prm.Value = valeur;
	    
            _command.Parameters.Add(prm);
        }

        public void ajouterParametreSortie(string nomPara, int taille, System.Data.SqlDbType dbType, object valeur)
        {
            CreerCommande();
            SqlParameter prm = new SqlParameter();
            prm.Direction = System.Data.ParameterDirection.Output;
            prm.ParameterName = nomPara;
            prm.Size = taille;
            prm.SqlDbType = dbType;
            prm.Value = valeur;
            _command.Parameters.Add(prm);
        }

        public void ajouterParametreRetour(string nomPara, int taille, System.Data.SqlDbType dbType)
        {
            CreerCommande();
            SqlParameter prm = new SqlParameter();
            prm.Direction = System.Data.ParameterDirection.ReturnValue;
            prm.ParameterName = nomPara;
            prm.Size = taille;
            prm.SqlDbType = dbType;           
            _command.Parameters.Add(prm);
        }


        public object obtenirParametre(string nomPara)
        {
            return _command.Parameters[nomPara].Value;
        }
           

        public void ajouterParametreEntreeSortie(string nomPara, int taille, System.Data.SqlDbType dbType, object valeur)
        {
            CreerCommande();
            SqlParameter prm = new SqlParameter();
            prm.Direction = System.Data.ParameterDirection.InputOutput;
            prm.ParameterName = nomPara;
            prm.Size = taille;
            prm.SqlDbType = dbType;
            prm.Value = valeur;
            _command.Parameters.Add(prm);
        }


        public int executeNonQuery()
        {
            return _command.ExecuteNonQuery();
        }

        public SqlDataReader executeReader()
        {
            return _command.ExecuteReader();
        }


        public void Close()
        {
            if (_connnexion != null)
                _connnexion.Close();
        }
    }
}