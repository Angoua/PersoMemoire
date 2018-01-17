
using Classes.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


    public class Question : Persist
    {
        public long ID { get; set; }
        public string Intitule { get; set; }
        public string CourteDescription { get; set; }

        public TypeReponse TypeReponse { get; set; }

        public string TypeReponseAsString { get; set; }

        public Enquete Enquete { get; set; }

        public string EnqueteAsString { get; set; }



        public override bool fnDelete()
        {
            bool Result = false;

            db.definirProcedureStockee("Question_Supprimer");
            db.ajouterParametreEntree("@ID", 64, SqlDbType.BigInt, ID);

            db.ajouterParametreRetour("@ReturnValue", 8, SqlDbType.Int);
            IDataReader dr = db.executeReader();
            int RetVal = (int)db.obtenirParametre("@ReturnValue");

            switch (RetVal)
            {
                case 0:
                    RowVersion = (byte[])db.obtenirParametre("@RowVersion");

                    if (IsNew)
                        ID = (long)db.obtenirParametre("@ID");

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

        public override bool fnGet(object ID)
        {
            try
            {
                db.definirProcedureStockee("Question_Obtenir");
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

        public IEnumerable<Persist> fnSelectByEnquete(long enqueteID)
        {
            List<Question> mListe = new List<Question>();

            db.definirProcedureStockee("Question_ListerParEnquete");

            db.ajouterParametreEntree("@EnqueteID", 8, SqlDbType.VarChar, enqueteID);

            IDataReader reader = db.executeReader();

            while (reader.Read())
            {
                Question mClass = new Question();

                mapFromDataReaderToObject(reader, mClass);

                mListe.Add(mClass);
            }
            reader.Close();

            return mListe;
        }

        public override IEnumerable<Persist> fnSelect()
        {
            throw new NotImplementedException();
        }

        public override bool fnUpdate()
        {
            bool Result = false;

            if (IsNew)
            {
                db.definirProcedureStockee("Question_Creer");
                db.ajouterParametreSortie("@ID", 64, SqlDbType.BigInt, ID);
                db.ajouterParametreSortie("@Rowversion", 50, SqlDbType.Timestamp, RowVersion);
            }
            else
            {
                db.definirProcedureStockee("Question_Modifier");
                db.ajouterParametreEntree("@ID", 64, SqlDbType.BigInt, ID);
                db.ajouterParametreEntree("@RowVersion", 50, SqlDbType.Timestamp, RowVersion);
            }

            db.ajouterParametreEntree("@Intitule", 500, SqlDbType.VarChar, this.Intitule);
            db.ajouterParametreEntree("@CourteDescription", 50, SqlDbType.VarChar, this.CourteDescription);
            db.ajouterParametreEntree("@TypeReponseID", 50, SqlDbType.SmallInt, this.TypeReponse.ID);
            db.ajouterParametreEntree("@EnqueteID", 50, SqlDbType.BigInt, this.Enquete.EnqueteID);
           
            db.ajouterParametreSortie("@ErrorMessage", 50, SqlDbType.VarChar, string.Empty);


            db.ajouterParametreRetour("@ReturnValue", 8, SqlDbType.Int);
            IDataReader dr = db.executeReader();
            int RetVal = (int)db.obtenirParametre("@ReturnValue");

            switch (RetVal)
            {
                case 0:
                    RowVersion = (byte[])db.obtenirParametre("@RowVersion");

                    if (IsNew)
                        ID = (long)db.obtenirParametre("@ID");

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


        private void mapFromDataReaderToObject(IDataReader reader, Question mClass)
        {
            
            if (reader != null)
            {
                mClass.IsNew = false;

                if (!Convert.IsDBNull(reader["ID"]))
                    mClass.ID = (short)reader["ID"];

                if (!Convert.IsDBNull(reader["Intitule"]))
                    mClass.Intitule = reader["Intitule"].ToString();

                if (!Convert.IsDBNull(reader["CourteDescription"]))
                    mClass.CourteDescription = reader["CourteDescription"].ToString();

                mClass.TypeReponse = new TypeReponse();
                if (!Convert.IsDBNull(reader["TypeReponseID"]))
                    mClass.TypeReponse.ID = short.Parse(reader["TypeReponseID"].ToString());

                if (!Convert.IsDBNull(reader["TypeReponseNom"]))
                    mClass.TypeReponse.Libelle = reader["TypeReponseNom"].ToString();


                mClass.Enquete = new Enquete();
                if (!Convert.IsDBNull(reader["EnqueteID"]))
                    mClass.Enquete.EnqueteID = long.Parse(reader["EnqueteID"].ToString());

                if (!Convert.IsDBNull(reader["EnqueteNom"]))
                    mClass.Enquete.Titre = reader["EnqueteNom"].ToString();


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
                    mClass.EstDesactive = (bool)reader["Statut"];

            }
        }
    }
