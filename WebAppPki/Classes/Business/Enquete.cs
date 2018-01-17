using Classes.Files;
using KpiApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Business
{
    public class Enquete : Persist
    {
        public long  ID { get; set; }
        public string Titre { get; set; }
        public string Campagne { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }        
        public CibleEnquete Cible { get; set; }
        public string CibleAsString 
        {
             get
            {
                return Cible != null ? Cible.Nom : string.Empty;
            }   
        }

        public Enquete()
        {
            db = DataAccessFactory.ObtenirAccesDonnees();
        }

        public override bool fnGet(object ID)
        {
            try
            {
                db.definirProcedureStockee("Enquete_Obtenir");
                db.ajouterParametreEntree("@ID", 64, SqlDbType.BigInt, (long)ID);
                IDataReader dr = db.executeReader();
                dr.Read();
                mapFromDataReaderToObject(dr, this);
                dr.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Persist> fnSelect(string campagneID, short cibleEnqueteID, short status)
        {
            List<Enquete> mListe = new List<Enquete>();

            db.definirProcedureStockee("Enquete_Lister");
            db.ajouterParametreEntree("@Campagne", 8, SqlDbType.VarChar, campagneID);
            db.ajouterParametreEntree("@CibleEnqueteID", 8, SqlDbType.SmallInt, cibleEnqueteID);
            db.ajouterParametreEntree("@Status", 8, SqlDbType.SmallInt, status);

            IDataReader reader = db.executeReader();

            while (reader.Read())
            {
                Enquete mClass = new Enquete();

                mapFromDataReaderToObject(reader, mClass);

                mListe.Add(mClass);
            }
            reader.Close();
            return mListe;
        }

        public override IEnumerable<Persist> fnSelect()
        {
            return fnSelect("Tous", -1, -1);
        }

        public override bool fnUpdate()
        {
            bool Result = false;

         //   @Id BigInt OUTPUT,
	        //@Titre varchar(500),
         //   @Campagne varchar(9),
         //   @DateDebut datetime,
         //   @DateFin datetime,
         //   @CibleEnqueteID smallint,
         //   @RowVersion timestamp OUTPUT,
         //   @ErrorMessage varchar(50) OUTPUT


            if (IsNew)
            {
                db.definirProcedureStockee("Enquete_Creer");
                db.ajouterParametreSortie("@ID", 32, SqlDbType.Int, ID);
                db.ajouterParametreSortie("@Rowversion", 50, SqlDbType.Timestamp, RowVersion);
            }
            else
            {
                db.definirProcedureStockee("Enquete_Modifier");
                db.ajouterParametreEntree("@ID", 32, SqlDbType.Int, ID);
                db.ajouterParametreEntree("@RowVersion", 50, SqlDbType.Timestamp, RowVersion);
            }

            db.ajouterParametreEntree("@Titre", 50, SqlDbType.VarChar, Titre);
            db.ajouterParametreEntree("@Campagne", 50, SqlDbType.VarChar, Campagne);
            db.ajouterParametreEntree("@DateDebut", 50, SqlDbType.VarChar, DateDebut);
            db.ajouterParametreEntree("@DateFin", 50, SqlDbType.VarChar, DateFin);
            db.ajouterParametreEntree("@CibleEnqueteID", 50, SqlDbType.SmallInt, Cible.ID);
            db.ajouterParametreSortie("@ErrorMessage", 50, SqlDbType.VarChar, string.Empty);


            db.ajouterParametreRetour("@ReturnValue", 8, SqlDbType.Int);
            IDataReader dr = db.executeReader();
            int RetVal = (int)db.obtenirParametre("@ReturnValue");

            switch (RetVal)
            {
                case 0:
                    RowVersion = (byte[])db.obtenirParametre("@RowVersion");

                    if (IsNew)
                        ID = (int)db.obtenirParametre("@ID");

                    IsNew = false;
                    Result = true;
                    break;
                default:
                    string errMsg = (string)db.obtenirParametre("@ErrorMessage");
                    Result = false;
                    throw new Exception();
            }
            return Result;
        }       

        public override bool fnDelete()
        {
            bool Result = false;
            db.definirProcedureStockee("Enquete_Supprimer");
            db.ajouterParametreEntree("@ID", 32, SqlDbType.BigInt, ID);

            db.ajouterParametreRetour("@ReturnValue", 8, SqlDbType.Int);
            IDataReader dr = db.executeReader();
            int RetVal = (int)db.obtenirParametre("@ReturnValue");

            switch (RetVal)
            {
                case 0:
                    RowVersion = (byte[])db.obtenirParametre("@RowVersion");

                    IsNew = false;
                    Result = true;
                    break;
                default:
                    string errMsg = (string)db.obtenirParametre("@ErrorMessage");
                    Result = false;
                    throw new Exception();
            }
            return Result;
        }

        private void mapFromDataReaderToObject(IDataReader reader, Enquete mClass)
        {

            if (reader != null)
            {
                if (!Convert.IsDBNull(reader["ID"]))
                    mClass.ID = (int)reader["ID"];

                if (!Convert.IsDBNull(reader["Titre"]))
                    mClass.Titre = reader["Titre"].ToString();

                if (!Convert.IsDBNull(reader["Campagne"]))
                    mClass.Campagne = reader["Campagne"].ToString();

                mClass.Cible = new CibleEnquete();

                if (!Convert.IsDBNull(reader["CibleID"]))
                    mClass.Cible.ID = short.Parse(reader["CibleID"].ToString());

                if (!Convert.IsDBNull(reader["CibleNom"]))
                    mClass.Cible.Nom= reader["CibleNom"].ToString();


                if (!Convert.IsDBNull(reader["DateDebut"]))
                    mClass.DateDebut = DateTime.Parse(reader["DateDebut"].ToString());

                if (!Convert.IsDBNull(reader["DateFin"]))
                    mClass.DateDebut = DateTime.Parse(reader["DateFin"].ToString());

                if (!Convert.IsDBNull(reader["CreationDate"]))
                    mClass.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());

                if (!Convert.IsDBNull(reader["CreationUtilisateur"]))
                    mClass.CreationUtilisateur = reader["CreationUtilisateur"].ToString();

                if (!Convert.IsDBNull(reader["ModificationUtilisateur"]))
                    mClass.ModificationUtilisateur = reader["ModificationUtilisateur"].ToString();


                if (!Convert.IsDBNull(reader["ModificationDate"]))
                    mClass.ModificationDate = DateTime.Parse(reader["ModificationDate"].ToString());

                if (!Convert.IsDBNull(reader["Rowversion"]))
                    mClass.RowVersion = (byte[])reader["RowVersion"];

                if (!Convert.IsDBNull(reader["Statut"]))
                    mClass.Statut = (bool)reader["Statut"];

            }
        }
    }
}
