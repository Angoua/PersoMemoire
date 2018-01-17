using Classes.Core;
using KpiApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


    public class TypeReponse : Persist
    {
        public short ID { get; set; }
        public string  Libelle { get; set; }

        public TypeReponse()
        {
            db = DataAccessFactory.ObtenirAccesDonnees();
        }

        public override bool fnDelete()
        {
            throw new NotImplementedException();
        }

        public override bool fnGet(object ID)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Persist> fnSelect()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Persist> fnSelect(short status)
        {
            List<TypeReponse> mListe = new List<TypeReponse>();

            db.definirProcedureStockee("TypeReponse_Lister");

            db.ajouterParametreEntree("@Status", 8, SqlDbType.SmallInt, status);

            IDataReader reader = db.executeReader();

            while (reader.Read())
            {
                TypeReponse mClass = new TypeReponse();

                mapFromDataReaderToObject(reader, mClass);

                mListe.Add(mClass);
            }
            reader.Close();
            return mListe;
        }

        public override bool fnUpdate()
        {
            throw new NotImplementedException();
        }



        private void mapFromDataReaderToObject(IDataReader reader, TypeReponse mClass)
        {

            if (reader != null)
            {
                if (!Convert.IsDBNull(reader["ID"]))
                    mClass.ID = (short)reader["ID"];

                if (!Convert.IsDBNull(reader["Libelle"]))
                    mClass.Libelle = reader["Libelle"].ToString();             

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