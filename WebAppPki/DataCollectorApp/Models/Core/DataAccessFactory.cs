using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpiApp.Models
{
    public class DataAccessFactory
    {
        //Obtenir l'obet d'accès aux données
        public static IDataAccess ObtenirAccesDonnees()
        {
            return new SqlServerDataAccess();
        }
    }
}